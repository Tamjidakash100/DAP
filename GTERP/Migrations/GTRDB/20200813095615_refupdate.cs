using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class refupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefferenceNo",
                table: "HR_Emp_Recreation");

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNo",
                table: "HR_Emp_Recreation",
                maxLength: 40,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceNo",
                table: "HR_Emp_Recreation");

            migrationBuilder.AddColumn<string>(
                name: "RefferenceNo",
                table: "HR_Emp_Recreation",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);
        }
    }
}
