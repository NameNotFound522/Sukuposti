using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sukuposti.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET SESSION sql_mode = 'ALLOW_INVALID_DATES';");
            
            migrationBuilder.AlterColumn<DateOnly>(
                name: "syntaika",
                table: "hevonen",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "syntaika",
                table: "hevonen",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);
        }
    }
}
