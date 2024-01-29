using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlwasataNew.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdaateCustomerCommentTblAddDateField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "date",
                table: "CustomerCommentstbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "CustomerCommentstbls");
        }
    }
}
