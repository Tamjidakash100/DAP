using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class uBI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_AccountType_AccTypeId",
                table: "HR_Emp_BankInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_Bank_BankId",
                table: "HR_Emp_BankInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_BankBranch_BranchId",
                table: "HR_Emp_BankInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_PayMode_PayModeId",
                table: "HR_Emp_BankInfo");

            migrationBuilder.AlterColumn<int>(
                name: "PayModeId",
                table: "HR_Emp_BankInfo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "HR_Emp_BankInfo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BankId",
                table: "HR_Emp_BankInfo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AccTypeId",
                table: "HR_Emp_BankInfo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_AccountType_AccTypeId",
                table: "HR_Emp_BankInfo",
                column: "AccTypeId",
                principalTable: "Cat_AccountType",
                principalColumn: "AccTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_Bank_BankId",
                table: "HR_Emp_BankInfo",
                column: "BankId",
                principalTable: "Cat_Bank",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_BankBranch_BranchId",
                table: "HR_Emp_BankInfo",
                column: "BranchId",
                principalTable: "Cat_BankBranch",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_PayMode_PayModeId",
                table: "HR_Emp_BankInfo",
                column: "PayModeId",
                principalTable: "Cat_PayMode",
                principalColumn: "PayModeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_AccountType_AccTypeId",
                table: "HR_Emp_BankInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_Bank_BankId",
                table: "HR_Emp_BankInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_BankBranch_BranchId",
                table: "HR_Emp_BankInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_PayMode_PayModeId",
                table: "HR_Emp_BankInfo");

            migrationBuilder.AlterColumn<int>(
                name: "PayModeId",
                table: "HR_Emp_BankInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "HR_Emp_BankInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BankId",
                table: "HR_Emp_BankInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccTypeId",
                table: "HR_Emp_BankInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_AccountType_AccTypeId",
                table: "HR_Emp_BankInfo",
                column: "AccTypeId",
                principalTable: "Cat_AccountType",
                principalColumn: "AccTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_Bank_BankId",
                table: "HR_Emp_BankInfo",
                column: "BankId",
                principalTable: "Cat_Bank",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_BankBranch_BranchId",
                table: "HR_Emp_BankInfo",
                column: "BranchId",
                principalTable: "Cat_BankBranch",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_BankInfo_Cat_PayMode_PayModeId",
                table: "HR_Emp_BankInfo",
                column: "PayModeId",
                principalTable: "Cat_PayMode",
                principalColumn: "PayModeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
