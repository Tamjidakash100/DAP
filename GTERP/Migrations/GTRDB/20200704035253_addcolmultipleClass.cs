using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class addcolmultipleClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCasual",
                table: "HR_Emp_Info",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "HR_Emp_Info",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalaryRange",
                table: "Cat_Grade",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TtlManpower",
                table: "Cat_Grade",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TtlManpower",
                table: "Cat_Emp_Type",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TtlManpower",
                table: "Cat_Designation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCasual",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "Skill",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "SalaryRange",
                table: "Cat_Grade");

            migrationBuilder.DropColumn(
                name: "TtlManpower",
                table: "Cat_Grade");

            migrationBuilder.DropColumn(
                name: "TtlManpower",
                table: "Cat_Emp_Type");

            migrationBuilder.DropColumn(
                name: "TtlManpower",
                table: "Cat_Designation");
        }
    }
}
