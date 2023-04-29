using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class HR_Emp_Salary_Modification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Salary_HR_Emp_Info_EmpId",
                table: "HR_Emp_Salary");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_LId1",
                table: "HR_Emp_Salary");

            migrationBuilder.AlterColumn<int>(
                name: "LId1",
                table: "HR_Emp_Salary",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmpId",
                table: "HR_Emp_Salary",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<float>(
                name: "FoodAllow",
                table: "HR_Emp_Salary",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFa",
                table: "HR_Emp_Salary",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Salary_HR_Emp_Info_EmpId",
                table: "HR_Emp_Salary",
                column: "EmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_LId1",
                table: "HR_Emp_Salary",
                column: "LId1",
                principalTable: "Cat_Location",
                principalColumn: "LId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Salary_HR_Emp_Info_EmpId",
                table: "HR_Emp_Salary");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_LId1",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "FoodAllow",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "IsFa",
                table: "HR_Emp_Salary");

            migrationBuilder.AlterColumn<int>(
                name: "LId1",
                table: "HR_Emp_Salary",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpId",
                table: "HR_Emp_Salary",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Salary_HR_Emp_Info_EmpId",
                table: "HR_Emp_Salary",
                column: "EmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_LId1",
                table: "HR_Emp_Salary",
                column: "LId1",
                principalTable: "Cat_Location",
                principalColumn: "LId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
