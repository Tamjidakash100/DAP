using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class persionalinfoupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PFMember",
                table: "HR_Emp_PersonalInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PFMember",
                table: "HR_Emp_PersonalInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
