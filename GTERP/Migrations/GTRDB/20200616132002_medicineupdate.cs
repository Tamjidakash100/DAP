using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class medicineupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MedicineName",
                table: "Medical_Details",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "HRExpensesOther",
                table: "HR_Emp_Salary",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHRExpensesOther",
                table: "HR_Emp_Salary",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "HR_Emp_Document",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicineName",
                table: "Medical_Details");

            migrationBuilder.DropColumn(
                name: "HRExpensesOther",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "IsHRExpensesOther",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "HR_Emp_Document");
        }
    }
}
