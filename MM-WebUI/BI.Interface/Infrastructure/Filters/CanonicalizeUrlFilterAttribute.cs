// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-03-2015
// ***********************************************************************
// <copyright file="CanonicalizeUrlFilterAttribute.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Filter for canonicalize URL and Hostname.</summary>
// ***********************************************************************

using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BI.Interface.Infrastructure.Filters
{
    /// <summary>
    /// Filter for lower case URL when receive GET request.
    /// Do not lower case the query string.
    /// </summary>
    /// <seealso href="http://stackoverflow.com/questions/14048338/create-filter-to-ensure-lowercase-urls">Create filter to ensure lowercase urls</seealso>
    /// <seealso href="http://stackoverflow.com/questions/878578/how-can-i-have-lowercase-routes-in-asp-net-mvc">How can I have lowercase routes in ASP.NET MVC?</seealso>
    public class LowerCaseFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            if (request.Url == null) return;
            var url = (request.Url.Scheme + "://" + request.Url.Authority + request.Url.AbsolutePath);
            if (request.HttpMethod != "GET" || !Regex.Match(url, @"[A-Z]").Success) return;
            var newUrl = url.ToLower(CultureInfo.CurrentCulture) + HttpContext.Current.Request.Url.Query;
            filterContext.Result = new RedirectResult(newUrl, true);
        }
    }

    /// <summary>
    /// Filter for remove trailing slash (/) behind URL.
    /// </summary>
    public class RemoveTrailingSlashFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            if (request.Url == null) return;
            var url = (request.Url.Scheme + "://" + request.Url.Authority + request.Url.AbsolutePath);
            if ((!url.EndsWith("/") && !url.EndsWith("\\")) || request.Url.AbsolutePath.Length <= 1) return;
            var newUrl = url.Substring(0, url.Length - 1);
            filterContext.Result = new RedirectResult(newUrl, true);
        }
    }

    /// <summary>
    /// Filter for remove www in front of URL.
    /// </summary>
    /// <seealso cref="http://stackoverflow.com/questions/4882508/how-to-remove-the-www-prefix-in-asp-net-mvc">How to remove the www. prefix in ASP.NET MVC</seealso>
    public class CanonicalizeHostnameFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var regex = new Regex("(http|https)://www\\.", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            var request = filterContext.HttpContext.Request;
            var url = request.Url;
            if (url != null && !regex.IsMatch(url.ToString())) return;
            var newUrl = regex.Replace(url.ToString(), String.Format("{0}://", url.Scheme));
            filterContext.Result = new RedirectResult(newUrl, true);
        }
    }
}