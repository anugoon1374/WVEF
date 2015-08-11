// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-02-2015
// ***********************************************************************
// <copyright file="RouteConfig.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>ASP.NET routing configuration.</summary>
// ***********************************************************************
using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;
using System.Web.Routing;

namespace BI.Interface
{
    /// <summary>
    /// ASP.NET Routing Configuration.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RouteConfig
    {
        /// <summary>
        /// Registers the MVC routes.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        /// <seealso href="http://weblogs.asp.net/rashid/asp-net-mvc-best-practices-part-2#routing">Routing consideration</seealso>
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Canonicalize URLs
            routes.LowercaseUrls = true;
            routes.AppendTrailingSlash = false;

            #region BLACK LIST ROUTES

            // Ignore axd files such as assest, image, sitemap etc
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Turns off the unnecessary file exists check
            //routes.RouteExistingFiles = true;

            // Ignore text, html, files.
            routes.IgnoreRoute("{file}.txt");
            routes.IgnoreRoute("{file}.htm");
            routes.IgnoreRoute("{file}.html");

            // Ignore the assets directory which contains images, js, css & html
            routes.IgnoreRoute("assets/{*pathInfo}");

            // Ignore the error directory which contains error pages
            routes.IgnoreRoute("Error/{*pathInfo}");

            //Exclude favicon (google toolbar request gif file as fav icon which is weird)
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.([iI][cC][oO]|[gG][iI][fF])(/.*)?" });

            #endregion BLACK LIST ROUTES

            #region WHITE LIST ROUTES

            // Profile
            //routes.MapRoute("SignUp", "SignUp", new { controller = "Membership", action = "SignUp" });
            //routes.MapRoute("SignIn", "SignIn", new { controller = "Membership", action = "SignIn" });
            //routes.MapRoute("ForgotPassword", "ForgotPassword", new { controller = "Membership", action = "ForgotPassword" });
            //routes.MapRoute("SignOut", "SignOut", new { controller = "Membership", action = "SignOut" });
            //routes.MapRoute("Profile", "Profile", new { controller = "Membership", action = "Profile" });
            //routes.MapRoute("ChangePassword", "ChangePassword", new { controller = "Membership", action = "ChangePassword" });

            // Landing page
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Business", action = "Index", id = UrlParameter.Optional }
            );

            #endregion WHITE LIST ROUTES
        }
    }
}