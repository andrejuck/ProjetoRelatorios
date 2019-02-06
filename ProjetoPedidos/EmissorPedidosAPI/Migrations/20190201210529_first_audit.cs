using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmissorPedidosAPI.Migrations
{
    public partial class first_audit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activated",
                table: "Users",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Activated",
                table: "Companies",
                nullable: false,
                defaultValue: true);

            migrationBuilder.CreateTable(
                name: "CompaniesAudit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Change = table.Column<string>(nullable: true),
                    ChangeDate = table.Column<DateTime>(nullable: false),
                    NewSocialName = table.Column<string>(nullable: true),
                    NewFantasyName = table.Column<string>(nullable: true),
                    NewSubscription = table.Column<string>(nullable: true),
                    NewStateSubscription = table.Column<string>(nullable: true),
                    NewEmail = table.Column<string>(nullable: true),
                    NewActivated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesAudit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompaniesAudit_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompaniesAudit_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesAudit_CompanyId",
                table: "CompaniesAudit",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesAudit_UserId",
                table: "CompaniesAudit",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompaniesAudit");

            migrationBuilder.DropColumn(
                name: "Activated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Activated",
                table: "Companies");
        }
    }
}
