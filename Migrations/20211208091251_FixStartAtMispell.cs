using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessApp.Migrations
{
    public partial class FixStartAtMispell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartAd",
                table: "MatchHistory",
                newName: "StartAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartAt",
                table: "MatchHistory",
                newName: "StartAd");
        }
    }
}
