using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlwasataNew.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateV2InteriorDesignQuestionnaireTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Basment",
                table: "InteriorDesignQuestionnaires",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SurfaceFloor",
                table: "InteriorDesignQuestionnaires",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Basment",
                table: "InteriorDesignQuestionnaires");

            migrationBuilder.DropColumn(
                name: "SurfaceFloor",
                table: "InteriorDesignQuestionnaires");
        }
    }
}
