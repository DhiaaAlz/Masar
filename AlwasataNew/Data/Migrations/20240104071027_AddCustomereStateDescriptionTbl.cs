using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlwasataNew.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomereStateDescriptionTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customerStateDescriptionTbl",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FollowTo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerStateDescriptionTbl", x => x.StateId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerStateDescriptionTbl");
        }
    }
}
