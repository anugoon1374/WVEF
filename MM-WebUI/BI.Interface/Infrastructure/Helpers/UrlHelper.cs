// ***********************************************************************
// Assembly         : BI.Auxiliary
// Author           : Anugoon Leelaphattarkij
// Created          : 04-17-2015
//
// Last Modified By : Anugoon Leelaphattarkij
// Last Modified On : 06-01-2015
// ***********************************************************************
// <copyright file="UrlHelper.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Extension to UrlHelper.</summary>
// ***********************************************************************

using System.Web.Mvc;
using BI.Auxiliary;
using BI.Infrastructure;

namespace BI.Interface
{
    /// <summary>
    /// Extension to UrlHelper by add following features
    /// <para>- Quick access file and folder path.</para>
    /// </summary>
    public static class UrlHelperExtension
    {
        #region ACCESS SPECIFIC PAGE OR FILE (Signup, Login, or Dashboard etc,.)

        /// <summary>
        /// Get application's root path.
        /// </summary>
        /// <param name="helper">The Url helper.</param>
        /// <returns>Application root path.</returns>
        /// <example>@Url.Root()</example>
        public static string Root(this UrlHelper helper)
        {
            return helper.Content("~/");
        }

        /// <summary>
        /// Get link to Login page.
        /// </summary>
        /// <param name="helper">The Url helper.</param>
        /// <returns>The link to Login page.</returns>
        /// <example><a href="<%= Url.Login() %>">Login</a></example>
        public static string Login(this UrlHelper helper)
        {
            return helper.RouteUrl("Login");
        }

        /// <summary>
        /// Get link to Sign up page.
        /// </summary>
        /// <param name="helper">The Url helper.</param>
        /// <returns>The link to Sign up page.</returns>
        /// <example><a href="<%= Url.SignUp() %>">SignUp</a></example>
        public static string SignUp(this UrlHelper helper)
        {
            return helper.RouteUrl("Signup");
        }

        /// <summary>
        /// Get link to Dashboard page.
        /// </summary>
        /// <param name="helper">The Url helper.</param>
        /// <returns>The link to signs up page.</returns>
        /// <example>
        /// <para><a href="<%= Url.Dashboard() %>">Dashboard</a></para>
        /// <para>Redirect(Url.Dashboard())</para>
        /// </example>
        public static string Dashboard(this UrlHelper helper)
        {
            return helper.RouteUrl("Dashboard");
        }

        /// <summary>
        /// Get application's No Icon image for show when no picture to display.
        /// </summary>
        /// <param name="helper">The Url helper.</param>
        /// <returns>Application's No Icon image</returns>
        /// <example>@Url.NoIcon()</example>
        public static string NoIcon(this UrlHelper helper)
        {
            return Image(helper, "noicon.png");
        }

        #endregion ACCESS SPECIFIC PAGE OR FILE (Signup, Login, or Dashboard etc,.)

        #region ACCESS ASSET FOLDERS

        /// <summary>
        /// The image folder path
        /// </summary>
        private static readonly string imagePath = AppSettings.Get("Asset.ImagePath", "~/assets/images/");

        /// <summary>
        /// The video folder path
        /// </summary>
        private static readonly string videoPath = AppSettings.Get("Asset.VideoPath", "~/assets/videos/");

        /// <summary>
        /// The script folder path
        /// </summary>
        private static readonly string scriptPath = AppSettings.Get("Asset.ScriptPath", "~/assets/images/");

        /// <summary>
        /// The styles sheet folder path
        /// </summary>
        private static readonly string stylesSheetPath = AppSettings.Get("Asset.StyleSheetPath", "~/assets/stylesheets/");

        /// <summary>
        /// Get application's image file path.
        /// </summary>
        /// <param name="helper">The Url helper.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Application's image path.</returns>
        /// <example>@Url.Image("filename.jpg")</example>
        public static string Image(this UrlHelper helper, string fileName)
        {
            return helper.Content((imagePath + "{0}").FormatWith(fileName));
        }

        /// <summary>
        /// Get application's video file path.
        /// </summary>
        /// <param name="helper">The Url helper.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Application's video path.</returns>
        /// <example>@Url.Video("filename.mp4")</example>
        public static string Video(this UrlHelper helper, string fileName)
        {
            return helper.Content((videoPath + "{0}").FormatWith(fileName));
        }

        /// <summary>
        /// Get application's script file path.
        /// </summary>
        /// <param name="helper">The Url helper.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Application's script path.</returns>
        /// <example>@Url.Script("filename.js")</example>
        public static string Script(this UrlHelper helper, string fileName)
        {
            return helper.Content((scriptPath + "{0}").FormatWith(fileName));
        }

        /// <summary>
        /// Get application's stylesheet file path.
        /// </summary>
        /// <param name="helper">The Url helper.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Application's stylesheets path.</returns>
        /// <example>@Url.Stylesheet("filename.css")</example>
        public static string Stylesheet(this UrlHelper helper, string fileName)
        {
            return helper.Content((stylesSheetPath + "{0}").FormatWith(fileName));
        }

        #endregion ACCESS ASSET FOLDERS
    }
}