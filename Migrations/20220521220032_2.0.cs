using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisneyAPI.Migrations
{
    public partial class _20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personajees_Obras_ObraId",
                table: "Personajees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personajees",
                table: "Personajees");

            migrationBuilder.RenameTable(
                name: "Personajees",
                newName: "Personajes");

            migrationBuilder.RenameIndex(
                name: "IX_Personajees_ObraId",
                table: "Personajes",
                newName: "IX_Personajes_ObraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personajes",
                table: "Personajes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personajes_Obras_ObraId",
                table: "Personajes",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "ObraId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personajes_Obras_ObraId",
                table: "Personajes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personajes",
                table: "Personajes");

            migrationBuilder.RenameTable(
                name: "Personajes",
                newName: "Personajees");

            migrationBuilder.RenameIndex(
                name: "IX_Personajes_ObraId",
                table: "Personajees",
                newName: "IX_Personajees_ObraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personajees",
                table: "Personajees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personajees_Obras_ObraId",
                table: "Personajees",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "ObraId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
