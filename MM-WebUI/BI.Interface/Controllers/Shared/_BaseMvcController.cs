// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-20-2015
// ***********************************************************************
// <copyright file="_BaseMvcController.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Base controller for all MVC controller.</summary>
// ***********************************************************************

using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Microsoft.Web.Mvc;

namespace BI.Interface.Controllers
{
    /// <summary>
    /// Base controller for all MVC controller.
    /// </summary>
    public abstract class BaseMvcController : Controller
    {
        /// <summary>
        /// Microsoft.Web.Mvc Future redirects to action.
        /// </summary>
        /// <typeparam name="TController">The type of the t controller.</typeparam>
        /// <param name="action">The action.</param>
        /// <returns>ActionResult.</returns>
        /// <remarks>
        /// This method allow us not need to use "this" in when return Strong-Type View.
        /// </remarks>
        protected ActionResult RedirectToAction<TController>(
            Expression<Action<TController>> action)
            where TController : Controller
        {
            return ControllerExtensions.RedirectToAction(this, action);
        }


        // TODO : Add something common in every controller here
    }
}