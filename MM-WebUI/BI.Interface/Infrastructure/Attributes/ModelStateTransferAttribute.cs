// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-03-2015
// ***********************************************************************
// <copyright file="ModelStateTransferAttribute.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Attribute for decorates any MVC route that needs to have automatic import/export Model State to TempData.</summary>
// ***********************************************************************

using System.Web.Mvc;

namespace BI.Interface.Infrastructure.Attributes
{
    /// <summary>
    /// Base action filter for export and import Model State to TempData.
    /// </summary>
    /// <seealso href="http://weblogs.asp.net/rashid/asp-net-mvc-best-practices-part-1#prg">Use PRG Pattern for Data Modification</seealso>
    public abstract class ModelStateTempDataTransfer : ActionFilterAttribute
    {
        protected static readonly string Key = typeof(ModelStateTempDataTransfer).FullName;
    }

    /// <summary>
    /// Attribute for decorates any MVC route that needs to have automatic export Model State to TempData.
    /// </summary>
    public class ExportModelStateToTempDataAttribute : ModelStateTempDataTransfer
    {
        /// <summary>
        /// Called by the ASP.NET MVC framework after the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Only export when ModelState is not valid
            if (!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                //Export if we are redirecting
                if ((filterContext.Result is RedirectResult) || (filterContext.Result is RedirectToRouteResult))
                {
                    filterContext.Controller.TempData[Key] = filterContext.Controller.ViewData.ModelState;
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }

    /// <summary>
    /// Attribute for decorates any MVC route that needs to have automatic import Model State to TempData.
    /// </summary>
    public class ImportModelStateFromTempData : ModelStateTempDataTransfer
    {
        /// <summary>
        /// Called by the ASP.NET MVC framework after the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var modelState = filterContext.Controller.TempData[Key] as ModelStateDictionary;

            if (modelState != null)
            {
                //Only Import if we are viewing
                if (filterContext.Result is ViewResult)
                {
                    filterContext.Controller.ViewData.ModelState.Merge(modelState);
                }
                else
                {
                    //Otherwise remove it.
                    filterContext.Controller.TempData.Remove(Key);
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }
}