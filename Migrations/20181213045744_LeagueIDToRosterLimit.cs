using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ff_platform.Migrations
{
    public partial class LeagueIDToRosterLimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LeagueID",
                table: "RosterLimitModel",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "LeagueRules",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    RosterLimitsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueRules", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LeagueRules_RosterLimitModel_RosterLimitsID",
                        column: x => x.RosterLimitsID,
                        principalTable: "RosterLimitModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeagueRules_RosterLimitsID",
                table: "LeagueRules",
                column: "RosterLimitsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeagueRules");

            migrationBuilder.DropColumn(
                name: "LeagueID",
                table: "RosterLimitModel");
        }
    }
}
