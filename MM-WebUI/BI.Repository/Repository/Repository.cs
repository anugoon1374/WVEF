// ***********************************************************************
// Assembly         : BI.Repository
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 05-22-2015
// ***********************************************************************
// <copyright file="Repository.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The data repository.</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BI.Core.Models;
using BI.Core.Repository;
using BI.Infrastructure;
using Omu.ValueInjecter;
using EntityFramework.BulkInsert.Extensions;

namespace BI.Repository.Repository
{
    /// <summary>
    /// The restorable data repository (CRUDR).
    /// </summary>
    /// <typeparam name="T">Entity based class type.</typeparam>
    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        /// <summary>
        /// The application database context
        /// </summary>
        protected readonly DbContext AppDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}" /> class.
        /// </summary>
        /// <param name="appDbContextFactory">The database context factory.</param>
        public Repository(IAppDbContextFactory<DbContext> appDbContextFactory)
        {
            AppDbContext = appDbContextFactory.GetDbContext();
        }

        #region CREATE

        /// <summary>
        /// Creates/Inserts the new item/object into repository.
        /// </summary>
        /// <param name="o">The new item.</param>
        /// <returns>Newly created/inserted item.</returns>
        public T Insert(T o)
        {
            var t = AppDbContext.Set<T>().Create();
            t.InjectFrom(o);
            AppDbContext.Set<T>().Add(t);
            AppDbContext.SaveChangesAsync();
            return t;
        }

        #endregion CREATE

        #region READ

        /// <summary>
        /// Gets the specified item/object by unique identifier from repository.
        /// </summary>
        /// <param name="uid">The item's unique identifier.</param>
        /// <returns>The specified item.</returns>
        public T Get(ulong uid)
        {
            return AppDbContext.Set<T>().Find(uid);
        }

        /// <summary>
        /// Gets the specified items/objects by certain criteria from repository.
        /// </summary>
        /// <param name="predicate">The search criteria expression.</param>
        /// <param name="showDeleted">if set to <c>true</c> [return deleted items].</param>
        /// <returns>The item collection (IQueryable).</returns>
        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false)
        {
            if (typeof(IDel).IsAssignableFrom(typeof(T)))
                return IoC.Resolve<IRestorableRepository<T>>().Where(predicate, showDeleted);

            return AppDbContext.Set<T>().Where(predicate);
        }

        /// <summary>
        /// Gets all items/objects from repository.
        /// </summary>
        /// <returns>The item collection (IQueryable).</returns>
        public virtual IQueryable<T> GetAll()
        {
            if (typeof(IDel).IsAssignableFrom(typeof(T)))
                return IoC.Resolve<IRestorableRepository<T>>().GetAll();

            return AppDbContext.Set<T>();
        }

        #endregion READ

        #region UPDATE

        /// <summary>
        /// Saves all change to repository.
        /// </summary>
        public void Save()
        {
            AppDbContext.SaveChanges();
        }

        #endregion UPDATE

        #region DELETE / RESTORE

        /// <summary>
        /// Deletes the specified item/object in repository.
        /// </summary>
        /// <param name="o">The specified item/object.</param>
        public virtual void Delete(T o)
        {
            if (o is IDel)
                (o as IDel).IsDeleted = true;
            else
            {
                AppDbContext.Set<T>().Remove(o);
                AppDbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Restores the specified deleted item/object in repository.
        /// </summary>
        /// <param name="o">The specified item/object.</param>
        public void Restore(T o)
        {
            if (o is IDel)
                IoC.Resolve<IRestorableRepository<T>>().Restore(o);
            AppDbContext.SaveChangesAsync();
        }

        #endregion DELETE / RESTORE

        #region EXTRA COMMANDS

        /// <summary>
        /// Creates/Inserts the collection of new item/object into repository.
        /// </summary>
        /// <param name="o">The collection of new item.</param>
        /// <returns>Newly created/inserted item.</returns>
        /// <remarks>This method use "EntityFramework.BulkInsert" extension</remarks>
        /// <seealso href="https://efbulkinsert.codeplex.com/">EntityFramework.BulkInsert extension</seealso>
        /// <seealso href="https://msdn.microsoft.com/en-us/data/dn456843.aspx">Entity Framework Transactions</seealso>
        public void BulkInsert(ICollection<T> o)
        {
            using (var dbContextTransaction = AppDbContext.Database.BeginTransaction())
            {
                try
                {
                    AppDbContext.BulkInsert(o);
                    AppDbContext.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                } 
            }
        }

        /// <summary>
        /// Executes the store procedure (Microsoft SQL Server only).
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="parameters">The parameters want to pass to store procedure.</param>
        /// <returns>The item collection (IEnumerable).</returns>
        /// <seealso href="http://stackoverflow.com/questions/20901419/how-to-call-stored-procedure-in-entity-framework-6-code-first">How to call stored procedure from Entity Framework</seealso>
        /// <remarks>This method support return with single result set only.</remarks>
        public virtual IEnumerable<T> ExecuteStoreProcedure(string storeProcedureName, params object[] parameters)
        {
            return AppDbContext.Database.SqlQuery<T>(storeProcedureName, parameters);
        }

        #endregion EXTRA COMMANDS
    }
}
