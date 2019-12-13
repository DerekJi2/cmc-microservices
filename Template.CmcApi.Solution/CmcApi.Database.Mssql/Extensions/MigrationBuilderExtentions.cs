using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace CmcApi.Database.Mssql.Extensions
{
    public static class MigrationBuilderExtentions
    {
        public static void AddScript(this MigrationBuilder migrationBuilder, string scriptFile)
        {
            if (File.Exists(scriptFile))
            {
                string sqlText = File.ReadAllText(scriptFile);
                if (!string.IsNullOrEmpty(sqlText))
                {
                    migrationBuilder.Sql(sqlText);
                    return;
                }
            }
            throw new Exception($"Cannot find script file '{scriptFile}', or it's an empty file.");
        }
    }
}
