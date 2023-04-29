using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class billmanageupdatemain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalConfessionAmount",
                table: "Bill_Main",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalElectricityAmount",
                table: "Bill_Main",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalLDAmount",
                table: "Bill_Main",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalReturnAmount",
                table: "Bill_Main",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalWFAmount",
                table: "Bill_Main",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalConfessionAmount",
                table: "Bill_Main");

            migrationBuilder.DropColumn(
                name: "TotalElectricityAmount",
                table: "Bill_Main");

            migrationBuilder.DropColumn(
                name: "TotalLDAmount",
                table: "Bill_Main");

            migrationBuilder.DropColumn(
                name: "TotalReturnAmount",
                table: "Bill_Main");

            migrationBuilder.DropColumn(
                name: "TotalWFAmount",
                table: "Bill_Main");
        }
    }
}
