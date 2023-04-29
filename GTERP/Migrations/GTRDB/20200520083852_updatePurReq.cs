using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class updatePurReq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComId",
                table: "Purpose",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Purpose",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Purpose",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Purpose",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Purpose",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Purpose",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComId",
                table: "PurchaseRequisitionSub",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "PurchaseRequisitionSub",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "PurchaseRequisitionSub",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "PurchaseRequisitionSub",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "PurchaseRequisitionSub",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PurchaseRequisitionSub",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PRNo",
                table: "PurchaseRequisitionMain",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComId",
                table: "PurchaseRequisitionMain",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "PurchaseRequisitionMain",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "PurchaseRequisitionMain",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "PurchaseRequisitionMain",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "PurchaseRequisitionMain",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PurchaseRequisitionMain",
                maxLength: 80,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Purpose");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Purpose");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Purpose");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Purpose");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Purpose");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Purpose");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "PurchaseRequisitionSub");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "PurchaseRequisitionSub");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "PurchaseRequisitionSub");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "PurchaseRequisitionSub");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "PurchaseRequisitionSub");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PurchaseRequisitionSub");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PurchaseRequisitionMain");

            migrationBuilder.AlterColumn<int>(
                name: "PRNo",
                table: "PurchaseRequisitionMain",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
