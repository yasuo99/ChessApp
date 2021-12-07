using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessApp.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WinCount = table.Column<int>(type: "int", nullable: false),
                    LoseCount = table.Column<int>(type: "int", nullable: false),
                    DrawCount = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchResult = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchHistory_Player_HostId",
                        column: x => x.HostId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchHistory_Player_OpponentId",
                        column: x => x.OpponentId,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchHistory_HostId",
                table: "MatchHistory",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchHistory_OpponentId",
                table: "MatchHistory",
                column: "OpponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchHistory");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
