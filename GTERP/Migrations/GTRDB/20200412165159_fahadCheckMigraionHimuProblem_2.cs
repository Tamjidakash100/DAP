using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GTERP.Migrations.GTRDB
{
    public partial class fahadCheckMigraionHimuProblem_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
              name: "MonName",
              table: "FiscalMonths");

            migrationBuilder.RenameColumn(
                name: "ComId",
                table: "Warehouses",
                newName: "comid");

            migrationBuilder.RenameColumn(
                name: "ComId",
                table: "VoucherMains",
                newName: "comid");

            migrationBuilder.RenameColumn(
                name: "ComId",
                table: "FiscalYears",
                newName: "comid");

            migrationBuilder.RenameColumn(
                name: "ComId",
                table: "ChartOfAccount",
                newName: "comid");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Warehouses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Warehouses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Warehouses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhType",
                table: "Warehouses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userid",
                table: "Warehouses",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "useridUpdate",
                table: "Warehouses",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoucherTypeButtonClass",
                table: "VoucherTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoucherTypeClass",
                table: "VoucherTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isSystem",
                table: "VoucherTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Note3",
                table: "VoucherSubs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note4",
                table: "VoucherSubs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note5",
                table: "VoucherSubs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefId",
                table: "VoucherSubs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowNo",
                table: "VoucherSubs",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TKCreditLocal",
                table: "VoucherSubs",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TKDebitLocal",
                table: "VoucherSubs",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "VoucherMains",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "VoucherMains",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "VoucherMains",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "VoucherMains",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrdUnitId",
                table: "VoucherMains",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoucherSerialId",
                table: "VoucherMains",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "useridApprove",
                table: "VoucherMains",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "useridCheck",
                table: "VoucherMains",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "useridUpdate",
                table: "VoucherMains",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductSerialId",
                table: "PurchaseSubs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowNo",
                table: "PurchaseSubs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
