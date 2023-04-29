using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class PayrollIntegrationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "HR_ReportType",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Cat_PayrollIntegration_Settings",
                columns: table => new
                {
                    PayrollIntegrationSettingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayrollIntegrationSettingName = table.Column<string>(maxLength: 30, nullable: false),
                    AccId = table.Column<int>(nullable: false),
                    PayrollTableName = table.Column<string>(nullable: true),
                    PayrollColumnName = table.Column<string>(nullable: true),
                    OtherLinkOne = table.Column<string>(nullable: true),
                    OtherLineTwo = table.Column<string>(nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_PayrollIntegration_Settings", x => x.PayrollIntegrationSettingId);
                    table.ForeignKey(
                        name: "FK_Cat_PayrollIntegration_Settings_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cat_PayrollIntegrationSummary",
                columns: table => new
                {
                    Cat_PayrollIntegrationSummaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataType = table.Column<string>(nullable: true),
                    EmployeeType = table.Column<string>(nullable: true),
                    AccId = table.Column<int>(nullable: false),
                    FiscalYearId = table.Column<int>(nullable: true),
                    FiscalMonthId = table.Column<int>(nullable: true),
                    TKDebitLocal = table.Column<double>(nullable: false),
                    TKCreditLocal = table.Column<double>(nullable: false),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_PayrollIntegrationSummary", x => x.Cat_PayrollIntegrationSummaryId);
                    table.ForeignKey(
                        name: "FK_Cat_PayrollIntegrationSummary_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cat_PayrollIntegrationSummary_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cat_PayrollIntegrationSummary_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PayrollIntegration_Settings_AccId",
                table: "Cat_PayrollIntegration_Settings",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PayrollIntegrationSummary_AccId",
                table: "Cat_PayrollIntegrationSummary",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PayrollIntegrationSummary_FiscalMonthId",
                table: "Cat_PayrollIntegrationSummary",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PayrollIntegrationSummary_FiscalYearId",
                table: "Cat_PayrollIntegrationSummary",
                column: "FiscalYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_PayrollIntegration_Settings");

            migrationBuilder.DropTable(
                name: "Cat_PayrollIntegrationSummary");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "HR_ReportType",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
