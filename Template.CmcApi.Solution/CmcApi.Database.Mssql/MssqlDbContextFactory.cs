using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CmcApi.Database.Mssql
{
    public class MssqlDbContextFactory : IDesignTimeDbContextFactory<MssqlDbContext>
    {
        public MssqlDbContextFactory()
        {
        }


        public MssqlDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            var builder = new DbContextOptionsBuilder<MssqlDbContext>();
            var connectionString = configuration.GetConnectionString("Default");
            builder.UseSqlServer(connectionString);

            return new MssqlDbContext(builder.Options, connectionString);
        }
    }
}
