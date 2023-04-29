using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class lvaddcol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "HR_LvEncashment",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "NetAmount",
                table: "HR_LvEncashment",                
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stamp",
                table: "HR_LvEncashment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "HR_LvEncashment");

            migrationBuilder.DropColumn(
                name: "NetAmount",
                table: "HR_LvEncashment");

            migrationBuilder.DropColumn(
                name: "Stamp",
                table: "HR_LvEncashment");
        }
    }
}
