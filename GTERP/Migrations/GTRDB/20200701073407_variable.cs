using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class variable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VarType",
                table: "HR_Emp_Document",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComId",
                table: "DeliveryChallan",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "DeliveryChallan",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "DeliveryChallan",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "DeliveryChallan",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DeliveryChallan",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Cat_Variable",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Cat_Variable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Cat_Variable",
                maxLength: 80,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VarType",
                table: "HR_Emp_Document");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "DeliveryChallan");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "DeliveryChallan");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "DeliveryChallan");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "DeliveryChallan");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DeliveryChallan");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Cat_Variable");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Cat_Variable");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Cat_Variable");
        }
    }
}
