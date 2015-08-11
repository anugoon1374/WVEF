// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 05-06-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 05-10-2015
// ***********************************************************************
// <copyright file="HomeController.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Default controller.</summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BI.Core.Models;
using BI.Core.Service;
using BI.Interface.Infrastructure.Feedbacks;
using BI.Interface.Infrastructure.Mappers;
using BI.Interface.ViewModels;
using Castle.Core.Internal;

namespace BI.Interface.Controllers
{
    /// <summary>
    /// The Business Controller. Also default controller of this application.
    /// </summary>
    public class BusinessController : BaseMvcController
    {
        #region Properties

        /// <summary>
        /// The data access service
        /// </summary>
        protected readonly IDataService<BusinessInfo> DataService;

        /// <summary>
        /// The data mapper for create view model
        /// </summary>
        private readonly IMapper<BusinessInfo, BusinessInfoCreateViewModel> _createMapper;

        /// <summary>
        /// The data mapper for edit view model
        /// </summary>
        private readonly IMapper<BusinessInfo, BusinessInfoEditViewModel> _editMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessController" /> class.
        /// </summary>
        /// <param name="dataService">The data service.</param>
        /// <param name="createMapper">The create mapper.</param>
        /// <param name="editMapper">The edit mapper.</param>
        public BusinessController(IDataService<BusinessInfo> dataService, IMapper<BusinessInfo, BusinessInfoCreateViewModel> createMapper, IMapper<BusinessInfo, BusinessInfoEditViewModel> editMapper)
        {
            DataService = dataService;
            _createMapper = createMapper;
            _editMapper = editMapper;
        }

        #endregion

        /// <summary>
        /// Landing page.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            var model = new SearchPageViewModel();

            // Get full business list
            var buyer = DataService.Where(q => q.Buy != "");
            model.BuyerList = buyer.ToList();
            var seller = DataService.Where(q => q.Sell != "");
            model.SellerList = seller.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SearchPageViewModel inputModel)
        {
            var model = new SearchPageViewModel();

            // Get search business list. Connect to Solr and Watson in next phase.
            var buyer = DataService.Where(q => q.Buy.Contains(inputModel.Query));
            model.BuyerList = buyer.ToList();
            var seller = DataService.Where(q => q.Sell.Contains(inputModel.Query));
            model.SellerList = seller.ToList();

            return View(model);
        }

        /// <summary>
        /// Add new business
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult New()
        {
            ViewBag.Title = "Market Mactcher (Prototype)";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(BusinessInfoCreateViewModel inputModel)
        {
            if(inputModel.Buy.IsNullOrEmpty())
                inputModel.Buy = "";
            if (inputModel.ContactJobTitle.IsNullOrEmpty())
                inputModel.ContactJobTitle = "";
            if (inputModel.Country.IsNullOrEmpty())
                inputModel.Country = "";
            if (inputModel.Website.IsNullOrEmpty())
                inputModel.Website = "";

            try
            {
                var newItemId = DataService.Insert(_createMapper.MapToEntity(inputModel, new BusinessInfo()));
                return this.RedirectToAction("New").WithSuccessAlertMessage("Congratulation!! You have complete register your business.");
            }
            catch (System.Exception ex)
            {
                return View().WithErrorAlertMessage("Oops!!! It seems we run into a tecnical problem. Please come back to try again shortly.");
            }
        }
    }
}