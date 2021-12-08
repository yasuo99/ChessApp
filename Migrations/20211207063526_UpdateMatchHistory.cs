using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessApp.Migrations
{
    public partial class UpdateMatchHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndAt",
                table: "MatchHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartAd",
                table: "MatchHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndAt",
                table: "MatchHistory");

            migrationBuilder.DropColumn(
                name: "StartAd",
                table: "MatchHistory");
        }
    }
}
