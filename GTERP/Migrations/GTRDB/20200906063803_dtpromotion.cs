using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class dtpromotion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DtPromotion",
                table: "HR_Emp_Info",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtPromotion",
                table: "HR_Emp_Increment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DtPromotion",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "DtPromotion",
                table: "HR_Emp_Increment");
        }
    }
}
