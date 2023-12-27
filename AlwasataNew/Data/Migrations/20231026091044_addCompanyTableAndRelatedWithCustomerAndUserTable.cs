using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlwasataNew.Data.Migrations
{
    /// <inheritdoc />
    public partial class addCompanyTableAndRelatedWithCustomerAndUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectDesignStages");

            migrationBuilder.DropColumn(
                name: "AffiliatedTo",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AffiliatedTo",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "security",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                schema: "security",
                table: "Users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Companies_CompanyId",
                table: "Customers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId",
                schema: "security",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Companies_CompanyId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "AffiliatedTo",
                schema: "security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AffiliatedTo",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectDesignStages",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ArchitecturalDesigns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchitecturalPlans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConstructionPlans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElectricityPlans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialThoughts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interfaces = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MechanicsDiagrams = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyAndDevelop = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
    }
}
