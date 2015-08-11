// ***********************************************************************
// Assembly         : BI.Repository
// Author           : Anugoon Leelaphattarakij
// Created          : 04-07-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 05-22-2015
// ***********************************************************************
// <copyright file="DbContextFactory.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The interface for application database context factory.</summary>
// ***********************************************************************
using System;
using System.Data.Entity;
using BI.Infrastructure;

namespace BI.Repository
{
    /// <summary>
    /// Represents the interface for application database context factory.
    /// </summary>
    public interface IAppDbContextFactory<out T>
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <returns>DbContext.</returns>
        T GetDbContext();
    }

    /// <summary>
    /// The factory for initiate application database context.
    /// </summary>
    /// <remarks>This factory handle replication only. For patitioning (scale) MSSQL database use Azure Elastic DB.</remarks>
    /// <seealso href="http://azure.microsoft.com/en-us/documentation/articles/sql-database-elastic-scale-use-entity-framework-applications-visual-studio/">scale MSSQL database use Azure Elastic DB</seealso>
    /// <seealso href="http://stackoverflow.com/questions/6107206/improving-bulk-insert-performance-in-entity-framework">Improving bulk insert performance in Entity framework</seealso>
    public class AppDbContextFactory : IAppDbContextFactory<DbContext>, IDisposable
    {
        #region PROPERTIES

        /// <summary>
        /// The database context
        /// </summary>
        private readonly DbContext _dbContext;

        /// <summary>
        /// The maximum write transaction per context
        /// </summary>
        public int MaxWriteTransactionPerContext { get; private set; }

        /// <summary>
        /// The maximum read transaction per context
        /// </summary>
        public int MaxReadTransactionPerContext { get; private set; }

        #endregion PROPERTIES

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContextFactory" /> class.
        /// </summary>
        public AppDbContextFactory()
        {
            // Initiate Application database context
            _dbContext = new AppDbContext();

            // -----------------------------------------------------------------------
            // Speed Optimization
            // -----------------------------------------------------------------------
            // Commit data change manually
            _dbContext.Configuration.AutoDetectChangesEnabled = AppSettings.Get("Database.EF.AutoDetectChangesEnabled", false);
            // Validate input data manually
            _dbContext.Configuration.ValidateOnSaveEnabled = AppSettings.Get("Database.EF.ValidateOnSaveEnabled", false);

            // -----------------------------------------------------------------------
            // Fix serialize issue - solve serialization fails
            // -----------------------------------------------------------------------
            // Do NOT enable proxied entities, else serialization fails
            _dbContext.Configuration.ProxyCreationEnabled = AppSettings.Get("Database.EF.ProxyCreationEnabled", true);
            // Load navigation properties explicitly to avoid serialization trouble
            _dbContext.Configuration.LazyLoadingEnabled = AppSettings.Get("Database.EF.LazyLoadingEnabled", true);

            MaxWriteTransactionPerContext = AppSettings.Get("Database.EF.MaxWriteTransactionPerContext", 100);
            MaxReadTransactionPerContext = AppSettings.Get("Database.EF.MaxReadTransactionPerContext", 10000);
        }

        /// <summary>
        /// Gets the master database context.
        /// </summary>
        /// <returns>DbContext.</returns>
        public DbContext GetDbContext()
        {
            return _dbContext;
        }

        #region DISPOSE

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                _dbContext.Dispose();
            }
            // free native resources
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion DISPOSE
    }
}