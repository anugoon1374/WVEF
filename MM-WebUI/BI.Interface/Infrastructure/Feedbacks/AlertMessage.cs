// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-03-2015
// ***********************************************************************
// <copyright file="AlertMessage.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Data model represents the Alert Message.</summary>
// ***********************************************************************

namespace BI.Interface.Infrastructure.Feedbacks
{
    /// <summary>
    /// Data model represents the Alert Message.
    /// </summary>
    public class AlertMessage
    {
        /// <summary>
        /// Gets or sets the alert message CSS class.
        /// </summary>
        /// <value>The alert message CSS class.</value>
        public string CssClass { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlertMessage"/> class.
        /// </summary>
        /// <param name="cssClass">The alert message CSS class.</param>
        /// <param name="message">The message.</param>
        public AlertMessage(string cssClass, string message)
        {
            CssClass = cssClass;
            Message = message;
        }
    }
}