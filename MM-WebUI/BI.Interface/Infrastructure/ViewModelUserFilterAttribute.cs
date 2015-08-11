// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-03-2015
// ***********************************************************************
// <copyright file="ViewModelUserFilterAttribute.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Filter for canonicalize URL and Hostname.</summary>
// ***********************************************************************

using System.Web.Mvc;
using BI.Interface.ViewModels;

namespace BI.Interface.Infrastructure.Filters
{
    /// <summary>
    /// Decorates any MVC route that needs to automatically add user information into every view model.
    /// </summary>
    /// <seealso href="http://weblogs.asp.net/rashid/asp-net-mvc-best-practices-part-1#viewModelSuperLayer">Create Layer Super Type for your ViewModel and Use Action Filter to populate common parts</seealso>
    public class ViewModelUserFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called by the ASP.NET MVC framework after the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            EntityViewModel model;

            if (filterContext.Controller.ViewData.Model == null)
            {
                model = new EntityViewModel();
                filterContext.Controller.ViewData.Model = model;
            }
            else
            {
                model = filterContext.Controller.ViewData.Model as EntityViewModel;
            }

            if (model != null)
            {
                model.IsUserAuthenticated = filterContext.HttpContext.User.Identity.IsAuthenticated;

                if (model.IsUserAuthenticated)
                {
                    model.UserName = filterContext.HttpContext.User.Identity.Name;
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }
}