using Microsoft.EntityFrameworkCore.Migrations;

namespace EmissorPedidos.Migrations
{
    public partial class Tabela_NivelUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_nivel_usuario_NivelUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_nivel_usuario",
                table: "nivel_usuario");

            migrationBuilder.RenameTable(
                name: "nivel_usuario",
                newName: "NivelUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NivelUsuario",
                table: "NivelUsuario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_NivelUsuario_NivelUsuarioId",
                table: "Usuarios",
                column: "NivelUsuarioId",
                principalTable: "NivelUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_NivelUsuario_NivelUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NivelUsuario",
                table: "NivelUsuario");

            migrationBuilder.RenameTable(
                name: "NivelUsuario",
                newName: "nivel_usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_nivel_usuario",
                table: "nivel_usuario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_nivel_usuario_NivelUsuarioId",
                table: "Usuarios",
                column: "NivelUsuarioId",
                principalTable: "nivel_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
