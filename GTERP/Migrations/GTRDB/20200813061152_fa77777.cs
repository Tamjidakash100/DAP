using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fa77777 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentStatus",
                table: "FA_Details",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInActive",
                table: "FA_Details",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentStatus",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "IsInActive",
                table: "FA_Details");
        }
    }
}
