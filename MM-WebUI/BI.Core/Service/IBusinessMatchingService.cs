// ***********************************************************************
// Assembly         : BI.Core
// Author           : Anugoon Leelaphattarakij
// Created          : 08-09-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 08-10-2015
// ***********************************************************************
// <copyright file="IBusinessMatchingService.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The interface/contract for Business Matching service.</summary>
// ***********************************************************************
using System;
using System.Threading.Tasks;
using BI.Core.Models;

namespace BI.Core.Service
{
    /// <summary>
    /// Represents the interface for Business Matching service.
    /// </summary>
    public interface IBusinessMatchingService
    {
        Task GetBuyerAsync(string query);
        Task GetSellerAsync(string query);
    }
}
