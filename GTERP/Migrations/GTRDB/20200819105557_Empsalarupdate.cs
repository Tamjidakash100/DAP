using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Empsalarupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProssType",
                table: "HR_LvEncashment",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HBLId2",
                table: "HR_Emp_Salary",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HBLId3",
                table: "HR_Emp_Salary",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PFLLId2",
                table: "HR_Emp_Salary",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PFLLId3",
                table: "HR_Emp_Salary",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_HBLId2",
                table: "HR_Emp_Salary",
                column: "HBLId2");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_HBLId3",
                table: "HR_Emp_Salary",
                column: "HBLId3");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_PFLLId2",
                table: "HR_Emp_Salary",
                column: "PFLLId2");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_PFLLId3",
                table: "HR_Emp_Salary",
                column: "PFLLId3");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_HBLId2",
                table: "HR_Emp_Salary",
                column: "HBLId2",
                principalTable: "Cat_Location",
                principalColumn: "LId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_HBLId3",
                table: "HR_Emp_Salary",
                column: "HBLId3",
                principalTable: "Cat_Location",
                principalColumn: "LId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_PFLLId2",
                table: "HR_Emp_Salary",
                column: "PFLLId2",
                principalTable: "Cat_Location",
                principalColumn: "LId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_PFLLId3",
                table: "HR_Emp_Salary",
                column: "PFLLId3",
                principalTable: "Cat_Location",
                principalColumn: "LId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_HBLId2",
                table: "HR_Emp_Salary");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_HBLId3",
                table: "HR_Emp_Salary");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_PFLLId2",
                table: "HR_Emp_Salary");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Salary_Cat_Location_PFLLId3",
                table: "HR_Emp_Salary");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Salary_HBLId2",
                table: "HR_Emp_Salary");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Salary_HBLId3",
                table: "HR_Emp_Salary");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Salary_PFLLId2",
                table: "HR_Emp_Salary");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Salary_PFLLId3",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "ProssType",
                table: "HR_LvEncashment");

            migrationBuilder.DropColumn(
                name: "HBLId2",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "HBLId3",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "PFLLId2",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "PFLLId3",
                table: "HR_Emp_Salary");
        }
    }
}
