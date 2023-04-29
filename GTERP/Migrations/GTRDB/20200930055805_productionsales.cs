using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class productionsales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionBagQty",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "ProductionSeedQty",
                table: "IssueMain");

            migrationBuilder.AddColumn<float>(
                name: "ProductionBagQty",
                table: "IssueSub",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ProductionSeedQty",
                table: "IssueSub",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SalesBagQty",
                table: "IssueSub",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SalesSeedQty",
                table: "IssueSub",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionBagQty",
                table: "IssueSub");

            migrationBuilder.DropColumn(
                name: "ProductionSeedQty",
                table: "IssueSub");

            migrationBuilder.DropColumn(
                name: "SalesBagQty",
                table: "IssueSub");

            migrationBuilder.DropColumn(
                name: "SalesSeedQty",
                table: "IssueSub");

            migrationBuilder.AddColumn<float>(
                name: "ProductionBagQty",
                table: "IssueMain",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ProductionSeedQty",
                table: "IssueMain",
                type: "real",
                nullable: true);
        }
    }
}
