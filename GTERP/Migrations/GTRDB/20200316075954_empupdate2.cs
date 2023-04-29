using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class empupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpInfo_Cat_District_EmpCurrDistId",
                table: "HrEmpInfo");

            migrationBuilder.AlterColumn<int>(
                name: "EmpCurrDistId",
                table: "HrEmpInfo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpInfo_Cat_District_EmpCurrDistId",
                table: "HrEmpInfo",
                column: "EmpCurrDistId",
                principalTable: "Cat_District",
                principalColumn: "DistId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpInfo_Cat_District_EmpCurrDistId",
                table: "HrEmpInfo");

            migrationBuilder.AlterColumn<int>(
                name: "EmpCurrDistId",
                table: "HrEmpInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpInfo_Cat_District_EmpCurrDistId",
                table: "HrEmpInfo",
                column: "EmpCurrDistId",
                principalTable: "Cat_District",
                principalColumn: "DistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
