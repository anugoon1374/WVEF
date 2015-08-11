// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-02-2015
// ***********************************************************************
// <copyright file="ApiControllerFactory.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Factory class for WebAPI Controller.</summary>
// ***********************************************************************
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace BI.Interface
{
    /// <summary>
    /// The factory class for construct WebAPI Controller.
    /// Factory will auto resolve dependencies API Controller class require.
    /// </summary>
    /// <remarks>Searching for this on Internet, use "WindsorCompositionRoot" term.</remarks>
    public class ApiControllerFactory : IHttpControllerActivator
    {
        /// <summary>
        /// The dependency container.
        /// </summary>
        private readonly IWindsorContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiControllerFactory" /> class.
        /// </summary>
        /// <param name="container">The dependency container.</param>
        /// <exception cref="HttpResponseException"></exception>
        /// <exception cref="System.Web.Http.HttpResponseException"></exception>
        public ApiControllerFactory(IWindsorContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Resolve dependency when initiate API Controller object.
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <param name="controllerDescriptor">The controller descriptor.</param>
        /// <param name="controllerType">Type of the controller.</param>
        /// <returns>IHttpController.</returns>
        /// <exception cref="HttpResponseException"></exception>
        /// <exception cref="System.Web.Http.HttpResponseException">503</exception>
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            try
            {
                var controller = (IHttpController)_container.Resolve(controllerType);
                request.RegisterForDispose(new Release(() => _container.Release(controller)));
                return controller;
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new ObjectContent<HttpError>(new HttpError(string.Format("The controller for path '{0}' could not be resolve.", request.RequestUri)), new JsonMediaTypeFormatter(), "application/json"),
                    ReasonPhrase = "Internal Server Error : Cannot Resolve Dependency"
                };
                throw new HttpResponseException(resp);
            }
        }

        /// <summary>
        /// Release/Dispose API Controller.
        /// </summary>
        private class Release : IDisposable
        {
            /// <summary>
            /// The release
            /// </summary>
            private readonly Action _release;

            /// <summary>
            /// Initializes a new instance of the <see cref="Release" /> class.
            /// </summary>
            /// <param name="release">The release.</param>
            public Release(Action release)
            {
                _release = release;
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                _release();
            }
        }
    }
}