using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sukuposti.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET SESSION sql_mode = 'ALLOW_INVALID_DATES';");
            
            migrationBuilder.AlterColumn<DateTime>(
                name: "syntaika",
                table: "hevonen",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_unicode_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "syntaika",
                table: "hevonen",
                type: "varchar(10)",
                nullable: true,
                collation: "utf8mb3_unicode_ci",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3");
        }
    }
}
