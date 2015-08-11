// ***********************************************************************
// Assembly         : BI.Auxiliary.Web
// Author           : Anugoon Leelaphattarakij
// Created          : 04-27-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-27-2015
// ***********************************************************************
// <copyright file="HttpContextFactory.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Factory pattern for HttpContext</summary>
// ***********************************************************************
using System;
using System.Web;

namespace BI.Interface
{
    /// <summary>
    /// <para>Factory pattern for HttpContext</para>
    /// <para>This make HttpContext mockable in unit test</para>
    /// </summary>
    /// <example>
    /// <para>Production: Do not need to setup anything</para>
    /// <para>Unit test : HttpContextFactory.SetCurrentContext(BiTestHelpers.GetMockedHttpContext());</para>
    /// </example>
    public class HttpContextFactory
    {
        /// <summary>
        /// The HttpContext
        /// </summary>
        private static HttpContextBase _httpContext;

        /// <summary>
        /// Gets the HttpContext (if available).
        /// </summary>
        /// <value>The HttpContext.</value>
        /// <exception cref="System.InvalidOperationException">HttpContext not available</exception>
        public static HttpContextBase GetHttpContext
        {
            get
            {
                if (_httpContext != null)
                    return _httpContext;

                if (HttpContext.Current == null)
                    throw new InvalidOperationException("HttpContext not available");

                return new HttpContextWrapper(HttpContext.Current);
            }
        }

        /// <summary>
        /// Sets the HttpContext.
        /// </summary>
        /// <param name="context">The HttpContext.</param>
        public static void SetCurrentContext(HttpContextBase context)
        {
            _httpContext = context;
        }
    }
}