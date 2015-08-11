// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 03-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-02-2015
// ***********************************************************************
// <copyright file="FilterConfig.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>ASP.NET filter configuration.</summary>
// ***********************************************************************

using System.Web.Mvc;
using BI.Infrastructure;
using BI.Interface.Infrastructure.Filters;

namespace BI.Interface
{
    /// <summary>
    /// ASP.NET Filter Configuration.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <seealso href="http://hackwebwith.net/asp-net-mvc-5-action-filter-types-overview/">ASP.NET MVC 5 ACTION FILTER TYPES OVERVIEW</seealso>
        /// <seealso href="https://moz.com/blog/canonical-url-tag-the-most-important-advancement-in-seo-practices-since-sitemaps">Canonical URL Tag - The Most Important Advancement in SEO Practices Since Sitemaps</seealso>
        
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Global error handling. Use with Application_Error() in global.asax.cs for cover all error
            filters.Add(new ApplicationHandleErrorAttribute());
            // Logging every request
            filters.Add(new ApplicationLoggingFilterAttribute());

            // Canonical URL for SEO
            filters.Add(new CanonicalizeHostnameFilterAttribute());
            filters.Add(new LowerCaseFilterAttribute());
            filters.Add(new RemoveTrailingSlashFilterAttribute());

            // Enforce HTTPS for every actions
            if (AppSettings.Get("Security.EnforceHttps", false))
                filters.Add(new RequireHttpsAttribute());
        }
    }
}