using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GTERP.Migrations.GTRDB
{
    public partial class voucherPF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_PFIntegrationSummary",
                columns: table => new
                {
                    Cat_PFIntegrationSummaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataType = table.Column<string>(nullable: true),
                    EmployeeType = table.Column<string>(nullable: true),
                    AccId = table.Column<int>(nullable: false),
                    FiscalYearId = table.Column<int>(nullable: true),
                    FiscalMonthId = table.Column<int>(nullable: true),
                    TKDebitLocal = table.Column<double>(nullable: false),
                    TKCreditLocal = table.Column<double>(nullable: false),
                    SLNo = table.Column<string>(nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    Note1 = table.Column<string>(nullable: true),
                    Note2 = table.Column<string>(nullable: true),
                    Note3 = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_PFIntegrationSummary", x => x.Cat_PFIntegrationSummaryId);
                    table.ForeignKey(
                        name: "FK_Cat_PFIntegrationSummary_Acc_ChartOfAccount_PF_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccount_PF",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cat_PFIntegrationSummary_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cat_PFIntegrationSummary_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PFIntegrationSummary_AccId",
                table: "Cat_PFIntegrationSummary",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PFIntegrationSummary_FiscalMonthId",
                table: "Cat_PFIntegrationSummary",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PFIntegrationSummary_FiscalYearId",
                table: "Cat_PFIntegrationSummary",
                column: "FiscalYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_PFIntegrationSummary");
        }
    }
}
