// ***********************************************************************
// Assembly         : BI.Auxiliary.Web
// Author           : Anugoon Leelaphattarkij
// Created          : 04-17-2015
//
// Last Modified By : Anugoon Leelaphattarkij
// Last Modified On : 05-27-2015
// ***********************************************************************
// <copyright file="MvcHelpers.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Ready-to-Use helper for assist ASP.NET MVC development.</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace BI.Interface.Infrastructure.Helpers
{
    /// <summary>
    /// Ready-to-Use helper for assist ASP.NET MVC development.
    /// </summary>
    public static partial class MvcHelper
    {
        /// <summary>
        /// Populates the list of SelectListItem from enumerable type.
        /// </summary>
        /// <typeparam name="TEnum">Struct, IComparable, IFormattable, IConvertible based enumerable type.</typeparam>
        /// <param name="useTextOnly">if set to <c>true</c> [use enum text only].</param>
        /// <returns>List of SelectListItem.</returns>
        public static List<SelectListItem> PopulateSelectItemList<TEnum>(bool useTextOnly = true)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            if (useTextOnly)
            {
                return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(v => new SelectListItem
                {
                    Text = v.ToString(CultureInfo.CurrentCulture),
                    Value = v.ToString(CultureInfo.CurrentCulture)
                }).ToList();
            }
            else
            {
                return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(v => new SelectListItem
                {
                    Text = v.ToString(CultureInfo.CurrentCulture),
                    Value = (v.ToInt64(new CultureInfo("en-US"))).ToString()
                }).ToList();
            }
        }

        /// <summary>
        /// Renders the page view to string.
        /// Useful if want to send partial view to client with JSON.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="model">The model.</param>
        /// <param name="viewStyle">The view style.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// controller
        /// or
        /// viewName
        /// or
        /// model
        /// or
        /// viewStyle
        /// </exception>
        /// <exception cref="ArgumentNullException">controller
        /// or
        /// viewName
        /// or
        /// model
        /// or
        /// viewStyle</exception>
        /// <seealso href="http://stackoverflow.com/questions/1471066/partial-views-vs-json-or-both">Pass Partial View on JSON</seealso>
        public static string RenderViewToString(this Controller controller, string viewName, object model, string viewStyle)
        {
            // Validate input
            if (controller == null) throw new ArgumentNullException("controller");
            if (viewName == null) throw new ArgumentNullException("viewName");
            if (model == null) throw new ArgumentNullException("model");
            if (viewStyle == null) throw new ArgumentNullException("viewStyle");

            // Render to string
            using (var writer = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                controller.ViewData.Model = model;
                controller.ViewBag.ViewStyle = viewStyle;
                var viewCxt = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, writer);
                viewCxt.View.Render(viewCxt, writer);
                return writer.ToString();
            }
        }
    }
}