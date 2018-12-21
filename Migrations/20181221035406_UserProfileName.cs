using Microsoft.EntityFrameworkCore.Migrations;

namespace ff_platform.Migrations
{
    public partial class UserProfileName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserProfiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserProfiles");
        }
    }
}
