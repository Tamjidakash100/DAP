using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class assign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignTo",
                table: "Tem_FA_Details");

            migrationBuilder.AddColumn<int>(
                name: "AssignToSection",
                table: "Tem_FA_Details",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignToSection",
                table: "Tem_FA_Details");

            migrationBuilder.AddColumn<int>(
                name: "AssignTo",
                table: "Tem_FA_Details",
                type: "int",
                nullable: true);
        }
    }
}
