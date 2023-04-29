using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class SWUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProssType",
                table: "HR_SummerWinterAllowance");

            migrationBuilder.AddColumn<int>(
                name: "Cat_SWSettingSWAllowanceId",
                table: "HR_SummerWinterAllowance",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SWSettingId",
                table: "HR_SummerWinterAllowance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNo",
                table: "Cat_SummerWinterAllowanceSetting",
                maxLength: 40,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ReferenceNo",
                table: "Cat_SummerWinterAllowanceSetting");

            migrationBuilder.AddColumn<string>(
                name: "ProssType",
                table: "HR_SummerWinterAllowance",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);
        }
    }
}
