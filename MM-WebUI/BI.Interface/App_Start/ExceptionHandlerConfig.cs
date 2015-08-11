// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 05-31-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-02-2015
// ***********************************************************************
// <copyright file="ExceptionHandlerConfig.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>ASP.NET exception handling configuration.</summary>
// ***********************************************************************

using System;

namespace BI.Interface
{
    /// <summary>
    /// ASP.NET exception handling configuration.
    /// </summary>
    public class ExceptionHandlerConfig
    {
        /// <summary>
        /// Handlings the global-level application error.
        /// </summary>
        public static void HandlingApplicationError(Exception exception)
        {
            // Send notification to administrator
            //MailHelper.SendMailMessageToAdmin(exception);

            //if (exception == null)
            //    return;
            //var mail = new MailMessage { From = new MailAddress("automated@contoso.com") };
            //mail.To.Add(new MailAddress("administrator@contoso.com"));
            //mail.Subject = "Site Error at " + DateTime.Now;
            //mail.Body = "Error Description: " + exception.Message;
            //var server = new SmtpClient { Host = "your.smtp.server" };
            //server.Send(mail);
        }
    }
}