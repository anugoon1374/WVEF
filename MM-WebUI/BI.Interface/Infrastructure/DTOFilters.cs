// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 05-31-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 05-31-2015
// ***********************************************************************
// <copyright file="DtoFilters.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>ASP.NET filter for transform data object.</summary>
// ***********************************************************************

using System.Web.Mvc;

namespace BI.Interface.Helpers
{
    #region DATA TRANSFORM ACTION FILTERS

    // --------------------------------------------------------------------------
    // Automatic transform input parameters before go to specific view model.
    // --------------------------------------------------------------------------

    /// <summary>
    /// SAMPLE : Action filter for automatically transform input parameters before go to XXX view model.
    /// </summary>
    /// <seealso href="http://weblogs.asp.net/rashid/asp-net-mvc-best-practices-part-1#actionFilterConvert">Use Action Filter to Convert to compatible Action Methods parameters</seealso>
    public class DataTransformFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //const string TabKey = "tab";
            //const string OrderByKey = "orderBy";

            //NameValueCollection queryString = filterContext.HttpContext.Request.QueryString;

            //StoryListTab tab = string.IsNullOrEmpty(queryString[TabKey]) ?
            //                    filterContext.RouteData.Values[TabKey].ToString().ToEnum(StoryListTab.Unread) :
            //                    queryString[TabKey].ToEnum(StoryListTab.Unread);

            //filterContext.ActionParameters[TabKey] = tab;

            //OrderBy orderBy = string.IsNullOrEmpty(queryString[OrderByKey]) ?
            //                    filterContext.RouteData.Values[OrderByKey].ToString().ToEnum(OrderBy.CreatedAtDescending) :
            //                    queryString[OrderByKey].ToEnum(OrderBy.CreatedAtDescending);

            //filterContext.ActionParameters[OrderByKey] = orderBy;

            base.OnActionExecuting(filterContext);
        }
    }

    #endregion DATA TRANSFORM ACTION FILTERS
}