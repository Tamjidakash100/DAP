using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class PurchasesubPurchaseid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseSubs_PurchaseMains_PurchaseMainPurchaseId",
                table: "PurchaseSubs");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseSubs_PurchaseMainPurchaseId",
                table: "PurchaseSubs");

            migrationBuilder.DropColumn(
                name: "PurchaseMainPurchaseId",
                table: "PurchaseSubs");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseSubs_PurchaseId",
                table: "PurchaseSubs",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseSubs_PurchaseMains_PurchaseId",
                table: "PurchaseSubs",
                column: "PurchaseId",
                principalTable: "PurchaseMains",
                principalColumn: "PurchaseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseSubs_PurchaseMains_PurchaseId",
                table: "PurchaseSubs");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseSubs_PurchaseId",
                table: "PurchaseSubs");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseMainPurchaseId",
                table: "PurchaseSubs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseSubs_PurchaseMainPurchaseId",
                table: "PurchaseSubs",
                column: "PurchaseMainPurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseSubs_PurchaseMains_PurchaseMainPurchaseId",
                table: "PurchaseSubs",
                column: "PurchaseMainPurchaseId",
                principalTable: "PurchaseMains",
                principalColumn: "PurchaseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
