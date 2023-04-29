using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class billupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ConfessionAmount",
                table: "Bill_Sub",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<float>(
                name: "ConfessionPercentage",
                table: "Bill_Sub",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<double>(
                name: "ElectricityAmount",
                table: "Bill_Sub",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LDAmount",
                table: "Bill_Sub",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<float>(
                name: "LDPercentage",
                table: "Bill_Sub",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<double>(
                name: "ReturnAmount",
                table: "Bill_Sub",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WFAmount",
                table: "Bill_Sub",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<float>(
                name: "WFPercentage",
                table: "Bill_Sub",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfessionAmount",
                table: "Bill_Sub");

            migrationBuilder.DropColumn(
                name: "ConfessionPercentage",
                table: "Bill_Sub");

            migrationBuilder.DropColumn(
                name: "ElectricityAmount",
                table: "Bill_Sub");

            migrationBuilder.DropColumn(
                name: "LDAmount",
                table: "Bill_Sub");

            migrationBuilder.DropColumn(
                name: "LDPercentage",
                table: "Bill_Sub");

            migrationBuilder.DropColumn(
                name: "ReturnAmount",
                table: "Bill_Sub");

            migrationBuilder.DropColumn(
                name: "WFAmount",
                table: "Bill_Sub");

            migrationBuilder.DropColumn(
                name: "WFPercentage",
                table: "Bill_Sub");
        }
    }
}
