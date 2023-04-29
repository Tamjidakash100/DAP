using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class DeliveryChallanGatepass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryChallan_GatePassSub_GatePassSubId",
                table: "DeliveryChallan");

            migrationBuilder.DropForeignKey(
                name: "FK_GatePassSub_GatePass_GatePassId",
                table: "GatePassSub");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryChallan_GatePassSubId",
                table: "DeliveryChallan");

            migrationBuilder.DropColumn(
                name: "GatePassSubId",
                table: "DeliveryChallan");

            migrationBuilder.AlterColumn<float>(
                name: "TruckLoadQty",
                table: "GatePassSub",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GatePassId",
                table: "GatePassSub",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BalanceQty",
                table: "GatePassSub",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddForeignKey(
                name: "FK_GatePassSub_GatePass_GatePassId",
                table: "GatePassSub",
                column: "GatePassId",
                principalTable: "GatePass",
                principalColumn: "GatePassId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GatePassSub_GatePass_GatePassId",
                table: "GatePassSub");

            migrationBuilder.DropColumn(
                name: "BalanceQty",
                table: "GatePassSub");

            migrationBuilder.AlterColumn<int>(
                name: "TruckLoadQty",
                table: "GatePassSub",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "GatePassId",
                table: "GatePassSub",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "GatePassSubId",
                table: "DeliveryChallan",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryChallan_GatePassSubId",
                table: "DeliveryChallan",
                column: "GatePassSubId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryChallan_GatePassSub_GatePassSubId",
                table: "DeliveryChallan",
                column: "GatePassSubId",
                principalTable: "GatePassSub",
                principalColumn: "GatePassSubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GatePassSub_GatePass_GatePassId",
                table: "GatePassSub",
                column: "GatePassId",
                principalTable: "GatePass",
                principalColumn: "GatePassId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
