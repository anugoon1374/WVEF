// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 05-09-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 05-10-2015
// ***********************************************************************
// <copyright file="BusinessInfoViewModels.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>View models for Business Information entity.</summary>
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BI.Core.Models;

namespace BI.Interface.ViewModels
{
    /// <summary>
    /// Create view model of BusinessInfo.
    /// </summary>
    public class BusinessInfoCreateViewModel : EntityViewModel
    {
        [Required(ErrorMessage = "Company name is required")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Company's address is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "Company Website")]
        public string Website { get; set; }
        [Required(ErrorMessage = "Business contact name is required")]
        [Display(Name = "Business Contact Name")]
        public string ContactName { get; set; }
        [Display(Name = "Business Contact Job Title")]
        public string ContactJobTitle { get; set; }
        [Required(ErrorMessage = "Contact detail is required")]
        [Display(Name = "Contact Detail (ex. Phone, Email, etc,.)")]
        [DataType(DataType.MultilineText)]
        public string ContactDescription { get; set; }
        [Required(ErrorMessage = "Business detail is required")]
        [Display(Name = "Business Detail")]
        public string BusinessDescription { get; set; }
        [Required(ErrorMessage = "Your selling product is required")]
        [Display(Name = "Name of Product or Service I want to sell")]
        public string Sell { get; set; }
        [Display(Name = "Name of Product or Service I want to buy")]
        public string Buy { get; set; }
    }

    /// <summary>
    /// Edit view model of BusinessInfo.
    /// </summary>
    public class BusinessInfoEditViewModel : BusinessInfoCreateViewModel
    {
    }

    /// <summary>
    /// View model of search page.
    /// </summary>
    public class SearchPageViewModel
    {
        /// <summary>
        /// Gets or sets the search query.
        /// </summary>
        /// <value>The search query.</value>
        public string Query { get; set; }

        /// <summary>
        /// Gets or sets the buyer list.
        /// </summary>
        /// <value>The buyer list.</value>
        public List<BusinessInfo> BuyerList { get; set; }

        /// <summary>
        /// Gets or sets the seller list.
        /// </summary>
        /// <value>The seller list.</value>
        public List<BusinessInfo> SellerList { get; set; }
    }

}