using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class billadd4column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ForfeitureAmount",
                table: "Bill_Sub",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OthersAmount",
                table: "Bill_Sub",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalForfeitureAmount",
                table: "Bill_Main",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalOthersAmount",
                table: "Bill_Main",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForfeitureAmount",
                table: "Bill_Sub");

            migrationBuilder.DropColumn(
                name: "OthersAmount",
                table: "Bill_Sub");

            migrationBuilder.DropColumn(
                name: "TotalForfeitureAmount",
                table: "Bill_Main");

            migrationBuilder.DropColumn(
                name: "TotalOthersAmount",
                table: "Bill_Main");
        }
    }
}
