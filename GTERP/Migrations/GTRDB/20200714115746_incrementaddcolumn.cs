using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class incrementaddcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "BSDiff",
                table: "HR_Emp_Increment",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "HRDiff",
                table: "HR_Emp_Increment",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "HRExpDiff",
                table: "HR_Emp_Increment",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MADiff",
                table: "HR_Emp_Increment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BSDiff",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "HRDiff",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "HRExpDiff",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "MADiff",
                table: "HR_Emp_Increment");
        }
    }
}
