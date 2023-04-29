using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class TotalPriceInwords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InWordsBng",
                table: "DeliveryOrder");

            migrationBuilder.DropColumn(
                name: "InWordsEng",
                table: "DeliveryOrder");

            migrationBuilder.AddColumn<string>(
                name: "QtyInWordsBng",
                table: "DeliveryOrder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QtyInWordsEng",
                table: "DeliveryOrder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalPriceInWordsBng",
                table: "DeliveryOrder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalPriceInWordsEng",
                table: "DeliveryOrder",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtyInWordsBng",
                table: "DeliveryOrder");

            migrationBuilder.DropColumn(
                name: "QtyInWordsEng",
                table: "DeliveryOrder");

            migrationBuilder.DropColumn(
                name: "TotalPriceInWordsBng",
                table: "DeliveryOrder");

            migrationBuilder.DropColumn(
                name: "TotalPriceInWordsEng",
                table: "DeliveryOrder");

            migrationBuilder.AddColumn<string>(
                name: "InWordsBng",
                table: "DeliveryOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InWordsEng",
                table: "DeliveryOrder",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
