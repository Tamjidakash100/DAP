using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class prdupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BagQty",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "SeedQty",
                table: "Production");

            migrationBuilder.AddColumn<float>(
                name: "DailyBagQty",
                table: "Production",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "DailySeedQty",
                table: "Production",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MonthlyBagQty",
                table: "Production",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MonthlySeedQty",
                table: "Production",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "YearlyBagQty",
                table: "Production",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "YearlySeedQty",
                table: "Production",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyBagQty",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "DailySeedQty",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "MonthlyBagQty",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "MonthlySeedQty",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "YearlyBagQty",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "YearlySeedQty",
                table: "Production");

            migrationBuilder.AddColumn<float>(
                name: "BagQty",
                table: "Production",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SeedQty",
                table: "Production",
                type: "real",
                nullable: true);
        }
    }
}
