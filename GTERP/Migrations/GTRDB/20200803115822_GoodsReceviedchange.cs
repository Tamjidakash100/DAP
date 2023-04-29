using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class GoodsReceviedchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiveSub_PurchaseRequisitionSub_PurReqSubId",
                table: "GoodsReceiveSub");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiveSub_PurReqSubId",
                table: "GoodsReceiveSub");

            migrationBuilder.DropColumn(
                name: "PurOrderMainId",
                table: "GoodsReceiveSub");

            migrationBuilder.DropColumn(
                name: "PurReqSubId",
                table: "GoodsReceiveSub");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurOrderMainId",
                table: "GoodsReceiveSub",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurReqSubId",
                table: "GoodsReceiveSub",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveSub_PurReqSubId",
                table: "GoodsReceiveSub",
                column: "PurReqSubId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiveSub_PurchaseRequisitionSub_PurReqSubId",
                table: "GoodsReceiveSub",
                column: "PurReqSubId",
                principalTable: "PurchaseRequisitionSub",
                principalColumn: "PurReqSubId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
