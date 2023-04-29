using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class menuclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModuleMenuClass",
                table: "ModuleMenus",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SLNo",
                table: "DownTimeReason",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SLNoB",
                table: "DownTimeReason",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuleMenuClass",
                table: "ModuleMenus");

            migrationBuilder.DropColumn(
                name: "SLNo",
                table: "DownTimeReason");

            migrationBuilder.DropColumn(
                name: "SLNoB",
                table: "DownTimeReason");
        }
    }
}
