using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GTERP.Migrations.GTRDB
{
    public partial class billmanagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bill_Main",
                columns: table => new
                {
                    BillMainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillNo = table.Column<string>(maxLength: 50, nullable: true),
                    BillDate = table.Column<DateTime>(nullable: false),
                    SupplierId = table.Column<int>(nullable: true),
                    SupplierName = table.Column<string>(maxLength: 100, nullable: true),
                    AccId = table.Column<int>(nullable: true),
                    TotalPOQty = table.Column<double>(nullable: false),
                    TotalReceiveQty = table.Column<double>(nullable: false),
                    GrossAmount = table.Column<double>(nullable: false),
                    TotalSDAmount = table.Column<double>(nullable: false),
                    TotalVATAmount = table.Column<double>(nullable: false),
                    TotalAITAmount = table.Column<double>(nullable: false),
                    NetPayableBill = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 400, nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    UserIdUpdated = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill_Main", x => x.BillMainId);
                    table.ForeignKey(
                        name: "FK_Bill_Main_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_Main_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bill_Sub",
                columns: table => new
                {
                    BillSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillMainId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    ProductName = table.Column<string>(maxLength: 100, nullable: true),
                    POQty = table.Column<double>(nullable: false),
                    ReceiveQty = table.Column<double>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    SDPercentage = table.Column<float>(nullable: false),
                    SDAmount = table.Column<double>(nullable: false),
                    VATPercentage = table.Column<float>(nullable: false),
                    VATAmount = table.Column<double>(nullable: false),
                    AITPercentage = table.Column<float>(nullable: false),
                    AITAmount = table.Column<double>(nullable: false),
                    NetAmount = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 400, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill_Sub", x => x.BillSubId);
                    table.ForeignKey(
                        name: "FK_Bill_Sub_Bill_Main_BillMainId",
                        column: x => x.BillMainId,
                        principalTable: "Bill_Main",
                        principalColumn: "BillMainId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bill_Sub_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_Main_AccId",
                table: "Bill_Main",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_Main_SupplierId",
                table: "Bill_Main",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_Sub_BillMainId",
                table: "Bill_Sub",
                column: "BillMainId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_Sub_ProductId",
                table: "Bill_Sub",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill_Sub");

            migrationBuilder.DropTable(
                name: "Bill_Main");
        }
    }
}
