using CmcApi.Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CmcApi.Database.Mssql
{
    public static class DbContextExtension
    {

        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this MssqlDbContext context)
        {

            if (!context.Vendors.Any())
            {
                var types = JsonConvert.DeserializeObject<List<Vendor>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "types.json"));
                context.AddRange(types);
                context.SaveChanges();
            }
        }
    }
}
