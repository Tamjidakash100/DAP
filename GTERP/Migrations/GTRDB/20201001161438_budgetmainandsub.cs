using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class budgetmainandsub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetMains",
                columns: table => new
                {
                    BudgetMainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearId = table.Column<int>(nullable: false),
                    FiscalMonthId = table.Column<int>(nullable: false),
                    TotalBudgetDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalBudgetCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetMains", x => x.BudgetMainId);
                    table.ForeignKey(
                        name: "FK_BudgetMains_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetMains_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BudgetDetails",
                columns: table => new
                {
                    BudgetDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetMainId = table.Column<int>(nullable: false),
                    AccId = table.Column<int>(nullable: false),
                    BudgetDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BudgetCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetDetails", x => x.BudgetDetailsId);
                    table.ForeignKey(
                        name: "FK_BudgetDetails_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetDetails_BudgetMains_BudgetMainId",
                        column: x => x.BudgetMainId,
                        principalTable: "BudgetMains",
                        principalColumn: "BudgetMainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetDetails_AccId",
                table: "BudgetDetails",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetDetails_BudgetMainId",
                table: "BudgetDetails",
                column: "BudgetMainId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetMains_FiscalMonthId",
                table: "BudgetMains",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetMains_FiscalYearId",
                table: "BudgetMains",
                column: "FiscalYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetDetails");

            migrationBuilder.DropTable(
                name: "BudgetMains");
        }
    }
}
