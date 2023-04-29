using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fahadCheckMigraionHimuProblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_AttFixed_Cat_AttStatus_Cat_AttStatusStatusId",
                table: "HR_AttFixed");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Payroll_SalaryAddition_Cat_Location_AddTypeId",
            //    table: "Payroll_SalaryAddition");

            //migrationBuilder.DropIndex(
            //    name: "IX_Payroll_SalaryAddition_AddTypeId",
            //    table: "Payroll_SalaryAddition");

            //migrationBuilder.DropIndex(
            //    name: "IX_HR_AttFixed_Cat_AttStatusStatusId",
            //    table: "HR_AttFixed");

            migrationBuilder.DropColumn(
                name: "CreditForeign",
                table: "VoucherSubs");

            migrationBuilder.DropColumn(
                name: "DebitForeign",
                table: "VoucherSubs");

            migrationBuilder.DropColumn(
                name: "TKCreditForeign",
                table: "VoucherSubs");

            migrationBuilder.DropColumn(
                name: "TKDebitForeign",
                table: "VoucherSubs");

            //migrationBuilder.DropColumn(
            //    name: "AddTypeId",
            //    table: "Payroll_SalaryAddition");

            //migrationBuilder.DropColumn(
            //    name: "DtOpBal",
            //    table: "HR_Leave_Balance");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companys_VoucherNoCreatedType_VoucherNoCreatedTypeId",
                table: "Companys");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherMains_PrdUnits_PrdUnitId",
                table: "VoucherMains");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Warehouses_ParentId",
                table: "Warehouses");

            migrationBuilder.DropTable(
                name: "Cat_Variable");

            migrationBuilder.DropTable(
                name: "HR_ProcessLock");

            migrationBuilder.DropTable(
                name: "PrdUnits");

            migrationBuilder.DropTable(
                name: "VoucherNoCreatedType");

            migrationBuilder.DropTable(
                name: "VoucherNoPrefixs");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_ParentId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_VoucherMains_PrdUnitId",
                table: "VoucherMains");

            migrationBuilder.DropIndex(
                name: "IX_Companys_VoucherNoCreatedTypeId",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "WhType",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "useridUpdate",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "VoucherTypeButtonClass",
                table: "VoucherTypes");

            migrationBuilder.DropColumn(
                name: "VoucherTypeClass",
                table: "VoucherTypes");

            migrationBuilder.DropColumn(
                name: "isSystem",
                table: "VoucherTypes");

            migrationBuilder.DropColumn(
                name: "Note3",
                table: "VoucherSubs");

            migrationBuilder.DropColumn(
                name: "Note4",
                table: "VoucherSubs");

            migrationBuilder.DropColumn(
                name: "Note5",
                table: "VoucherSubs");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "VoucherSubs");

            migrationBuilder.DropColumn(
                name: "RowNo",
                table: "VoucherSubs");

            migrationBuilder.DropColumn(
                name: "TKCreditLocal",
                table: "VoucherSubs");

            migrationBuilder.DropColumn(
                name: "TKDebitLocal",
                table: "VoucherSubs");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "VoucherMains");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "VoucherMains");

            migrationBuilder.DropColumn(
                name: "PrdUnitId",
                table: "VoucherMains");

            migrationBuilder.DropColumn(
                name: "VoucherSerialId",
                table: "VoucherMains");

            migrationBuilder.DropColumn(
                name: "useridApprove",
                table: "VoucherMains");

            migrationBuilder.DropColumn(
                name: "useridCheck",
                table: "VoucherMains");

            migrationBuilder.DropColumn(
                name: "useridUpdate",
                table: "VoucherMains");

            migrationBuilder.DropColumn(
                name: "ProductSerialId",
                table: "PurchaseSubs");

            migrationBuilder.DropColumn(
                name: "RowNo",
                table: "PurchaseSubs");

            migrationBuilder.DropColumn(
                name: "SalesTypeId",
                table: "PurchaseSubs");

            migrationBuilder.DropColumn(
                name: "OtherAddType",
                table: "Payroll_SalaryAddition");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "FiscalYears");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "FiscalYears");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "FiscalYears");

            migrationBuilder.DropColumn(
                name: "useridUpdate",
                table: "FiscalYears");

            migrationBuilder.DropColumn(
                name: "MonthName",
                table: "FiscalMonths");

            migrationBuilder.DropColumn(
                name: "VoucherNoCreatedTypeId",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "isChequeDetails",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "isMultiCurrency",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "isMultiDebitCredit",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "isVoucherDistributionEntry",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "AccSubId",
                table: "ChartOfAccount");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "ChartOfAccount");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "ChartOfAccount");

            migrationBuilder.DropColumn(
                name: "IsBankItem",
                table: "ChartOfAccount");

            migrationBuilder.DropColumn(
                name: "IsCashItem",
                table: "ChartOfAccount");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "ChartOfAccount");

            migrationBuilder.DropColumn(
                name: "isItemInventory",
                table: "ChartOfAccount");

            migrationBuilder.DropColumn(
                name: "useridUpdate",
                table: "ChartOfAccount");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsInActive",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "comid",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "useridUpdate",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "comid",
                table: "Warehouses",
                newName: "ComId");

            migrationBuilder.RenameColumn(
                name: "comid",
                table: "VoucherMains",
                newName: "ComId");

            migrationBuilder.RenameColumn(
                name: "comid",
                table: "FiscalYears",
                newName: "ComId");

            migrationBuilder.RenameColumn(
                name: "comid",
                table: "ChartOfAccount",
                newName: "ComId");

            migrationBuilder.AddColumn<double>(
                name: "CreditForeign",
                table: "VoucherSubs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DebitForeign",
                table: "VoucherSubs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TKCreditForeign",
                table: "VoucherSubs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TKDebitForeign",
                table: "VoucherSubs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "VoucherMains",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComId",
                table: "VoucherMains",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateByUserId",
                table: "Payroll_SalaryAddition",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DtJoin",
                table: "Payroll_SalaryAddition",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "DtInput",
                table: "Payroll_SalaryAddition",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "AddTypeId",
                table: "Payroll_SalaryAddition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtOpBal",
                table: "HR_Leave_Balance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "LvType",
                table: "HR_Leave_Avail",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "LvApp",
                table: "HR_Leave_Avail",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtInput",
                table: "HR_Leave_Avail",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cat_AttStatusStatusId",
                table: "HR_AttFixed",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "isWorking",
                table: "FiscalYears",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "isRunning",
                table: "FiscalYears",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "ComId",
                table: "FiscalYears",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonName",
                table: "FiscalMonths",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComId",
                table: "Companys",
                type: "int",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "vCompanyComId",
                table: "CompanyPermissions",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComId",
                table: "ChartOfAccount",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OpDebitLocal",
                table: "ChartOfAccount",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "OpDebit",
                table: "ChartOfAccount",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "OpCreditLocal",
                table: "ChartOfAccount",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "OpCredit",
                table: "ChartOfAccount",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.CreateIndex(
                name: "IX_Payroll_SalaryAddition_AddTypeId",
                table: "Payroll_SalaryAddition",
                column: "AddTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_AttFixed_Cat_AttStatusStatusId",
                table: "HR_AttFixed",
                column: "Cat_AttStatusStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_AttFixed_Cat_AttStatus_Cat_AttStatusStatusId",
                table: "HR_AttFixed",
                column: "Cat_AttStatusStatusId",
                principalTable: "Cat_AttStatus",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payroll_SalaryAddition_Cat_Location_AddTypeId",
                table: "Payroll_SalaryAddition",
                column: "AddTypeId",
                principalTable: "Cat_Location",
                principalColumn: "LId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
