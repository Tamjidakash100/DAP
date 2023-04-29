using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class budgetrelease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acc_BudgetRelease",
                columns: table => new
                {
                    BudgetReleaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearId = table.Column<int>(nullable: false),
                    FiscalMonthId = table.Column<int>(nullable: false),
                    AccId = table.Column<int>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    DebitAmount = table.Column<double>(nullable: false),
                    CreditAmount = table.Column<double>(nullable: false),
                    EmpId = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 400, nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    UserIdUpdated = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_BudgetRelease", x => x.BudgetReleaseId);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetRelease_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetRelease_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetRelease_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acc_BudgetRelease_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetRelease_AccId",
                table: "Acc_BudgetRelease",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetRelease_EmpId",
                table: "Acc_BudgetRelease",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetRelease_FiscalMonthId",
                table: "Acc_BudgetRelease",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_BudgetRelease_FiscalYearId",
                table: "Acc_BudgetRelease",
                column: "FiscalYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_BudgetRelease");
        }
    }
}
