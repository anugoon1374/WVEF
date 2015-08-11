// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-02-2015
// ***********************************************************************
// <copyright file="WebApiConfig.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>ASP.NET WebAPI configuration.</summary>
// ***********************************************************************
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace BI.Interface
{
    /// <summary>
    /// ASP.NET WebAPI Configuration.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the WebAPI specified configuration.
        /// </summary>
        /// <param name="config">The HTTP configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MapHttpAttributeRoutes();

            // Enable Elmah for WebAPI
            // PM> Install-Package Elmah.Contrib.WebApi
            //config.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());

            #region REMOTE PROCEDURE CALL (RPC)

            // NOTE: RPC can be call using both GET/POST protocol, but default is POST because it is more secure.

            // GET /{controller}/api/{action}
            config.Routes.MapHttpRoute(
                name: "Web API RPC Get",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { },
                constraints: new { action = @"[A-Za-z]+", httpMethod = new HttpMethodConstraint("GET") }
                );

            // POST /{controller}/api/{action}
            config.Routes.MapHttpRoute(
                name: "Web API RPC Post",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { },
                constraints: new { action = @"[A-Za-z]+", httpMethod = new HttpMethodConstraint("POST") }
                );

            #endregion REMOTE PROCEDURE CALL (RPC)

            #region RESOURCE / DATA ACCESS

            // NOTE: Do not change default route. These path is already tested and secured.
            // GET /{controller}/api/{id}
            config.Routes.MapHttpRoute(
                name: "Web API Get Single Resource",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { action = "Get" },
                constraints: new { httpMethod = new HttpMethodConstraint("GET"), id = @"\d+" }
                );

            // GET /{controller}/api
            config.Routes.MapHttpRoute(
                name: "Web API Get All Resource",
                routeTemplate: "api/{controller}",
                defaults: new { action = "GetAll" },
                constraints: new { httpMethod = new HttpMethodConstraint("GET"), id = "" }
                );

            // PUT /{controller}/api
            config.Routes.MapHttpRoute(
                name: "Web API Update Resource",
                routeTemplate: "{controller}/api",
                defaults: new { action = "Put" },
                constraints: new { httpMethod = new HttpMethodConstraint("PUT") }
                );

            // POST /{controller}/api
            config.Routes.MapHttpRoute(
                name: "Web API Create Resource",
                routeTemplate: "api/{controller}",
                defaults: new { action = "Post" },
                constraints: new { httpMethod = new HttpMethodConstraint("POST") }
                );

            // DELETE /{controller}/api/{id}
            config.Routes.MapHttpRoute(
                name: "Web API Delete Single Resource",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { action = "Delete" },
                constraints: new { httpMethod = new HttpMethodConstraint("DELETE"), id = @"\d+" }
                );

            // POST /{controller}/api/{id}
            config.Routes.MapHttpRoute(
                name: "Web API Restore Single Resource",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { action = "Restore" },
                constraints: new { httpMethod = new HttpMethodConstraint("POST"), id = @"\d+" }
                );

            #endregion RESOURCE / DATA ACCESS

            // Change default output format from XML to JSON
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}