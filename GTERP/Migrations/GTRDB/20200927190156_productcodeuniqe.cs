using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class productcodeuniqe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiveSub_Products_ProductId",
                table: "GoodsReceiveSub");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "GoodsReceiveSub",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_comid_ProductCode",
                table: "Products",
                columns: new[] { "comid", "ProductCode" },
                unique: true,
                filter: "[ProductCode] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiveSub_Products_ProductId",
                table: "GoodsReceiveSub",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiveSub_Products_ProductId",
                table: "GoodsReceiveSub");

            migrationBuilder.DropIndex(
                name: "IX_Products_comid_ProductCode",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "GoodsReceiveSub",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiveSub_Products_ProductId",
                table: "GoodsReceiveSub",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
