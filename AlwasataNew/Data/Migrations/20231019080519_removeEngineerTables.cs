using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlwasataNew.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeEngineerTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirConditioningPlans");

            migrationBuilder.DropTable(
                name: "Architecturalplans");

            migrationBuilder.DropTable(
                name: "ConstructionDrawings");

            migrationBuilder.DropTable(
                name: "ElectricityPlans");

            migrationBuilder.DropTable(
                name: "MechanicalDiagrams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirConditioningPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirConditioningPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Architecturalplans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Architecturalplans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstructionDrawings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionDrawings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MechanicalDiagrams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicalDiagrams", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AirConditioningPlans",
                columns: new[] { "Id", "CreatedBy", "Name" },
                values: new object[,]
                {
                    { 1, "Admin", "مخطط التكييف للقبو" },
                    { 2, "Admin", "مخطط التكييف للأرضي" },
                    { 3, "Admin", "مخطط التكييف للأول" },
                    { 4, "Admin", "مخطط التكييف للملاحق العلوية" },
                    { 5, "Admin", "مواقع وحدات التكييف في الاسطح" },
                    { 6, "Admin", "حساب الاحمال للتكييف" }
                });

            migrationBuilder.InsertData(
                table: "Architecturalplans",
                columns: new[] { "Id", "CreatedBy", "Name" },
                values: new object[,]
                {
                    { 1, "Admin", "الموقع العام" },
                    { 2, "Admin", "معماري دور القبو" },
                    { 3, "Admin", "معماري الدور الارضي" },
                    { 4, "Admin", "معماري الدور الاول" },
                    { 5, "Admin", "معماري الملاحق العلوية" },
                    { 6, "Admin", "مخططات فرش القبو" },
                    { 7, "Admin", "مخططات فرش الدور الارضي" },
                    { 8, "Admin", "مخططات فرش الدور الاول" },
                    { 9, "Admin", "قطاعين عرضي وطولي" },
                    { 10, "Admin", "4 واجهات" },
                    { 11, "Admin", "جداول الابواب والنوافذ" },
                    { 12, "Admin", "تفاصيل الادراج" },
                    { 13, "Admin", "مخططات الاسوار" },
                    { 14, "Admin", "لوحة تفاصيل المصعد" },
                    { 15, "Admin", "لوحة ارضيات" },
                    { 16, "Admin", "سقف" }
                });

            migrationBuilder.InsertData(
                table: "ConstructionDrawings",
                columns: new[] { "Id", "CreatedBy", "Name" },
                values: new object[,]
                {
                    { 1, "Admin", "مخطط المحاور والاعمدة" },
                    { 2, "Admin", "مخطط اللبشة" },
                    { 3, "Admin", "مخطط القواعد المسلحة" },
                    { 4, "Admin", "مخطط الميد والارضيات" },
                    { 5, "Admin", "مخطط سقف الدور القبو" },
                    { 6, "Admin", "مخطط سقف الدور الارضي" },
                    { 7, "Admin", "مخطط سقف الدور الاول" },
                    { 8, "Admin", "مخطط سقف الملحق العلوي" },
                    { 9, "Admin", "الجداول" },
                    { 10, "Admin", "مخططات تفصيلية" }
                });

            migrationBuilder.InsertData(
                table: "ElectricityPlans",
                columns: new[] { "Id", "CreatedBy", "Name" },
                values: new object[,]
                {
                    { 1, "Admin", "مخطط اضاءة القبو" },
                    { 2, "Admin", "مخطط اضاءة الدور الارضي" },
                    { 3, "Admin", "مخطط اضاءة الدور الاول" },
                    { 4, "Admin", "مخطط اضاءة دور الملحق" },
                    { 5, "Admin", "مخطط القوى للقبو" },
                    { 6, "Admin", "مخطط القوى للأرضي" },
                    { 7, "Admin", " مخطط القوى للأول" },
                    { 8, "Admin", "مخطط القوى للملحق العلوي" },
                    { 9, "Admin", "مخطط التيار المنخفض" },
                    { 10, "Admin", "مخطط التيار المنخفض للقبو" },
                    { 11, "Admin", "مخطط التيار المنخفض للأرضي" },
                    { 12, "Admin", "مخطط التيار المنخفض للأول" },
                    { 13, "Admin", "مخطط التيار المنخفض للملحق العلوي" },
                    { 14, "Admin", "تأسيس الطاقة الشمسية" },
                    { 15, "Admin", "مخططات كميرات المراقبة" },
                    { 16, "Admin", "جداول الاحمال" },
                    { 17, "Admin", "مخططات تأريض" },
                    { 18, "Admin", "جداول ورموز توضيحية" },
                    { 19, "Admin", "مخطط كفاءة الطاقة" }
                });

            migrationBuilder.InsertData(
                table: "MechanicalDiagrams",
                columns: new[] { "Id", "CreatedBy", "Name" },
                values: new object[,]
                {
                    { 1, "Admin", " مخططات صرف الامطار" },
                    { 2, "Admin", "مخططات الصرف العام" },
                    { 3, "Admin", "مخطط التهوية" },
                    { 4, "Admin", "مخطط التغذية" },
                    { 5, "Admin", "موقع الخزانات والبيارة" },
                    { 6, "Admin", "مخطط كفاءة الطاقة" }
                });
        }
    }
}
