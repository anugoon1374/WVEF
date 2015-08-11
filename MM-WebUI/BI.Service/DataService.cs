// ***********************************************************************
// Assembly         : BI.Service
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-30-2015
// ***********************************************************************
// <copyright file="DataLogic.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summaryThe facade/service locator for data access service.</summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Linq.Expressions;
using BI.Core.Models;
using BI.Core.Repository;
using BI.Core.Service;

namespace BI.Service
{
    /// <summary>
    /// The facade/service locator for data access service.
    /// </summary>
    /// <typeparam name="T">Entity based class type.</typeparam>
    public class DataService<T> : IDataService<T> where T : Entity, new()
    {
        /// <summary>
        /// The data repository
        /// </summary>
        protected IRepository<T> Repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService{T}" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public DataService(IRepository<T> repository)
        {
            Repository = repository;
        }

        #region CREATE

        /// <summary>
        /// Creates/Inserts the new item/object into repository.
        /// </summary>
        /// <param name="item">The new item.</param>
        /// <returns>Unique identifier of the newly created/inserted item (System.UInt64).</returns>
        public virtual ulong Insert(T item)
        {
            var newItem = Repository.Insert(item);
            return newItem.Uid;
        }

        #endregion CREATE

        #region UPDATE

        /// <summary>
        /// Saves repository.
        /// </summary>
        public void Save()
        {
            Repository.Save();
        }

        #endregion UPDATE

        #region READ

        /// <summary>
        /// Gets the specified item/object by unique identifier from repository.
        /// </summary>
        /// <param name="uid">The item's unique identifier.</param>
        /// <returns>The specified item.</returns>
        public T Get(ulong uid)
        {
            return Repository.Get(uid);
        }

        /// <summary>
        /// Gets all items/objects from repository.
        /// </summary>
        /// <returns>The item collection (IQueryable).</returns>
        public IQueryable<T> GetAll()
        {
            return Repository.GetAll();
        }

        /// <summary>
        /// Gets the specified items/objects by certain criteria from repository.
        /// </summary>
        /// <param name="predicate">The search criteria expression.</param>
        /// <param name="showDeleted">if set to <c>true</c> [return deleted items].</param>
        /// <returns>The item collection (IQueryable).</returns>
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false)
        {
            return Repository.Where(predicate, showDeleted);
        }

        #endregion READ

        #region DELETE & RESTORE

        /// <summary>
        /// Deletes the specified item in repository.
        /// </summary>
        /// <param name="uid">The item's unique identifier.</param>
        public virtual void Delete(ulong uid)
        {
            Repository.Delete(Repository.Get(uid));
        }

        /// <summary>
        /// Restores the specified deleted item in repository.
        /// This method will do nothing if object is un-restorable entity.
        /// </summary>
        /// <param name="uid">The item's unique identifier.</param>
        public void Restore(ulong uid)
        {
            Repository.Restore(Repository.Get(uid));
        }

        #endregion DELETE & RESTORE
    }
}