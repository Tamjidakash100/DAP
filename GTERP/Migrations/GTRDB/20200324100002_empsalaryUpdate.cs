using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class empsalaryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPurchaseAdv",
                table: "HR_Emp_Salary",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSiftAllow",
                table: "HR_Emp_Salary",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPurchaseAdv",
                table: "HR_Emp_Salary");

            migrationBuilder.DropColumn(
                name: "IsSiftAllow",
                table: "HR_Emp_Salary");
        }
    }
}
