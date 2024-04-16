using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlwasataNew.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInteriorDesignQuestionnaireTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectDesign",
                table: "InteriorDesignQuestionnaires",
                newName: "DesignStyle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DesignStyle",
                table: "InteriorDesignQuestionnaires",
                newName: "ProjectDesign");
        }
    }
}
