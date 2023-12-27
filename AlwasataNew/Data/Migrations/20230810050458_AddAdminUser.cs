using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlwasataNew.Data.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePicture]) VALUES (N'1fd111fe-cc6f-4eba-b043-3bbab4bc3d06', N'admin', N'ADMIN', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEGwlZ8CeXrqk20XLYTCDCLX+RmW5AyA5TiJeTY12l88cmWNouCKpmBZAaFij0Ydo1g==', N'RK5CFJ2LIAQYFYOWXUWBO247EVT7LNZD', N'ee050044-a75d-441a-8e5b-14635149d50e', NULL, 0, 0, NULL, 1, 0, N'Admin', N'Admin', null)\r\n");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [security].[Users] WHERE Id = '1fd111fe-cc6f-4eba-b043-3bbab4bc3d06'");
        }
    }
}
