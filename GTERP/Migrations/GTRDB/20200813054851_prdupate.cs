using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class prdupate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionQty",
                table: "Production");

            migrationBuilder.AddColumn<float>(
                name: "BagQty",
                table: "Production",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "DOBalance",
                table: "Production",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SeedQty",
                table: "Production",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BagQty",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "DOBalance",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "SeedQty",
                table: "Production");

            migrationBuilder.AddColumn<float>(
                name: "ProductionQty",
                table: "Production",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
