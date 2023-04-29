using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class empinfoupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Command",
                table: "SalaryProcess",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtLocalJoin",
                table: "HR_Emp_Info",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAllowOT",
                table: "HR_Emp_Info",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Command",
                table: "SalaryProcess");

            migrationBuilder.DropColumn(
                name: "DtLocalJoin",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "IsAllowOT",
                table: "HR_Emp_Info");
        }
    }
}
