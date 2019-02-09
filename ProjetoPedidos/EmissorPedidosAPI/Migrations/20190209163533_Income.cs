using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmissorPedidosAPI.Migrations
{
    public partial class Income : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Observation = table.Column<string>(nullable: true),
                    IncomeValue = table.Column<decimal>(nullable: false),
                    PaidValue = table.Column<decimal>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: true),
                    ReceiveDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    ChartAccountId = table.Column<int>(nullable: true),
                    BankAccountId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incomes_ChartAccounts_ChartAccountId",
                        column: x => x.ChartAccountId,
                        principalTable: "ChartAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incomes_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incomes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_BankAccountId",
                table: "Incomes",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_ChartAccountId",
                table: "Incomes",
                column: "ChartAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_PaymentTypeId",
                table: "Incomes",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_UserId",
                table: "Incomes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incomes");
        }
    }
}
