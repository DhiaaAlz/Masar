using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlwasataNew.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerCommentTbl_AddEmployeeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "CustomerCommentstbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "CustomerCommentstbls");
        }
    }
}
