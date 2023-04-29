using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class incupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "HRExpOtherDiff",
                table: "HR_Emp_Increment",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NewHRExpOther",
                table: "HR_Emp_Increment",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OldHRExpOther",
                table: "HR_Emp_Increment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HRExpOtherDiff",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "NewHRExpOther",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "OldHRExpOther",
                table: "HR_Emp_Increment");
        }
    }
}
