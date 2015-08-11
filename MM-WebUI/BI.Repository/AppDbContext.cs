// ***********************************************************************
// Assembly         : BI.Repository
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 05-22-2015
// ***********************************************************************
// <copyright file="DbContext.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The application database context.</summary>
// ***********************************************************************
using System.Data.Entity;
using BI.Core.Models;

namespace BI.Repository
{
    /// <summary>
    /// The application database context.
    /// </summary>
    public class AppDbContext : DbContext
    {
        // TODO : Add data table here

        #region Database Tables

        /// <summary>
        /// Gets or sets business information from repository.
        /// </summary>
        /// <value>The business information.</value>
        public DbSet<BusinessInfo> BusinessInfoes { get; set; }

        #endregion Database Tables

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext" /> class.
        /// </summary>
        public AppDbContext()
            : base("DefaultConnection")
        {
            // Uncomment line below in case you want to disable auto-create database in production machine
            // Database.SetInitializer<Db>(null);
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.</remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BusinessInfo>().HasKey(s => s.Uid);
            //base.OnModelCreating(modelBuilder);
        }
    }
}