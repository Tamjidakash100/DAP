using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fa00986876767 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "AssignTo",
                table: "FA_Details",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FA_Details_HR_Emp_Info_AssignTo",
                table: "FA_Details");

            migrationBuilder.DropIndex(
                name: "IX_FA_Details_AssignTo",
                table: "FA_Details");

            migrationBuilder.AlterColumn<int>(
                name: "AssignTo",
                table: "FA_Details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Emp_InfoEmpId",
                table: "FA_Details",
                type: "int",
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
    }
}
