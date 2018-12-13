using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ff_platform.Migrations
{
    public partial class rosterlimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RosterLimitsID",
                table: "Leagues",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RosterLimitModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    QuarterbackLimit = table.Column<int>(nullable: false),
                    RunningbackLimit = table.Column<int>(nullable: false),
                    WideReceiverLimit = table.Column<int>(nullable: false),
                    TightEndLimit = table.Column<int>(nullable: false),
                    FullbackLimit = table.Column<int>(nullable: false),
                    KickerLimit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RosterLimitModel", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_RosterLimitsID",
                table: "Leagues",
                column: "RosterLimitsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_RosterLimitModel_RosterLimitsID",
                table: "Leagues",
                column: "RosterLimitsID",
                principalTable: "RosterLimitModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_RosterLimitModel_RosterLimitsID",
                table: "Leagues");

            migrationBuilder.DropTable(
                name: "RosterLimitModel");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_RosterLimitsID",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "RosterLimitsID",
                table: "Leagues");
        }
    }
}
