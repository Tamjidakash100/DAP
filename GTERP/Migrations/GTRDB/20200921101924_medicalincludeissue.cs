using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class medicalincludeissue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Advice",
                table: "IssueMain",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BP",
                table: "IssueMain",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "IssueMain",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "IssueMain",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patient",
                table: "IssueMain",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Pulse",
                table: "IssueMain",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "IssueMain",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_DoctorId",
                table: "IssueMain",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_EmpId",
                table: "IssueMain",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueMain_HR_Emp_Info_DoctorId",
                table: "IssueMain",
                column: "DoctorId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueMain_HR_Emp_Info_EmpId",
                table: "IssueMain",
                column: "EmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueMain_HR_Emp_Info_DoctorId",
                table: "IssueMain");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueMain_HR_Emp_Info_EmpId",
                table: "IssueMain");

            migrationBuilder.DropIndex(
                name: "IX_IssueMain_DoctorId",
                table: "IssueMain");

            migrationBuilder.DropIndex(
                name: "IX_IssueMain_EmpId",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "Advice",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "BP",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "Patient",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "Pulse",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "IssueMain");
        }
    }
}
