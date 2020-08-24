using Microsoft.EntityFrameworkCore.Migrations;

namespace GameOfDrones.Migrations
{
    public partial class Rounds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GamesId",
                table: "Round",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Round_GamesId",
                table: "Round",
                column: "GamesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Round_Game_GamesId",
                table: "Round",
                column: "GamesId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Round_Game_GamesId",
                table: "Round");

            migrationBuilder.DropIndex(
                name: "IX_Round_GamesId",
                table: "Round");

            migrationBuilder.DropColumn(
                name: "GamesId",
                table: "Round");
        }
    }
}
