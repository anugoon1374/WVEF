// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 05-06-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 05-06-2015
// ***********************************************************************
// <copyright file="Global.asax.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Main class for this web application.</summary>
// ***********************************************************************

using System;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BI.Infrastructure;
using BI.Interface.Helpers;

namespace BI.Interface
{
    /// <summary>
    /// Web application's main class
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiApplication"/> class.
        /// </summary>
        /// <remarks>Inject all required dependencies.</remarks>
        public WebApiApplication()
        {
            DependencyInstaller.RegisterApplication();
            DependencyInstaller.RegisterAssemblies();
            DependencyInstaller.RegisterTypes();
        }

        /// <summary>
        /// Starting application.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleConfig.RegisterBundlesForDashboard(BundleTable.Bundles);
            BundleConfig.RegisterBundlesForFrontEnd(BundleTable.Bundles);

            // Setup IoC during runtime for WebAPI Controller
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new ApiControllerFactory(IoC.Container));

            // Setup IoC during runtime for MVC Controller
            ControllerBuilder.Current.SetControllerFactory(new MvcControllerFactory(IoC.Container));

            // Register all of the web workers.
            WebWorkerConfig.RegisterWebWorker();
        }

        /// <summary>
        /// Quitting application, release all resources.
        /// </summary>
        protected void Application_End()
        {
            Dispose();
        }

        /// <summary>
        /// Handles the Error event of the Application control.
        /// This is global error handling which will show when everything was failed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            // Get error
            Exception exception = Server.GetLastError();
            if (exception == null) return;

            // Handling error
            ExceptionHandlerConfig.HandlingApplicationError(exception);
            Response.Write(exception);

            // Clear error
            Server.ClearError();

            // Redirect to error page
            //Response.Redirect("/error");
        }
    }
}
