using CmcApi.Core.Entities;
using CmcApi.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace CmcApi.Database.Mssql
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

        public MssqlDbContext(DbContextOptions<MssqlDbContext> options) : base(options)
        {
            _DbContectOptions = options;
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
            OnModelCreatingBaseEntity<Vendor>(modelBuilder);
        }

        /// <summary>
        /// Set default values for T ： BaseEntity
        /// </summary>
        /// <typeparam name="T">BaseEntity</typeparam>
        /// <param name="modelBuilder">ModelBuilder</param>
        protected void OnModelCreatingBaseEntity<T>(ModelBuilder modelBuilder)
            where T : BaseEntity
        {
            this.OnModelCreatingAuditedEntity<T>(modelBuilder);

            modelBuilder.Entity<T>().Property(b => b.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<T>().Property(b => b.Version).HasDefaultValue(1);
            modelBuilder.Entity<T>().Property(b => b.Guid).HasDefaultValueSql("NEWID()");
        }

        /// <summary>
        /// Set default values for T ： AuditedEntity
        /// </summary>
        /// <typeparam name="T">AuditedEntity</typeparam>
        /// <param name="modelBuilder">ModelBuilder</param>
        protected void OnModelCreatingAuditedEntity<T>(ModelBuilder modelBuilder)
            where T : AuditedEntity
        {
            modelBuilder.Entity<T>().Property(b => b.Created).HasDefaultValueSql("GETDATE()");
        }


    }
}
