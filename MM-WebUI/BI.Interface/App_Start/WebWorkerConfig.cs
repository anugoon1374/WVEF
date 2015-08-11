// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-27-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-02-2015
// ***********************************************************************
// <copyright file="WebWorkerConfig.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>ASP.NET for web worker configuration.</summary>
// ***********************************************************************
using System;

namespace BI.Interface
{
    /// <summary>
    /// ASP.NET for web worker configuration.
    /// </summary>
    public class WebWorkerConfig
    {
        /// <summary>
        /// Registers the web workers for automate work.
        /// </summary>
        public static void RegisterWebWorker()
        {
            // TODO : Add automate worker here
            //Worker.SetupSimpleWorker(WebWorker, 60 * 1000);
        }

        /// <summary>
        /// Web worker for automation work.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        protected static void WebWorker(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                // TODO : Add automate task here
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}