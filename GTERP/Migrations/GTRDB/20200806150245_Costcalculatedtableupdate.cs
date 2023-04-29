using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Costcalculatedtableupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_GoodsReceiveMain_vGoodsReceiveMainGRRMainId",
                table: "CostCalculated");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_vGoodsReceiveMainGRRMainId",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "vGoodsReceiveMainGRRMainId",
                table: "CostCalculated");

            migrationBuilder.RenameColumn(
                name: "grrmainid",
                table: "CostCalculated",
                newName: "GRRMainId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_GRRMainId",
                table: "CostCalculated",
                column: "GRRMainId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_GoodsReceiveMain_GRRMainId",
                table: "CostCalculated",
                column: "GRRMainId",
                principalTable: "GoodsReceiveMain",
                principalColumn: "GRRMainId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_GoodsReceiveMain_GRRMainId",
                table: "CostCalculated");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_GRRMainId",
                table: "CostCalculated");

            migrationBuilder.RenameColumn(
                name: "GRRMainId",
                table: "CostCalculated",
                newName: "grrmainid");

            migrationBuilder.AddColumn<int>(
                name: "vGoodsReceiveMainGRRMainId",
                table: "CostCalculated",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_vGoodsReceiveMainGRRMainId",
                table: "CostCalculated",
                column: "vGoodsReceiveMainGRRMainId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_GoodsReceiveMain_vGoodsReceiveMainGRRMainId",
                table: "CostCalculated",
                column: "vGoodsReceiveMainGRRMainId",
                principalTable: "GoodsReceiveMain",
                principalColumn: "GRRMainId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
