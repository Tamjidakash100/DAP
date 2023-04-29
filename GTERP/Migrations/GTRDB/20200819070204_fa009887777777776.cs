using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fa009887777777776 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Emp_InfoEmpId",
                table: "FA_Details",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FA_Details_Emp_InfoEmpId",
                table: "FA_Details",
                column: "Emp_InfoEmpId");

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
                name: "FK_FA_Details_HR_Emp_Info_Emp_InfoEmpId",
                table: "FA_Details");

            migrationBuilder.DropIndex(
                name: "IX_FA_Details_Emp_InfoEmpId",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "Emp_InfoEmpId",
                table: "FA_Details");
        }
    }
}
