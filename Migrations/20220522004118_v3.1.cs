using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisneyAPI.Migrations
{
    public partial class v31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Generos_GeneroId",
                table: "Obras");

            migrationBuilder.AlterColumn<int>(
                name: "GeneroId",
                table: "Obras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Generos",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

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

            migrationBuilder.AlterColumn<int>(
                name: "GeneroId",
                table: "Obras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Generos",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Generos_GeneroId",
                table: "Obras",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "GeneroId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
