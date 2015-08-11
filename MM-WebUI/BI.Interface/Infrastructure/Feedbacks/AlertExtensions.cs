// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-03-2015
// ***********************************************************************
// <copyright file="AlertExtensions.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Extensions for access (set and get) Alert Messages in TempData.</summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Web.Mvc;

namespace BI.Interface.Infrastructure.Feedbacks
{
    /// <summary>
    /// Extensions for access (set and get) Alert Messages in TempData.
    /// </summary>
    public static class AlertExtensions
    {
        /// <summary>
        /// The key for access temp data that contain Alert Messages.
        /// </summary>
        private const string Alerts = "_Alerts";

        /// <summary>
        /// Gets the Alert Messages.
        /// </summary>
        /// <param name="tempData">The ASP.Net MVC TempData.</param>
        /// <returns>List of Alert Message.</returns>
        public static List<AlertMessage> GetAlertMessages(this TempDataDictionary tempData)
        {
            if (!tempData.ContainsKey(Alerts))
            {
                tempData[Alerts] = new List<AlertMessage>();
            }
            return (List<AlertMessage>)tempData[Alerts];
        }

        /// <summary>
        /// Add success alert message to the action result.
        /// </summary>
        /// <param name="result">The action result.</param>
        /// <param name="message">The message.</param>
        /// <returns>ActionResult.</returns>
        public static ActionResult WithSuccessAlertMessage(this ActionResult result, string message)
        {
            return new AlertMessageDecoratorResult(result, "alert-success", message);
        }

        /// <summary>
        /// Add information alert message to the action result.
        /// </summary>
        /// <param name="result">The action result.</param>
        /// <param name="message">The message.</param>
        /// <returns>ActionResult.</returns>
        public static ActionResult WithInfoAlertMessage(this ActionResult result, string message)
        {
            return new AlertMessageDecoratorResult(result, "alert-info", message);
        }

        /// <summary>
        /// Add warning alert message to the action result.
        /// </summary>
        /// <param name="result">The action result.</param>
        /// <param name="message">The message.</param>
        /// <returns>ActionResult.</returns>
        public static ActionResult WithWarningAlertMessage(this ActionResult result, string message)
        {
            return new AlertMessageDecoratorResult(result, "alert-warning", message);
        }

        /// <summary>
        /// Add error alert message to the action result.
        /// </summary>
        /// <param name="result">The action result.</param>
        /// <param name="message">The message.</param>
        /// <returns>ActionResult.</returns>
        public static ActionResult WithErrorAlertMessage(this ActionResult result, string message)
        {
            return new AlertMessageDecoratorResult(result, "alert-danger", message);
        }
    }
}