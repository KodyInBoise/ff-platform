using Microsoft.EntityFrameworkCore.Migrations;

namespace ff_platform.Migrations
{
    public partial class UpdatedTeamModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LeagueID",
                table: "Teams",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LeagueID",
                table: "Teams",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
