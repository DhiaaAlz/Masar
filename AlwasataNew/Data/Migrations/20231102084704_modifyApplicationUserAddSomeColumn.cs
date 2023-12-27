using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlwasataNew.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifyApplicationUserAddSomeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "security",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Admin Admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "security",
                table: "Users");
        }
    }
}
