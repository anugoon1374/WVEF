// ***********************************************************************
// Assembly         : BI.Core
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 05-22-2015
// ***********************************************************************
// <copyright file="IUniversalRepository.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The interface for universal data repository.</summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Linq;
using BI.Core.Models;

namespace BI.Core.Repository
{
    /// <summary>
    /// Represents the interface for universal data repository (CRUD).
    /// </summary>
    public interface IUniversalRepository
    {
        #region CREATE

        /// <summary>
        /// Creates/Inserts the new item/object into repository.
        /// </summary>
        /// <typeparam name="T">Entity based class type.</typeparam>
        /// <param name="o">The new item.</param>
        /// <returns>Newly created/inserted item.</returns>
        T Insert<T>(T o) where T : Entity, new();

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
        /// <typeparam name="T">Entity based class type.</typeparam>
        /// <param name="uid">The item's unique identifier.</param>
        /// <returns>The specified item.</returns>
        T Get<T>(int uid) where T : Entity;

        /// <summary>
        /// Gets all items/objects from repository.
        /// </summary>
        /// <typeparam name="T">Entity based class type.</typeparam>
        /// <returns>The item collection (IQueryable).</returns>
        IQueryable<T> GetAll<T>() where T : Entity;

        #endregion READ

        #region EXTRA COMMANDS

        /// <summary>
        /// Creates/Inserts the collection of new item/object into repository.
        /// </summary>
        /// <param name="o">The collection of new item.</param>
        /// <returns>Newly created/inserted item.</returns>
        void BulkInsert<T>(ICollection<T> o) where T : Entity, new();

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
        IEnumerable<T> ExecuteStoreProcedure<T>(string storeProcedureName, params object[] parameters) where T : Entity;

        #endregion EXTRA COMMANDS
    }
}