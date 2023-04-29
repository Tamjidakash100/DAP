using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GTERP.Migrations.GTRDB
{
    public partial class fahadCheckMigraionHimuProblem_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<bool>(
                name: "isWorking",
                table: "FiscalYears",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "isRunning",
                table: "FiscalYears",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "FiscalYears",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "FiscalYears",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "FiscalYears",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userid",
                table: "FiscalYears",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "useridUpdate",
                table: "FiscalYears",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthName",
                table: "FiscalMonths",
                nullable: true);

          

            migrationBuilder.AddColumn<int>(
                name: "VoucherNoCreatedTypeId",
                table: "Companys",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isChequeDetails",
                table: "Companys",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isMultiCurrency",
                table: "Companys",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isMultiDebitCredit",
                table: "Companys",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isVoucherDistributionEntry",
                table: "Companys",
                nullable: false,
                defaultValue: false);

         

            migrationBuilder.AlterColumn<float>(
                name: "OpDebitLocal",
                table: "ChartOfAccount",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "OpDebit",
                table: "ChartOfAccount",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "OpCreditLocal",
                table: "ChartOfAccount",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "OpCredit",
                table: "ChartOfAccount",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "ChartOfAccount",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AccSubId",
                table: "ChartOfAccount",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "ChartOfAccount",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "ChartOfAccount",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsBankItem",
                table: "ChartOfAccount",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsCashItem",
                table: "ChartOfAccount",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "ChartOfAccount",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "isItemInventory",
                table: "ChartOfAccount",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "useridUpdate",
                table: "ChartOfAccount",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInActive",
                table: "Categories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "comid",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userid",
                table: "Categories",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "useridUpdate",
                table: "Categories",
                maxLength: 128,
                nullable: true);



            migrationBuilder.CreateTable(
                name: "HR_ProcessLock",
                columns: table => new
                {
                    ProcessId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    LockType = table.Column<string>(maxLength: 50, nullable: true),
                    DtDate = table.Column<DateTime>(nullable: false),
                    IsLock = table.Column<bool>(nullable: false),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DtTran = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_ProcessLock", x => x.ProcessId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
