using CmcApi.Data.AbstractEntities;
using CmcApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CmcApi.Data.DbContexts
{
    public class MssqlDbContext : DbContext
    {
        private readonly string _ConnectionString;
        protected readonly DbContextOptions<MssqlDbContext> _DbContectOptions;

        public MssqlDbContext(DbContextOptions<MssqlDbContext> options, string connectionString) : base(options)
        {
            _DbContectOptions = options;
            _ConnectionString = connectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_ConnectionString);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingAuditedEntity<Vendor>(modelBuilder);
        }

        /// <summary>
        /// Set default values for T ： BaseEntity
        /// </summary>
        /// <typeparam name="T">BaseEntity</typeparam>
        /// <param name="modelBuilder">ModelBuilder</param>
        protected void OnModelCreatingBaseEntity<T>(ModelBuilder modelBuilder)
            where T : BaseEntity
        {
            modelBuilder.Entity<T>().Property(b => b.IsDeleted).HasDefaultValue(false);
        }

        /// <summary>
        /// Set default values for T ： AuditedEntity
        /// </summary>
        /// <typeparam name="T">AuditedEntity</typeparam>
        /// <param name="modelBuilder">ModelBuilder</param>
        protected void OnModelCreatingAuditedEntity<T>(ModelBuilder modelBuilder)
            where T : AuditedEntity
        {
            this.OnModelCreatingBaseEntity<T>(modelBuilder);

            modelBuilder.Entity<T>().Property(b => b.Created).HasDefaultValueSql("GETDATE()");
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Vendor> Vendors { get; set; }
    }
}
