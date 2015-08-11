// ***********************************************************************
// Assembly         : BI.Repository
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 05-22-2015
// ***********************************************************************
// <copyright file="UniversalRepository.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The universal data repository.</summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BI.Core.Models;
using BI.Core.Repository;
using EntityFramework.BulkInsert.Extensions;
using Omu.ValueInjecter;

namespace BI.Repository.Repository
{
    /// <summary>
    /// The universal data repository (CRUD).
    /// </summary>
    public class UniversalRepository : IUniversalRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        protected readonly DbContext AppDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniversalRepository" /> class.
        /// </summary>
        /// <param name="appDbContextFactory">The database context factory.</param>
        public UniversalRepository(IAppDbContextFactory<DbContext> appDbContextFactory)
        {
            AppDbContext = appDbContextFactory.GetDbContext();
        }

        #region CREATE

        /// <summary>
        /// Creates/Inserts the new item/object into repository.
        /// </summary>
        /// <typeparam name="T">Entity based class type.</typeparam>
        /// <param name="o">The new item.</param>
        /// <returns>Newly created/inserted item.</returns>
        public T Insert<T>(T o) where T : Entity, new()
        {
            var t = new T();
            t.InjectFrom(o);
            AppDbContext.Set<T>().Add(t);
            AppDbContext.SaveChangesAsync();
            return t;
        }

        #endregion CREATE

        #region UPDATE

        /// <summary>
        /// Saves repository.
        /// </summary>
        public void Save()
        {
            AppDbContext.SaveChangesAsync();
        }

        #endregion UPDATE

        #region READ

        /// <summary>
        /// Gets the specified item by identifier from repository.
        /// </summary>
        /// <typeparam name="T">Entity based class type.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>The item object.</returns>
        public T Get<T>(int id) where T : Entity
        {
            return AppDbContext.Set<T>().Find(id);
        }

        /// <summary>
        /// Gets all items/objects from repository.
        /// </summary>
        /// <typeparam name="T">Entity based class type.</typeparam>
        /// <returns>The item collection (IQueryable).</returns>
        public IQueryable<T> GetAll<T>() where T : Entity
        {
            return AppDbContext.Set<T>();
        }

        #endregion READ

        #region EXTRA COMMANDS

        /// <summary>
        /// Creates/Inserts the collection of new item/object into repository.
        /// </summary>
        /// <param name="o">The collection of new item.</param>
        /// <returns>Newly created/inserted item.</returns>
        /// <remarks>This method use "EntityFramework.BulkInsert" extension</remarks>
        /// <seealso href="https://efbulkinsert.codeplex.com/">EntityFramework.BulkInsert extension</seealso>
        /// <seealso href="https://msdn.microsoft.com/en-us/data/dn456843.aspx">Entity Framework Transactions</seealso>
        public void BulkInsert<T>(ICollection<T> o) where T : Entity, new()
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
        public virtual IEnumerable<T> ExecuteStoreProcedure<T>(string storeProcedureName, params object[] parameters)
            where T : Entity
        {
            return AppDbContext.Database.SqlQuery<T>(storeProcedureName, parameters);
        }

        #endregion EXTRA COMMANDS
    }
}