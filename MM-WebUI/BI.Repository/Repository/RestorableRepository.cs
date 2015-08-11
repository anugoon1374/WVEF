// ***********************************************************************
// Assembly         : BI.Repository
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-21-2015
// ***********************************************************************
// <copyright file="RestorableRepository.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The data repository extension to make data restorable</summary>
// ***********************************************************************
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BI.Core.Models;
using BI.Core.Repository;

namespace BI.Repository.Repository
{
    /// <summary>
    /// Data repository extension to make data restorable.
    /// </summary>
    /// <typeparam name="T">DelEntity based class type.</typeparam>
    public class RestorableRepository<T> : IRestorableRepository<T> where T : DelEntity
    {
        /// <summary>
        /// The application database context
        /// </summary>
        protected readonly DbContext AppDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestorableRepository{T}" /> class.
        /// </summary>
        /// <param name="appDbContextFactory">The database context factory.</param>
        public RestorableRepository(IAppDbContextFactory<DbContext> appDbContextFactory)
        {
            AppDbContext = appDbContextFactory.GetDbContext();
        }

        #region RESTORE

        /// <summary>
        /// Restores the specified deleted item/object in repository.
        /// </summary>
        /// <param name="o">The specified item/object.</param>
        public void Restore(T o)
        {
            o.IsDeleted = false;
        }

        #endregion RESTORE

        #region READ

        /// <summary>
        /// Gets the specified items/objects by certain criteria from repository.
        /// </summary>
        /// <param name="predicate">The search criteria expression.</param>
        /// <param name="showDeleted">if set to <c>true</c> [return deleted items].</param>
        /// <returns>The item collection (IQueryable).</returns>
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false)
        {
            var res = AppDbContext.Set<T>().Where(predicate);
            if (!showDeleted) res = res.Where(o => o.IsDeleted == false);
            return res;
        }

        /// <summary>
        /// Gets all items/objects from repository.
        /// </summary>
        /// <returns>The item collection (IQueryable).</returns>
        public IQueryable<T> GetAll()
        {
            // NOTE : DO NOT IMPLEMENT ASYNC CALL HERE
            return AppDbContext.Set<T>().Where(o => o.IsDeleted == false);
        }

        #endregion READ
    }
}