using Microsoft.EntityFrameworkCore.Migrations;

namespace EmissorPedidosAPI.Migrations
{
    public partial class PhoneNumberTOString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Phones",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Phones",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
