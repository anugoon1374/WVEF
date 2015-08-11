// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-03-2015
// ***********************************************************************
// <copyright file="AlertMessageDecoratorResult.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Action result decorator for adding alert message.</summary>
// ***********************************************************************

using System.Web.Mvc;

namespace BI.Interface.Infrastructure.Feedbacks
{
    /// <summary>
    /// Action result decorator for adding Alert Message.
    /// </summary>
    /// <remarks>
    /// This decorator standardize alert message and make it easier for developer to use.
    /// </remarks>
    public class AlertMessageDecoratorResult : ActionResult
    {
        /// <summary>
        /// Gets or sets the inner action result.
        /// </summary>
        /// <value>The inner action result.</value>
        public ActionResult InnerResult { get; set; }

        /// <summary>
        /// Gets or sets the notification CSS class.
        /// </summary>
        /// <value>The notification CSS class.</value>
        public string CssClass { get; set; }

        /// <summary>
        /// Gets or sets the notification message.
        /// </summary>
        /// <value>The notification message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlertMessageDecoratorResult"/> class.
        /// </summary>
        /// <param name="innerResult">The inner result.</param>
        /// <param name="cssClass">The CSS class.</param>
        /// <param name="message">The message.</param>
        public AlertMessageDecoratorResult(ActionResult innerResult, string cssClass, string message)
        {
            InnerResult = innerResult;
            CssClass = cssClass;
            Message = message;
        }

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.
        /// </summary>
        /// <param name="context">The context in which the result is executed. The context information includes the controller, HTTP content, request context, and route data.</param>
        public override void ExecuteResult(ControllerContext context)
        {
            var alerts = context.Controller.TempData.GetAlertMessages();
            alerts.Add(new AlertMessage(CssClass, Message));
            InnerResult.ExecuteResult(context);
        }
    }
}