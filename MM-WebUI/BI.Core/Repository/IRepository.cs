// ***********************************************************************
// Assembly         : BI.Core
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 05-22-2015
// ***********************************************************************
// <copyright file="IRepository.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The interface for data repository.</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BI.Core.Repository
{
    /// <summary>
    /// Represents the interface for data repository.
    /// </summary>
    /// <typeparam name="T">Model class type.</typeparam>
    public interface IRepository<T>
    {
        #region CREATE

        /// <summary>
        /// Creates/Inserts the new item/object into repository.
        /// </summary>
        /// <param name="o">The new item.</param>
        /// <returns>Newly created/inserted item.</returns>
        T Insert(T o);

        #endregion CREATE

        #region UPDATE

        /// <summary>
        /// Saves all change to repository.
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
        /// Deletes the specified item/object in repository.
        /// </summary>
        /// <param name="o">The specified item/object.</param>
        void Delete(T o);

        /// <summary>
        /// Restores the specified deleted item/object in repository.
        /// </summary>
        /// <param name="o">The specified item/object.</param>
        void Restore(T o);

        #endregion DELETE & RESTORE

        #region EXTRA COMMANDS

        /// <summary>
        /// Creates/Inserts the collection of new item/object into repository.
        /// </summary>
        /// <param name="o">The collection of new item.</param>
        /// <returns>Newly created/inserted item.</returns>
        void BulkInsert(ICollection<T> o);

        /// <summary>
        /// Executes the store procedure (Microsoft SQL Server only).
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="parameters">The parameters want to pass to store procedure.</param>
        /// <returns>The item collection (IEnumerable).</returns>
        /// <remarks>
        /// <para>This method support return with single result set only.</para>
        /// </remarks>
        /// <seealso href="http://stackoverflow.com/questions/20901419/how-to-call-stored-procedure-in-entity-framework-6-code-first">How to call stored procedure from Entity Framework</seealso>
        IEnumerable<T> ExecuteStoreProcedure(string storeProcedureName, params object[] parameters);

        #endregion EXTRA COMMANDS
    }
}