using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CmcApi.Database.Mssql.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    Version = table.Column<int>(nullable: true, defaultValue: 1),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    LastModified = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Code = table.Column<string>(maxLength: 25, nullable: true),
                    AbnNum = table.Column<string>(maxLength: 25, nullable: true),
                    LegalName = table.Column<string>(maxLength: 255, nullable: true),
                    BusinessName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
