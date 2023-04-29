using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GTERP.Migrations.GTRDB
{
    public partial class BankStatementBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acc_BankStatementBalances",
                columns: table => new
                {
                    BankStatementBalanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    isDelete = table.Column<bool>(nullable: false),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    BalanceDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_BankStatementBalances", x => x.BankStatementBalanceId);
                    table.ForeignKey(
                        name: "FK_Acc_BankStatementBalances_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BankStatementBalances_AccId",
                table: "Acc_BankStatementBalances",
                column: "AccId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_BankStatementBalances");
        }
    }
}
