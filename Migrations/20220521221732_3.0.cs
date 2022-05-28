using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisneyAPI.Migrations
{
    public partial class _30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Generos_Obras_ObraId",
                table: "Generos");

            migrationBuilder.DropIndex(
                name: "IX_Generos_ObraId",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "CurrentObraId",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "ObraId",
                table: "Generos");

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Obras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "currentGeneroId",
                table: "Obras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Obras_GeneroId",
                table: "Obras",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Generos_GeneroId",
                table: "Obras",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "GeneroId",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropColumn(
                name: "currentGeneroId",
                table: "Obras");

            migrationBuilder.AddColumn<int>(
                name: "CurrentObraId",
                table: "Generos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Generos",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ObraId",
                table: "Generos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Generos_ObraId",
                table: "Generos",
                column: "ObraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Generos_Obras_ObraId",
                table: "Generos",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "ObraId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
