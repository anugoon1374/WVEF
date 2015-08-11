// ***********************************************************************
// Assembly         : BI.Core
// Author           : Anugoon Leelaphattarakij
// Created          : 08-08-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 08-10-2015
// ***********************************************************************
// <copyright file="ISmartCanvasService.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The interface/contract for Smart Canvas API service.</summary>
// ***********************************************************************
using System;
using System.Threading.Tasks;
using BI.Core.Models;

namespace BI.Core.Service
{
    /// <summary>
    /// Represents the interface for Smart Canvas API service.
    /// </summary>
    /// <remarks>Don't use. Not complete</remarks>
    public interface ISmartCanvasService
    {
        /// <summary>
        /// Gets the smart canvas card by unique identifier.
        /// </summary>
        /// <param name="uid">The unique identifier.</param>
        /// <returns>Task.</returns>
        Task GetAsync(string uid);

        /// <summary>
        /// Creates new smart canvas card 
        /// </summary>
        /// <param name="newCanvas">The new smart canvas.</param>
        /// <returns>Task.</returns>
        Task CreateAsync(SmartCanvas newCanvas);
    }
}
