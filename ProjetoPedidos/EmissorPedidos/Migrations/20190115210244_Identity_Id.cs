using Microsoft.EntityFrameworkCore.Migrations;

namespace EmissorPedidos.Migrations
{
    public partial class Identity_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Telefones",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_EmpresaId",
                table: "Telefones",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Empresas_EmpresaId",
                table: "Telefones",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Empresas_EmpresaId",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_EmpresaId",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Telefones");
        }
    }
}
