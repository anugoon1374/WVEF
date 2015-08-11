// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 06-02-2015
// ***********************************************************************
// <copyright file="DependencyInstaller.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>ASP.NET dependency injection configuration.</summary>
// ***********************************************************************
using System.Web.Http.Controllers;
using System.Web.Mvc;
using BI.Infrastructure;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BI.Interface
{
    /// <summary>
    /// ASP.NET dependency injection configuration.
    /// </summary>
    public class DependencyInstaller
    {
        /// <summary>
        /// Registers the classes and types in current application/assembly.
        /// </summary>
        public static void RegisterApplication()
        {
            IoC.Container.Install(
                new ApiControllerInstaller(),
                new MvcControllerInstaller()
            );
        }

        /// <summary>
        /// Registers the dependency from other assemblies.
        /// </summary>
        public static void RegisterAssemblies()
        {
            var dependencies = AppSettings.Get("Dependency.AssemblyName", "");
            foreach (var dependency in dependencies.Split(','))
            {
                // Always use transient lifestyle because Castle Windsor not support resolve during application_start()
                Di.RegisterAllFromAssemblies(dependency, Di.LifeStyle.Transient);
            }
        }

        /// <summary>
        /// Registers the dependency types.
        /// </summary>
        public static void RegisterTypes()
        {
            // TODO : Add additional dependency types want to register here
            //Di.Register(typeof(IHasher), typeof(Hasher));
        }
    }

    /// <summary>
    /// Register/Inject API Controller.
    /// </summary>
    public class ApiControllerInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Installs the specified container based on IHttpController.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient());
        }
    }

    /// <summary>
    /// Register/Inject MVC Controller.
    /// </summary>
    public class MvcControllerInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Installs the specified container based on IController.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
        }
    }
}