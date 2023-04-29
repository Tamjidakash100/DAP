using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class HR_IncTypeModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewEmpType",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "NewGrade",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "OldEmpType",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "OldGrade",
                table: "HR_Emp_Increment");

            migrationBuilder.AddColumn<int>(
                name: "NewEmpTypeId",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NewGenderId",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OldEmpTypeId",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OldGenderId",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_NewEmpTypeId",
                table: "HR_Emp_Increment",
                column: "NewEmpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_NewGenderId",
                table: "HR_Emp_Increment",
                column: "NewGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_OldEmpTypeId",
                table: "HR_Emp_Increment",
                column: "OldEmpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_OldGenderId",
                table: "HR_Emp_Increment",
                column: "OldGenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Emp_Type_NewEmpTypeId",
                table: "HR_Emp_Increment",
                column: "NewEmpTypeId",
                principalTable: "Cat_Emp_Type",
                principalColumn: "EmpTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Gender_NewGenderId",
                table: "HR_Emp_Increment",
                column: "NewGenderId",
                principalTable: "Cat_Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Emp_Type_OldEmpTypeId",
                table: "HR_Emp_Increment",
                column: "OldEmpTypeId",
                principalTable: "Cat_Emp_Type",
                principalColumn: "EmpTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Gender_OldGenderId",
                table: "HR_Emp_Increment",
                column: "OldGenderId",
                principalTable: "Cat_Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Emp_Type_NewEmpTypeId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Gender_NewGenderId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Emp_Type_OldEmpTypeId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_Cat_Gender_OldGenderId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Increment_NewEmpTypeId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Increment_NewGenderId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Increment_OldEmpTypeId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Increment_OldGenderId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "NewEmpTypeId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "NewGenderId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "OldEmpTypeId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "OldGenderId",
                table: "HR_Emp_Increment");

            migrationBuilder.AddColumn<string>(
                name: "NewEmpType",
                table: "HR_Emp_Increment",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewGrade",
                table: "HR_Emp_Increment",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OldEmpType",
                table: "HR_Emp_Increment",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OldGrade",
                table: "HR_Emp_Increment",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
