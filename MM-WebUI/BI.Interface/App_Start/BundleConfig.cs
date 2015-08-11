// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-02-2015
// ***********************************************************************
// <copyright file="BundleConfig.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Javascript and CSS bundle configuration.</summary>
// ***********************************************************************
using System.Web.Optimization;

namespace BI.Interface
{
    /// <summary>
    /// Javascript and CSS bundle configuration.
    /// Use only one bundles.
    /// </summary>
    /// <seealso href="http://go.microsoft.com/fwlink/?LinkId=301862">ASP.Net Bundles</seealso>
    public class BundleConfig
    {
        /// <summary>
        /// Registers the default ASP.Net MVC bundles.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        /// <remarks>
        /// Use CDN if this application is host on internet environment.
        /// </remarks>
        public static void RegisterBundles(BundleCollection bundles)
        {
            // TODO : Add common bundle here.
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }

        /// <summary>
        /// Registers the bundles for dashboard.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        public static void RegisterBundlesForDashboard(BundleCollection bundles)
        {
            // TODO : Add bundle for dashboard here.
        }

        /// <summary>
        /// Registers the bundles for front end.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        public static void RegisterBundlesForFrontEnd(BundleCollection bundles)
        {
            // TODO : Add bundle for front-end here.
            bundles.Add(new StyleBundle("~/Content/css-card").Include(
                      "~/Content/bootplus-custom.css",
                      "~/Content/bootplus-responsive.css"
                     ));
        }
    }
}