using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class DecimalErrorTesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChartOfAccount_ChartOfAccount_ParentID",
                table: "ChartOfAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPaymentSubs_ChartOfAccount_vChartofAccountsAccId",
                table: "SalesPaymentSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherSubs_ChartOfAccount_ChartOfAccountAccId",
                table: "VoucherSubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChartOfAccount",
                table: "ChartOfAccount");

            migrationBuilder.RenameTable(
                name: "ChartOfAccount",
                newName: "ChartOfAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_ChartOfAccount_ParentID",
                table: "ChartOfAccounts",
                newName: "IX_ChartOfAccounts_ParentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChartOfAccounts",
                table: "ChartOfAccounts",
                column: "AccId");

            migrationBuilder.CreateTable(
                name: "HR_Loan_HouseBuilding",
                columns: table => new
                {
                    LoanHouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    EmpId = table.Column<int>(nullable: true),
                    LoanType = table.Column<string>(maxLength: 50, nullable: true),
                    DtLoanStart = table.Column<DateTime>(nullable: false),
                    DtLoanEnd = table.Column<DateTime>(nullable: false),
                    LoanAmount = table.Column<decimal>(nullable: true),
                    LoanTerm = table.Column<float>(nullable: false),
                    InterestRate = table.Column<float>(nullable: false),
                    Compound = table.Column<string>(maxLength: 50, nullable: true),
                    PayBack = table.Column<string>(maxLength: 50, nullable: true),
                    MonthlyLoanAmount = table.Column<decimal>(nullable: true),
                    MonthlyInterest = table.Column<decimal>(nullable: true),
                    TotalLoanAmount = table.Column<decimal>(nullable: true),
                    TotalInterest = table.Column<decimal>(nullable: true),
                    Isinactive = table.Column<bool>(nullable: false),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtTran = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Loan_HouseBuilding", x => x.LoanHouseId);
                    table.ForeignKey(
                        name: "FK_HR_Loan_HouseBuilding_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_Loan_Data_HouseBuilding",
                columns: table => new
                {
                    LoanDataHouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    LoanHouseId = table.Column<int>(nullable: true),
                    EmpId = table.Column<int>(nullable: true),
                    DtLoanMonth = table.Column<DateTime>(nullable: false),
                    BeginningLoanBalance = table.Column<decimal>(nullable: true),
                    InterestAmount = table.Column<decimal>(nullable: true),
                    PrincipalAmount = table.Column<decimal>(nullable: true),
                    MonthlyLoanAmount = table.Column<decimal>(nullable: true),
                    EndingBalance = table.Column<decimal>(nullable: true),
                    IsPaid = table.Column<bool>(nullable: false),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtTran = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Loan_Data_HouseBuilding", x => x.LoanDataHouseId);
                    table.ForeignKey(
                        name: "FK_HR_Loan_Data_HouseBuilding_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Loan_Data_HouseBuilding_HR_Loan_HouseBuilding_LoanHouseId",
                        column: x => x.LoanHouseId,
                        principalTable: "HR_Loan_HouseBuilding",
                        principalColumn: "LoanHouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_Data_HouseBuilding_EmpId",
                table: "HR_Loan_Data_HouseBuilding",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_Data_HouseBuilding_LoanHouseId",
                table: "HR_Loan_Data_HouseBuilding",
                column: "LoanHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loan_HouseBuilding_EmpId",
                table: "HR_Loan_HouseBuilding",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChartOfAccounts_ChartOfAccounts_ParentID",
                table: "ChartOfAccounts",
                column: "ParentID",
                principalTable: "ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPaymentSubs_ChartOfAccounts_vChartofAccountsAccId",
                table: "SalesPaymentSubs",
                column: "vChartofAccountsAccId",
                principalTable: "ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherSubs_ChartOfAccounts_ChartOfAccountAccId",
                table: "VoucherSubs",
                column: "ChartOfAccountAccId",
                principalTable: "ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChartOfAccounts_ChartOfAccounts_ParentID",
                table: "ChartOfAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPaymentSubs_ChartOfAccounts_vChartofAccountsAccId",
                table: "SalesPaymentSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherSubs_ChartOfAccounts_ChartOfAccountAccId",
                table: "VoucherSubs");

            migrationBuilder.DropTable(
                name: "HR_Loan_Data_HouseBuilding");

            migrationBuilder.DropTable(
                name: "HR_Loan_HouseBuilding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChartOfAccounts",
                table: "ChartOfAccounts");

            migrationBuilder.RenameTable(
                name: "ChartOfAccounts",
                newName: "ChartOfAccount");

            migrationBuilder.RenameIndex(
                name: "IX_ChartOfAccounts_ParentID",
                table: "ChartOfAccount",
                newName: "IX_ChartOfAccount_ParentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChartOfAccount",
                table: "ChartOfAccount",
                column: "AccId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChartOfAccount_ChartOfAccount_ParentID",
                table: "ChartOfAccount",
                column: "ParentID",
                principalTable: "ChartOfAccount",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPaymentSubs_ChartOfAccount_vChartofAccountsAccId",
                table: "SalesPaymentSubs",
                column: "vChartofAccountsAccId",
                principalTable: "ChartOfAccount",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherSubs_ChartOfAccount_ChartOfAccountAccId",
                table: "VoucherSubs",
                column: "ChartOfAccountAccId",
                principalTable: "ChartOfAccount",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
