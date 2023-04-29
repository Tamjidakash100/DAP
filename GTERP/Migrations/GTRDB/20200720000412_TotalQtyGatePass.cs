using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class TotalQtyGatePass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TotalQty",
                table: "GatePass",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_GatePassSub_DeliveryChallanId",
                table: "GatePassSub",
                column: "DeliveryChallanId");

            migrationBuilder.AddForeignKey(
                name: "FK_GatePassSub_DeliveryChallan_DeliveryChallanId",
                table: "GatePassSub",
                column: "DeliveryChallanId",
                principalTable: "DeliveryChallan",
                principalColumn: "DeliveryChallanId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GatePassSub_DeliveryChallan_DeliveryChallanId",
                table: "GatePassSub");

            migrationBuilder.DropIndex(
                name: "IX_GatePassSub_DeliveryChallanId",
                table: "GatePassSub");

            migrationBuilder.DropColumn(
                name: "TotalQty",
                table: "GatePass");
        }
    }
}
