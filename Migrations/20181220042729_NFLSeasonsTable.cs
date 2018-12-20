using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ff_platform.Migrations
{
    public partial class NFLSeasonsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NFLSeasons",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    PreseasonWeekCount = table.Column<int>(nullable: false),
                    RegularSeasonWeekCount = table.Column<int>(nullable: false),
                    PostSeasonWeekCount = table.Column<int>(nullable: false),
                    TotalWeekCount = table.Column<int>(nullable: false),
                    PreaseasonStart = table.Column<DateTime>(nullable: false),
                    RegularSeasonStart = table.Column<DateTime>(nullable: false),
                    PostSeasonStart = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFLSeasons", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NFLSeasons");
        }
    }
}
