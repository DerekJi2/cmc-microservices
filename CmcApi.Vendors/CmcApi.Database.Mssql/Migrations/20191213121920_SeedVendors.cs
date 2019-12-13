using CmcApi.Database.Mssql.Extensions;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmcApi.Database.Mssql.Migrations
{
    public partial class SeedVendors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddScript("SeedData/20191212115513_SeedVendors.sql");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
