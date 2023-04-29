using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class incrementupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "NewHRExp",
                table: "HR_Emp_Increment",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OldHRExp",
                table: "HR_Emp_Increment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewHRExp",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "OldHRExp",
                table: "HR_Emp_Increment");
        }
    }
}
