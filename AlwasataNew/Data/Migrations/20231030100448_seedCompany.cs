using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlwasataNew.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Companies",
               columns: new[] { "Id", "Name" },
               values: new object[] { 1, "المنظور الشامل"}
           );

            migrationBuilder.InsertData(
              table: "Companies",
              columns: new[] { "Id", "Name" },
              values: new object[] { 2, "مجموعة المهندسين المحترفين" }
          );

            migrationBuilder.InsertData(
              table: "Companies",
              columns: new[] { "Id", "Name" },
              values: new object[] { 3, "فاس الاولى" }
          );

            migrationBuilder.InsertData(
              table: "Companies",
              columns: new[] { "Id", "Name" },
              values: new object[] { 4, "تمويل البناء" }
          );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [Companies]");
        }
    }
}
