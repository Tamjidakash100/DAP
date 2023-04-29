using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Salesmainchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ComId",
                table: "SalesMains",
                newName: "comid");

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "SalesMains",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "comid",
                table: "SalesMains",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "SalesMains",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "SalesMains",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "useridUpdate",
                table: "SalesMains",
                maxLength: 128,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "SalesMains");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "SalesMains");

            migrationBuilder.DropColumn(
                name: "useridUpdate",
                table: "SalesMains");

            migrationBuilder.RenameColumn(
                name: "comid",
                table: "SalesMains",
                newName: "ComId");

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "SalesMains",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "SalesMains",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);
        }
    }
}
