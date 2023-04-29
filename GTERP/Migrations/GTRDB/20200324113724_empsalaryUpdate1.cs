using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class empsalaryUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "HR_Emp_Salary",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "HR_Emp_Salary",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "HR_Emp_Salary",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "HR_Emp_Salary",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "HR_Emp_Salary",
                maxLength: 80,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HR_Emp_Salary");
        }
    }
}
