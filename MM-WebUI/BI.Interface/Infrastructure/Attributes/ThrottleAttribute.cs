// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-03-2015
// ***********************************************************************
// <copyright file="ThrottleAttribute.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Attribute for decorates any MVC route that needs to have client requests limited by time.</summary>
// ***********************************************************************

using System;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace BI.Interface.Infrastructure.Attributes
{
    /// <summary>
    /// Attribute for decorates any MVC route that needs to have client requests limited by time.
    /// Work when deploy in single machine only.
    /// </summary>
    /// <remarks>Uses the current System.Web.Caching.Cache to store each client request to the decorated route.</remarks>
    /// <seealso href="http://stackoverflow.com/questions/33969/best-way-to-implement-request-throttling-in-asp-net-mvc">Best way to implement request throttling in ASP.NET MVC</seealso>
    /// <example>
    /// [Throttle(Name="TestThrottle", Message = "You must wait {n} seconds before accessing this url again.", Seconds = 5)]
    /// public ActionResult TestThrottle()
    /// {
    ///     return Content("TestThrottle executed");
    /// }
    /// </example>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ThrottleAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// A unique name for this Throttle.
        /// </summary>
        /// <remarks>
        /// We'll be inserting a Cache record based on this name and client IP, e.g. "Name-192.168.0.1"
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// The number of seconds clients must wait before executing this decorated route again.
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// A text message that will be sent to the client upon throttling.  You can include the token {n} to
        /// show this.Seconds in the message, e.g. "Wait {n} seconds before trying again".
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Called by the ASP.NET MVC framework after the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var key = string.Concat(Name, "-", filterContext.HttpContext.Request.UserHostAddress);
            var allowExecute = false;

            if (HttpRuntime.Cache[key] == null)
            {
                HttpRuntime.Cache.Add(key,
                    true, // is this the smallest data we can have?
                    null, // no dependencies
                    DateTime.Now.AddSeconds(Seconds), // absolute expiration
                    Cache.NoSlidingExpiration,
                    CacheItemPriority.Low,
                    null); // no callback

                allowExecute = true;
            }

            if (allowExecute) return;
            if (String.IsNullOrEmpty(Message))
                Message = "You may only perform this action every {n} seconds.";

            filterContext.Result = new ContentResult { Content = Message.Replace("{n}", Seconds.ToString()) };
            // see 409 - http://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
        }
    }
}