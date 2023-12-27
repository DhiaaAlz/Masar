using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlwasataNew.Data.Migrations
{
    /// <inheritdoc />
    public partial class addProjectDesignStagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectDesignStages",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    InitialThoughts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchitecturalDesigns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyAndDevelop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interfaces = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElectricityPlans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MechanicsDiagrams = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConstructionPlans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchitecturalPlans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDesignStages", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_ProjectDesignStages_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectDesignStages");
        }
    }
}
