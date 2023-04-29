using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Grrsubwarehouseadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComId",
                table: "IssueSub");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "IssueSub");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "IssueSub");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "IssueSub");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "IssueSub");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "IssueSub");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "GoodsReceiveSub");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "GoodsReceiveSub");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GoodsReceiveSub");

            migrationBuilder.AddColumn<int>(
                name: "Complete",
                table: "StoreRequisitionMain",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GoodsReceiveSubWarehouse",
                columns: table => new
                {
                    GRRSubWarehouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    SRowNo = table.Column<int>(nullable: false),
                    GRRQty = table.Column<float>(nullable: false),
                    GRRSubId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceiveSubWarehouse", x => x.GRRSubWarehouseId);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveSubWarehouse_GoodsReceiveSub_GRRSubId",
                        column: x => x.GRRSubId,
                        principalTable: "GoodsReceiveSub",
                        principalColumn: "GRRSubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveSubWarehouse_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveSubWarehouse_GRRSubId",
                table: "GoodsReceiveSubWarehouse",
                column: "GRRSubId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveSubWarehouse_WarehouseId",
                table: "GoodsReceiveSubWarehouse",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsReceiveSubWarehouse");

            migrationBuilder.DropColumn(
                name: "Complete",
                table: "StoreRequisitionMain");

            migrationBuilder.AddColumn<string>(
                name: "ComId",
                table: "IssueSub",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "IssueSub",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "IssueSub",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "IssueSub",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "IssueSub",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "IssueSub",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComId",
                table: "GoodsReceiveSub",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "GoodsReceiveSub",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "GoodsReceiveSub",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);
        }
    }
}
