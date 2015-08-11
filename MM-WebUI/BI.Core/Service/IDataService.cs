// ***********************************************************************
// Assembly         : BI.Core
// Author           : Anugoon Leelaphattarakij
// Created          : 04-17-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-30-2015
// ***********************************************************************
// <copyright file="IDataService.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The interface/contract for data access service.</summary>
// ***********************************************************************

using System;
using System.Linq;
using System.Linq.Expressions;
using BI.Core.Models;

namespace BI.Core.Service
{
    /// <summary>
    /// Represents the interface for data access service.
    /// </summary>
    /// <typeparam name="T">Entity based class type.</typeparam>
    public interface IDataService<T> where T : Entity, new()
    {
        #region CREATE

        /// <summary>
        /// Creates/Inserts the new item/object into repository.
        /// </summary>
        /// <param name="item">The new item.</param>
        /// <returns>Unique identifier of the newly created/inserted item (System.UInt64).</returns>
        ulong Insert(T item);

        #endregion CREATE

        #region UPDATE

        /// <summary>
        /// Saves repository.
        /// </summary>
        void Save();

        #endregion UPDATE

        #region READ

        /// <summary>
        /// Gets the specified item/object by unique identifier from repository.
        /// </summary>
        /// <param name="uid">The item's unique identifier.</param>
        /// <returns>The specified item.</returns>
        T Get(ulong uid);

        /// <summary>
        /// Gets all items/objects from repository.
        /// </summary>
        /// <returns>The item collection (IQueryable).</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Gets the specified items/objects by certain criteria from repository.
        /// </summary>
        /// <param name="predicate">The search criteria expression.</param>
        /// <param name="showDeleted">if set to <c>true</c> [return deleted items].</param>
        /// <returns>The item collection (IQueryable).</returns>
        IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false);

        #endregion READ

        #region DELETE & RESTORE

        /// <summary>
        /// Deletes the specified item in repository.
        /// </summary>
        /// <param name="uid">The item's unique identifier.</param>
        void Delete(ulong uid);

        /// <summary>
        /// Restores the specified deleted item in repository.
        /// This method will do nothing if object is un-restorable entity.
        /// </summary>
        /// <param name="uid">The item's unique identifier.</param>
        void Restore(ulong uid);

        #endregion DELETE & RESTORE
    }
}