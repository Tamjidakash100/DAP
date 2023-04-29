using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class gatepassnounique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InWordsBng",
                table: "DeliveryOrder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InWordsEng",
                table: "DeliveryOrder",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GatePass_ComId_GatePassNo",
                table: "GatePass",
                columns: new[] { "ComId", "GatePassNo" },
                unique: true,
                filter: "[ComId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryChallan_ComId_ChallanNo",
                table: "DeliveryChallan",
                columns: new[] { "ComId", "ChallanNo" },
                unique: true,
                filter: "[ComId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GatePass_ComId_GatePassNo",
                table: "GatePass");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryChallan_ComId_ChallanNo",
                table: "DeliveryChallan");

            migrationBuilder.DropColumn(
                name: "InWordsBng",
                table: "DeliveryOrder");

            migrationBuilder.DropColumn(
                name: "InWordsEng",
                table: "DeliveryOrder");
        }
    }
}
