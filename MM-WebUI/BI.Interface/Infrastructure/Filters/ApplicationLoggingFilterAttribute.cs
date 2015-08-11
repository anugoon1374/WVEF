// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-03-2015
// ***********************************************************************
// <copyright file="ApplicationLoggingFilterAttribute.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Filter for logging application requests.</summary>
// ***********************************************************************

using System.Web.Mvc;

namespace BI.Interface.Infrastructure.Filters
{
    /// <summary>
    /// Filter for logging application requests.
    /// </summary>
    public class ApplicationLoggingFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // TODO : Implement universal logging here
        }
    }
}