using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuleClassa",
                table: "ModuleMenus");

            migrationBuilder.DropColumn(
                name: "ModuleClassi",
                table: "ModuleMenus");

            migrationBuilder.AddColumn<string>(
                name: "ModuleClassa",
                table: "Modules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModuleClassi",
                table: "Modules",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuleClassa",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ModuleClassi",
                table: "Modules");

            migrationBuilder.AddColumn<string>(
                name: "ModuleClassa",
                table: "ModuleMenus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModuleClassi",
                table: "ModuleMenus",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
