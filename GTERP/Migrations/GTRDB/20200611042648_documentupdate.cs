using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class documentupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocLocation",
                table: "HR_Emp_Document");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "HR_Emp_Document",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "HR_Emp_Document",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "HR_Emp_Document");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "HR_Emp_Document");

            migrationBuilder.AddColumn<string>(
                name: "DocLocation",
                table: "HR_Emp_Document",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
