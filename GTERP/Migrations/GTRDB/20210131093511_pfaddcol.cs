using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class pfaddcol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmmoniaReceiving",
                table: "IssueMain");

            migrationBuilder.AddColumn<string>(
                name: "AmmoniaReceivingCapco",
                table: "IssueMain",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AmmoniaReceivingCufl",
                table: "IssueMain",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GratuityFinalYId",
                table: "HR_Emp_PersonalInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GratuityFundTransferYId",
                table: "HR_Emp_PersonalInfo",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsGratuityFinal",
                table: "HR_Emp_PersonalInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGratuityFundTransfer",
                table: "HR_Emp_PersonalInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPFFinal",
                table: "HR_Emp_PersonalInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPFFundTransfer",
                table: "HR_Emp_PersonalInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWFFinal",
                table: "HR_Emp_PersonalInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWFFundTransfer",
                table: "HR_Emp_PersonalInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PFFinalYId",
                table: "HR_Emp_PersonalInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PFFundTransferYId",
                table: "HR_Emp_PersonalInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WFFinalYId",
                table: "HR_Emp_PersonalInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WFFundTransferYId",
                table: "HR_Emp_PersonalInfo",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "IncomeTax",
                table: "HR_Emp_ArrearBill",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "LastMonthDays",
                table: "HR_Emp_ArrearBill",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "NewWashingAllow",
                table: "HR_Emp_ArrearBill",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "OldWashingAllow",
                table: "HR_Emp_ArrearBill",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PFAdd",
                table: "HR_Emp_ArrearBill",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "WashingAllowDiff",
                table: "HR_Emp_ArrearBill",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ttlArrearWashingAllow",
                table: "HR_Emp_ArrearBill",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostPrice",
                table: "fA_Sells",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_GratuityFinalYId",
                table: "HR_Emp_PersonalInfo",
                column: "GratuityFinalYId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_GratuityFundTransferYId",
                table: "HR_Emp_PersonalInfo",
                column: "GratuityFundTransferYId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_PFFinalYId",
                table: "HR_Emp_PersonalInfo",
                column: "PFFinalYId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_PFFundTransferYId",
                table: "HR_Emp_PersonalInfo",
                column: "PFFundTransferYId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_WFFinalYId",
                table: "HR_Emp_PersonalInfo",
                column: "WFFinalYId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_WFFundTransferYId",
                table: "HR_Emp_PersonalInfo",
                column: "WFFundTransferYId");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYears_GratuityFinalYId",
                table: "HR_Emp_PersonalInfo",
                column: "GratuityFinalYId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYears_GratuityFundTransferYId",
                table: "HR_Emp_PersonalInfo",
                column: "GratuityFundTransferYId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYears_PFFinalYId",
                table: "HR_Emp_PersonalInfo",
                column: "PFFinalYId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYears_PFFundTransferYId",
                table: "HR_Emp_PersonalInfo",
                column: "PFFundTransferYId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYears_WFFinalYId",
                table: "HR_Emp_PersonalInfo",
                column: "WFFinalYId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYears_WFFundTransferYId",
                table: "HR_Emp_PersonalInfo",
                column: "WFFundTransferYId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYears_GratuityFinalYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYears_GratuityFundTransferYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYears_PFFinalYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYears_PFFundTransferYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYears_WFFinalYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_PersonalInfo_Acc_FiscalYears_WFFundTransferYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_PersonalInfo_GratuityFinalYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_PersonalInfo_GratuityFundTransferYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_PersonalInfo_PFFinalYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_PersonalInfo_PFFundTransferYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_PersonalInfo_WFFinalYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_PersonalInfo_WFFundTransferYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "AmmoniaReceivingCapco",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "AmmoniaReceivingCufl",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "GratuityFinalYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "GratuityFundTransferYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "IsGratuityFinal",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "IsGratuityFundTransfer",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "IsPFFinal",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "IsPFFundTransfer",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "IsWFFinal",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "IsWFFundTransfer",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "PFFinalYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "PFFundTransferYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "WFFinalYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "WFFundTransferYId",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "IncomeTax",
                table: "HR_Emp_ArrearBill");

            migrationBuilder.DropColumn(
                name: "LastMonthDays",
                table: "HR_Emp_ArrearBill");

            migrationBuilder.DropColumn(
                name: "NewWashingAllow",
                table: "HR_Emp_ArrearBill");

            migrationBuilder.DropColumn(
                name: "OldWashingAllow",
                table: "HR_Emp_ArrearBill");

            migrationBuilder.DropColumn(
                name: "PFAdd",
                table: "HR_Emp_ArrearBill");

            migrationBuilder.DropColumn(
                name: "WashingAllowDiff",
                table: "HR_Emp_ArrearBill");

            migrationBuilder.DropColumn(
                name: "ttlArrearWashingAllow",
                table: "HR_Emp_ArrearBill");

            migrationBuilder.DropColumn(
                name: "CostPrice",
                table: "fA_Sells");

            migrationBuilder.AddColumn<string>(
                name: "AmmoniaReceiving",
                table: "IssueMain",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }
    }
}
