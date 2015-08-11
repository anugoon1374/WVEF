// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-02-2015
// ***********************************************************************
// <copyright file="MvcControllerFactory.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The factory class for construct MVC Controller.</summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace BI.Interface
{
    /// <summary>
    /// The factory class for construct MVC Controller.
    /// Factory will auto resolve dependencies MVC Controller class require.
    /// </summary>
    public class MvcControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// The dependency container
        /// </summary>
        private readonly IWindsorContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="MvcControllerFactory" /> class.
        /// </summary>
        /// <param name="container">The dependency container.</param>
        public MvcControllerFactory(IWindsorContainer container)
        {
            _container = container;

            #region Register MVC-base class in this project

            var controllerTypes =
                from t in Assembly.GetExecutingAssembly().GetTypes()
                where typeof (IController).IsAssignableFrom(t)
                select t;

            foreach (var t in controllerTypes)
            {
                try
                {
                    container.Register(Component.For(t).LifeStyle.Transient);
                }
                catch (Exception)
                {
                }
            }

        

            #endregion Register MVC-base class in this project
        }

        /// <summary>
        /// Retrieves the controller instance for the specified request context and controller type.
        /// </summary>
        /// <param name="requestContext">The context of the HTTP request, which includes the HTTP context and route data.</param>
        /// <param name="controllerType">The type of the controller.</param>
        /// <returns>The controller instance.</returns>
        /// <exception cref="HttpException">
        /// 404
        /// or
        /// 503
        /// </exception>
        /// <exception cref="System.Web.HttpException">404
        /// or
        /// 503</exception>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }

            try
            {
                return (IController)_container.Resolve(controllerType);
            }
            catch (Exception ex)
            {
                throw ex;
                //throw new HttpException(503, string.Format("The controller for path '{0}' could not be resolve.", requestContext.HttpContext.Request.Path));
            }
        }
    }
}