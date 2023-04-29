using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class iscreatoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRereation",
                table: "HR_Emp_Recreation");

            migrationBuilder.AddColumn<bool>(
                name: "IsRecreation",
                table: "HR_Emp_Recreation",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRecreation",
                table: "HR_Emp_Recreation");

            migrationBuilder.AddColumn<bool>(
                name: "IsRereation",
                table: "HR_Emp_Recreation",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
