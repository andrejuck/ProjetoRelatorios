using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmissorPedidosAPI.Migrations
{
    public partial class Bank_BankAccount_ChartAccount_Expenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OldActivated",
                table: "CompaniesAudit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OldEmail",
                table: "CompaniesAudit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OldFantasyName",
                table: "CompaniesAudit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OldSocialName",
                table: "CompaniesAudit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OldStateSubscription",
                table: "CompaniesAudit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OldSubscription",
                table: "CompaniesAudit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChartAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChartAccounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<int>(nullable: false),
                    AccountDigit = table.Column<int>(nullable: false),
                    BankAgency = table.Column<int>(nullable: false),
                    BankAgencyDigit = table.Column<int>(nullable: false),
                    BankId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Observation = table.Column<string>(nullable: true),
                    ExpenseValue = table.Column<decimal>(nullable: false),
                    PaidValue = table.Column<decimal>(nullable: false),
                    PenaltyValue = table.Column<decimal>(nullable: false),
                    DiscountValue = table.Column<decimal>(nullable: false),
                    PayDate = table.Column<DateTime>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: false),
                    ExpenseDate = table.Column<DateTime>(nullable: false),
                    BankAccountId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    ChartAccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_ChartAccounts_ChartAccountId",
                        column: x => x.ChartAccountId,
                        principalTable: "ChartAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Dinheiro" },
                    { 2, "Boleto" },
                    { 3, "Cartão de Crédito" },
                    { 4, "Cartão de Débito" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_BankId",
                table: "BankAccounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_UserId",
                table: "BankAccounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_UserId",
                table: "Banks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChartAccounts_UserId",
                table: "ChartAccounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_BankAccountId",
                table: "Expenses",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ChartAccountId",
                table: "Expenses",
                column: "ChartAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PaymentTypeId",
                table: "Expenses",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserId",
                table: "Expenses",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "ChartAccounts");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropColumn(
                name: "OldActivated",
                table: "CompaniesAudit");

            migrationBuilder.DropColumn(
                name: "OldEmail",
                table: "CompaniesAudit");

            migrationBuilder.DropColumn(
                name: "OldFantasyName",
                table: "CompaniesAudit");

            migrationBuilder.DropColumn(
                name: "OldSocialName",
                table: "CompaniesAudit");

            migrationBuilder.DropColumn(
                name: "OldStateSubscription",
                table: "CompaniesAudit");

            migrationBuilder.DropColumn(
                name: "OldSubscription",
                table: "CompaniesAudit");
        }
    }
}
