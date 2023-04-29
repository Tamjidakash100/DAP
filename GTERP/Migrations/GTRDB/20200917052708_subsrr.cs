using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class subsrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSubWarehouse",
                table: "Warehouses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SubWarehouseId",
                table: "StoreRequisitionMain",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonB",
                table: "DownTimeReason",
                maxLength: 300,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreRequisitionMain_SubWarehouseId",
                table: "StoreRequisitionMain",
                column: "SubWarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreRequisitionMain_Warehouses_SubWarehouseId",
                table: "StoreRequisitionMain",
                column: "SubWarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreRequisitionMain_Warehouses_SubWarehouseId",
                table: "StoreRequisitionMain");

            migrationBuilder.DropIndex(
                name: "IX_StoreRequisitionMain_SubWarehouseId",
                table: "StoreRequisitionMain");

            migrationBuilder.DropColumn(
                name: "IsSubWarehouse",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "SubWarehouseId",
                table: "StoreRequisitionMain");

            migrationBuilder.DropColumn(
                name: "ReasonB",
                table: "DownTimeReason");
        }
    }
}
