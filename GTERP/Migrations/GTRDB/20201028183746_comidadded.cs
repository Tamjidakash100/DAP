using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class comidadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Acc_VoucherSubChecnos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Acc_VoucherSubChecnos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "comid",
                table: "Acc_VoucherSubChecnos",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isManualEntry",
                table: "Acc_VoucherSubChecnos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "userid",
                table: "Acc_VoucherSubChecnos",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "useridApprove",
                table: "Acc_VoucherSubChecnos",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "useridCheck",
                table: "Acc_VoucherSubChecnos",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "useridUpdate",
                table: "Acc_VoucherSubChecnos",
                maxLength: 128,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.DropColumn(
                name: "comid",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.DropColumn(
                name: "isManualEntry",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.DropColumn(
                name: "useridApprove",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.DropColumn(
                name: "useridCheck",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.DropColumn(
                name: "useridUpdate",
                table: "Acc_VoucherSubChecnos");
        }
    }
}
