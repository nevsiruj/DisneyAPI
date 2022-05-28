using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisneyAPI.Migrations
{
    public partial class v32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Obras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Obras_GeneroId",
                table: "Obras",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Generos_GeneroId",
                table: "Obras",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "GeneroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Generos_GeneroId",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Obras_GeneroId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Obras");
        }
    }
}
