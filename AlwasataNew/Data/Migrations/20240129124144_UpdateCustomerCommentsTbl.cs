using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlwasataNew.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerCommentsTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerCommentstbls",
                table: "CustomerCommentstbls");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerCommentstbls",
                table: "CustomerCommentstbls",
                columns: new[] { "CustomerId", "Id", "StateId", "TypeOfCommunicationId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerCommentstbls",
                table: "CustomerCommentstbls");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerCommentstbls",
                table: "CustomerCommentstbls",
                columns: new[] { "CustomerId", "Id" });
        }
    }
}
