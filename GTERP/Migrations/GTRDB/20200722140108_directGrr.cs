using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class directGrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "GoodsReceiveSub",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VatAmount",
                table: "GoodsReceiveSub",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VatParcent",
                table: "GoodsReceiveSub",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDirectGRR",
                table: "GoodsReceiveMain",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "GoodsReceiveSub");

            migrationBuilder.DropColumn(
                name: "VatAmount",
                table: "GoodsReceiveSub");

            migrationBuilder.DropColumn(
                name: "VatParcent",
                table: "GoodsReceiveSub");

            migrationBuilder.DropColumn(
                name: "IsDirectGRR",
                table: "GoodsReceiveMain");
        }
    }
}
