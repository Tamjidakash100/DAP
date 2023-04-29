using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class prductionsales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "DailySalesBagQty",
                table: "Production",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "DailySalesSeedQty",
                table: "Production",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MonthlySalesBagQty",
                table: "Production",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MonthlySalesSeedQty",
                table: "Production",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "YearlySalesBagQty",
                table: "Production",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "YearlySalesSeedQty",
                table: "Production",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailySalesBagQty",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "DailySalesSeedQty",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "MonthlySalesBagQty",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "MonthlySalesSeedQty",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "YearlySalesBagQty",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "YearlySalesSeedQty",
                table: "Production");
        }
    }
}
