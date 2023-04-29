using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class addIndexSW : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SWAllowanceId",
                table: "HR_SummerWinterAllowance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HR_SummerWinterAllowance_SWAllowanceId",
                table: "HR_SummerWinterAllowance",
                column: "SWAllowanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_SummerWinterAllowance_Cat_SummerWinterAllowanceSetting_SWAllowanceId",
                table: "HR_SummerWinterAllowance",
                column: "SWAllowanceId",
                principalTable: "Cat_SummerWinterAllowanceSetting",
                principalColumn: "SWAllowanceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_SummerWinterAllowance_Cat_SummerWinterAllowanceSetting_SWAllowanceId",
                table: "HR_SummerWinterAllowance");

            migrationBuilder.DropIndex(
                name: "IX_HR_SummerWinterAllowance_SWAllowanceId",
                table: "HR_SummerWinterAllowance");

            migrationBuilder.DropColumn(
                name: "SWAllowanceId",
                table: "HR_SummerWinterAllowance");
        }
    }
}
