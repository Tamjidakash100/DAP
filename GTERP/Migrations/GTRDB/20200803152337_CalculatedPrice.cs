using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class CalculatedPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NetAmount",
                table: "PurchaseMains",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "CostCalculated",
                columns: table => new
                {
                    CostCalculatedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grrmainid = table.Column<int>(nullable: true),
                    vGoodsReceiveMainGRRMainId = table.Column<int>(nullable: true),
                    IssueMainId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    CurrQty = table.Column<float>(nullable: false),
                    CurrPrice = table.Column<float>(nullable: false),
                    TotalCurrPrice = table.Column<float>(nullable: false),
                    PrevQty = table.Column<float>(nullable: false),
                    PrevPrice = table.Column<float>(nullable: false),
                    TotalPrevPrice = table.Column<float>(nullable: false),
                    CalculatedPrice = table.Column<float>(nullable: false),
                    CalculatedDate = table.Column<DateTime>(nullable: false),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCalculated", x => x.CostCalculatedId);
                    table.ForeignKey(
                        name: "FK_CostCalculated_IssueMain_IssueMainId",
                        column: x => x.IssueMainId,
                        principalTable: "IssueMain",
                        principalColumn: "IssueMainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostCalculated_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostCalculated_GoodsReceiveMain_vGoodsReceiveMainGRRMainId",
                        column: x => x.vGoodsReceiveMainGRRMainId,
                        principalTable: "GoodsReceiveMain",
                        principalColumn: "GRRMainId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_IssueMainId",
                table: "CostCalculated",
                column: "IssueMainId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_ProductId",
                table: "CostCalculated",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_vGoodsReceiveMainGRRMainId",
                table: "CostCalculated",
                column: "vGoodsReceiveMainGRRMainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostCalculated");

            migrationBuilder.AlterColumn<float>(
                name: "NetAmount",
                table: "PurchaseMains",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
