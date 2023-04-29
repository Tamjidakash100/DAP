using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class rmIndexSW : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_SummerWinterAllowance_Cat_SummerWinterAllowanceSetting_Cat_SWSettingSWAllowanceId",
                table: "HR_SummerWinterAllowance");

            migrationBuilder.DropIndex(
                name: "IX_HR_SummerWinterAllowance_Cat_SWSettingSWAllowanceId",
                table: "HR_SummerWinterAllowance");

            migrationBuilder.DropColumn(
                name: "Cat_SWSettingSWAllowanceId",
                table: "HR_SummerWinterAllowance");

            migrationBuilder.DropColumn(
                name: "SWSettingId",
                table: "HR_SummerWinterAllowance");

            migrationBuilder.DropColumn(
                name: "dtMonth",
                table: "Cat_SummerWinterAllowanceSetting");

            migrationBuilder.AddColumn<string>(
                name: "ProssType",
                table: "Cat_SummerWinterAllowanceSetting",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProssType",
                table: "Cat_SummerWinterAllowanceSetting");

            migrationBuilder.AddColumn<int>(
                name: "Cat_SWSettingSWAllowanceId",
                table: "HR_SummerWinterAllowance",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SWSettingId",
                table: "HR_SummerWinterAllowance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "dtMonth",
                table: "Cat_SummerWinterAllowanceSetting",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_HR_SummerWinterAllowance_Cat_SWSettingSWAllowanceId",
                table: "HR_SummerWinterAllowance",
                column: "Cat_SWSettingSWAllowanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_SummerWinterAllowance_Cat_SummerWinterAllowanceSetting_Cat_SWSettingSWAllowanceId",
                table: "HR_SummerWinterAllowance",
                column: "Cat_SWSettingSWAllowanceId",
                principalTable: "Cat_SummerWinterAllowanceSetting",
                principalColumn: "SWAllowanceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
