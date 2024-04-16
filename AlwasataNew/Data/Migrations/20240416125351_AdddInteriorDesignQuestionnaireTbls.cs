using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlwasataNew.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdddInteriorDesignQuestionnaireTbls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirstFloorQuestionnaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterBedroom = table.Column<bool>(type: "bit", nullable: false),
                    Room1 = table.Column<bool>(type: "bit", nullable: false),
                    FirstFloorHall = table.Column<bool>(type: "bit", nullable: false),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InteriorDesignQuestionnaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstFloorQuestionnaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroundFloorQuestionnaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenCouncil = table.Column<bool>(type: "bit", nullable: false),
                    WCMenCouncil = table.Column<bool>(type: "bit", nullable: false),
                    WomenCouncil = table.Column<bool>(type: "bit", nullable: false),
                    WCWomenCouncil = table.Column<bool>(type: "bit", nullable: false),
                    GroundFloorHall = table.Column<bool>(type: "bit", nullable: false),
                    Kitchen = table.Column<bool>(type: "bit", nullable: false),
                    ExternalAttachment = table.Column<bool>(type: "bit", nullable: false),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InteriorDesignQuestionnaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundFloorQuestionnaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interfaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrontInterfaces = table.Column<bool>(type: "bit", nullable: false),
                    SideInterfaces = table.Column<bool>(type: "bit", nullable: false),
                    SideInterfaces2 = table.Column<bool>(type: "bit", nullable: false),
                    BackInterfaces = table.Column<bool>(type: "bit", nullable: false),
                    InteriorDesignQuestionnaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interfaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InteriorDesignQuestionnaires",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDesign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuldingArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroundFloorQuestionnaireId = table.Column<int>(type: "int", nullable: false),
                    FirstFloorQuestionnaireId = table.Column<int>(type: "int", nullable: false),
                    InterfacesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteriorDesignQuestionnaires", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirstFloorQuestionnaires");

            migrationBuilder.DropTable(
                name: "GroundFloorQuestionnaires");

            migrationBuilder.DropTable(
                name: "Interfaces");

            migrationBuilder.DropTable(
                name: "InteriorDesignQuestionnaires");
        }
    }
}
