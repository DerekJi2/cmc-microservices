using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace CmcApi.Database.Mssql
{
    public class MssqlDbContextFactory //: IDesignTimeDbContextFactory<MssqlDbContext>
    {
        public MssqlDbContextFactory()
        {
        }


        //public MssqlDbContext CreateDbContext(string[] args)
        //{
        //    var builder = new DbContextOptionsBuilder<MssqlDbContext>();
        //    builder.UseSqlServer(
        //        "Server=(localdb)\\mssqllocaldb;Database=config;Trusted_Connection=True;MultipleActiveResultSets=true");

        //    return new MssqlDbContext(builder.Options);
        //}
    }
}
