using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class newtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentStatus",
                table: "Tem_FA_Details");

            migrationBuilder.DropColumn(
                name: "PurchseDate",
                table: "Tem_FA_Details");

            migrationBuilder.AlterColumn<int>(
                name: "AssignTo",
                table: "Tem_FA_Details",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "AccumulatedDepreciatedValue",
                table: "Tem_FA_Details",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "AssignToDept",
                table: "Tem_FA_Details",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FA_Dep_StatusId",
                table: "Tem_FA_Details",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "Tem_FA_Details",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "WrittenDownValue",
                table: "Tem_FA_Details",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ManualSRRDate",
                table: "IssueMain",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccumulatedDepreciatedValue",
                table: "Tem_FA_Details");

            migrationBuilder.DropColumn(
                name: "AssignToDept",
                table: "Tem_FA_Details");

            migrationBuilder.DropColumn(
                name: "FA_Dep_StatusId",
                table: "Tem_FA_Details");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "Tem_FA_Details");

            migrationBuilder.DropColumn(
                name: "WrittenDownValue",
                table: "Tem_FA_Details");

            migrationBuilder.AlterColumn<int>(
                name: "AssignTo",
                table: "Tem_FA_Details",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentStatus",
                table: "Tem_FA_Details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchseDate",
                table: "Tem_FA_Details",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ManualSRRDate",
                table: "IssueMain",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
