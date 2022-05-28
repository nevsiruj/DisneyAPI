using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisneyAPI.Migrations
{
    public partial class v33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personajes_Obras_ObraId",
                table: "Personajes");

            migrationBuilder.AlterColumn<int>(
                name: "ObraId",
                table: "Personajes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Personajes_Obras_ObraId",
                table: "Personajes",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "ObraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personajes_Obras_ObraId",
                table: "Personajes");

            migrationBuilder.AlterColumn<int>(
                name: "ObraId",
                table: "Personajes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personajes_Obras_ObraId",
                table: "Personajes",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "ObraId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
