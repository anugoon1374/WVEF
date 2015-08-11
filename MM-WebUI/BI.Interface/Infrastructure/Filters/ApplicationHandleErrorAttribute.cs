// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-03-2015
// ***********************************************************************
// <copyright file="ApplicationHandleErrorAttribute.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Filter for application handling error exception.</summary>
// ***********************************************************************

using System.Web.Mvc;

namespace BI.Interface.Infrastructure.Filters
{
    /// <summary>
    /// Filter for application handling error exception.
    /// </summary>
    /// <remarks>Use filter and Application_Error() will cover all error happens in application.</remarks>
    /// <seealso href="http://www.codeproject.com/Articles/850062/Exception-handling-in-ASP-NET-MVC-methods-explaine">ASP.NET MVC Error Exception</seealso>
    public class ApplicationHandleErrorAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// Called when an exception occurs.
        /// </summary>
        /// <param name="filterContext">The action-filter context.</param>
        public override void OnException(ExceptionContext filterContext)
        {
            var ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "error",
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}