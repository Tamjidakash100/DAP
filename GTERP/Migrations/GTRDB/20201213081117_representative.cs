using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class representative : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FA_Details_HR_Emp_Info_AssignTo",
                table: "FA_Details");

            migrationBuilder.DropIndex(
                name: "IX_FA_Details_AssignTo",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "AssignTo",
                table: "FA_Details");

            migrationBuilder.AddColumn<int>(
                name: "AssignToSection",
                table: "FA_Details",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Emp_InfoEmpId",
                table: "FA_Details",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FA_Details_AssignToSection",
                table: "FA_Details",
                column: "AssignToSection");

            migrationBuilder.CreateIndex(
                name: "IX_FA_Details_Emp_InfoEmpId",
                table: "FA_Details",
                column: "Emp_InfoEmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_FA_Details_Cat_Section_AssignToSection",
                table: "FA_Details",
                column: "AssignToSection",
                principalTable: "Cat_Section",
                principalColumn: "SectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FA_Details_HR_Emp_Info_Emp_InfoEmpId",
                table: "FA_Details",
                column: "Emp_InfoEmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FA_Details_Cat_Section_AssignToSection",
                table: "FA_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_FA_Details_HR_Emp_Info_Emp_InfoEmpId",
                table: "FA_Details");

            migrationBuilder.DropIndex(
                name: "IX_FA_Details_AssignToSection",
                table: "FA_Details");

            migrationBuilder.DropIndex(
                name: "IX_FA_Details_Emp_InfoEmpId",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "AssignToSection",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "Emp_InfoEmpId",
                table: "FA_Details");

            migrationBuilder.AddColumn<int>(
                name: "AssignTo",
                table: "FA_Details",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FA_Details_AssignTo",
                table: "FA_Details",
                column: "AssignTo");

            migrationBuilder.AddForeignKey(
                name: "FK_FA_Details_HR_Emp_Info_AssignTo",
                table: "FA_Details",
                column: "AssignTo",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
