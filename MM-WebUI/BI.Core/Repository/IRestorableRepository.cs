// ***********************************************************************
// Assembly         : BI.Core
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-30-2015
// ***********************************************************************
// <copyright file="IRestorableRepository.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The interface for data repository extension to make data restorable.</summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BI.Core.Repository
{
    /// <summary>
    /// Represents the interface for data repository extension to make data restorable.
    /// </summary>
    /// <typeparam name="T">Model class type.</typeparam>
    public interface IRestorableRepository<T>
    {
        /// <summary>
        /// Gets the specified items/objects by certain criteria from repository.
        /// </summary>
        /// <param name="predicate">The search criteria expression.</param>
        /// <param name="showDeleted">if set to <c>true</c> [return deleted items].</param>
        /// <returns>The item collection (IQueryable).</returns>
        IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false);

        /// <summary>
        /// Gets all items/objects from repository.
        /// </summary>
        /// <returns>The item collection (IQueryable).</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Restores the specified deleted item/object in repository.
        /// </summary>
        /// <param name="o">The specified item/object.</param>
        void Restore(T o);
    }
}