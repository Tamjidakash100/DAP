using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class GoodsReceive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoodsReceiveMain",
                columns: table => new
                {
                    GRRMainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GRRNo = table.Column<string>(nullable: true),
                    GRRDate = table.Column<DateTime>(nullable: false),
                    GRRRef = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    PrdUnitId = table.Column<int>(nullable: true),
                    PurReqId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: true),
                    ConvertionRate = table.Column<float>(nullable: false),
                    TotalGRRValue = table.Column<float>(nullable: false),
                    Deduction = table.Column<float>(nullable: true),
                    NetGRRValue = table.Column<float>(nullable: true),
                    SubSectId = table.Column<int>(nullable: true),
                    PurOrderMainId = table.Column<int>(nullable: true),
                    GateInHouseDate = table.Column<DateTime>(nullable: true),
                    ExpectedReciveDate = table.Column<DateTime>(nullable: true),
                    TermsAndCondition = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 60, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceiveMain", x => x.GRRMainId);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveMain_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveMain_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveMain_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveMain_PurchaseOrderMain_PurOrderMainId",
                        column: x => x.PurOrderMainId,
                        principalTable: "PurchaseOrderMain",
                        principalColumn: "PurOrderMainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveMain_PurchaseRequisitionMain_PurReqId",
                        column: x => x.PurReqId,
                        principalTable: "PurchaseRequisitionMain",
                        principalColumn: "PurReqId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveMain_Cat_SubSection_SubSectId",
                        column: x => x.SubSectId,
                        principalTable: "Cat_SubSection",
                        principalColumn: "SubSectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveMain_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoodsReceiveSub",
                columns: table => new
                {
                    GRRSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLNo = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    RequisitionQty = table.Column<int>(nullable: true),
                    RemainingReqQty = table.Column<int>(nullable: true),
                    PurchaseQty = table.Column<int>(nullable: true),
                    Rate = table.Column<float>(nullable: true),
                    TotalValue = table.Column<float>(nullable: true),
                    Quality = table.Column<float>(nullable: true),
                    Received = table.Column<float>(nullable: true),
                    Damage = table.Column<float>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 60, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    PurReqSubId = table.Column<int>(nullable: true),
                    PurOrderMainId = table.Column<int>(nullable: true),
                    PurOrderSubId = table.Column<int>(nullable: true),
                    GRRMainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceiveSub", x => x.GRRSubId);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveSub_GoodsReceiveMain_GRRMainId",
                        column: x => x.GRRMainId,
                        principalTable: "GoodsReceiveMain",
                        principalColumn: "GRRMainId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveSub_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveSub_PurchaseOrderSub_PurOrderSubId",
                        column: x => x.PurOrderSubId,
                        principalTable: "PurchaseOrderSub",
                        principalColumn: "PurOrderSubId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveSub_PurchaseRequisitionSub_PurReqSubId",
                        column: x => x.PurReqSubId,
                        principalTable: "PurchaseRequisitionSub",
                        principalColumn: "PurReqSubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveMain_CurrencyId",
                table: "GoodsReceiveMain",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveMain_PaymentTypeId",
                table: "GoodsReceiveMain",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveMain_PrdUnitId",
                table: "GoodsReceiveMain",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveMain_PurOrderMainId",
                table: "GoodsReceiveMain",
                column: "PurOrderMainId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveMain_PurReqId",
                table: "GoodsReceiveMain",
                column: "PurReqId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveMain_SubSectId",
                table: "GoodsReceiveMain",
                column: "SubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveMain_SupplierId",
                table: "GoodsReceiveMain",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveSub_GRRMainId",
                table: "GoodsReceiveSub",
                column: "GRRMainId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveSub_ProductId",
                table: "GoodsReceiveSub",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveSub_PurOrderSubId",
                table: "GoodsReceiveSub",
                column: "PurOrderSubId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveSub_PurReqSubId",
                table: "GoodsReceiveSub",
                column: "PurReqSubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsReceiveSub");

            migrationBuilder.DropTable(
                name: "GoodsReceiveMain");
        }
    }
}
