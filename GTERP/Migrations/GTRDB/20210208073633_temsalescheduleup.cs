using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class temsalescheduleup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SalesDate",
                table: "fA_Sells",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "fA_Sells",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "fA_Sells",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "fA_Sells",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "fA_Sells",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "fA_Sells",
                maxLength: 80,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "fA_Sells");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "fA_Sells");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "fA_Sells");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "fA_Sells");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "fA_Sells");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SalesDate",
                table: "fA_Sells",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
