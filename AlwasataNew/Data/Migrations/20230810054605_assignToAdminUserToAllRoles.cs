using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlwasataNew.Data.Migrations
{
    public partial class assignToAdminUserToAllRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT into [security].[UserRoles] (UserId,RoleId) SELECT '1fd111fe-cc6f-4eba-b043-3bbab4bc3d06',Id FROM [security].[Roles] where Name = 'Admin'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("\r\n\r\nDELETE from [security].[UserRoles] where UserId='1fd111fe-cc6f-4eba-b043-3bbab4bc3d06'");
        }
    }
}
