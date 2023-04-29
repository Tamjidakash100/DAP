using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class PurchaseOrderEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseOrderMain",
                columns: table => new
                {
                    PurOrderMainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PONo = table.Column<string>(nullable: true),
                    PODate = table.Column<DateTime>(nullable: false),
                    PORef = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    PrdUnitId = table.Column<int>(nullable: true),
                    PurReqId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: true),
                    ConvertionRate = table.Column<float>(nullable: false),
                    TotalPOValue = table.Column<float>(nullable: false),
                    Deduction = table.Column<float>(nullable: true),
                    NetPOValue = table.Column<float>(nullable: true),
                    SubSectId = table.Column<int>(nullable: true),
                    GateInHouseDate = table.Column<DateTime>(nullable: true),
                    ExpectedReciveDate = table.Column<DateTime>(nullable: true),
                    TermsAndCondition = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 60, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    GateInHouseDatestring = table.Column<string>(nullable: true),
                    ExpectedReciveDatestring = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderMain", x => x.PurOrderMainId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderMain_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderMain_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderMain_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderMain_PurchaseRequisitionMain_PurReqId",
                        column: x => x.PurReqId,
                        principalTable: "PurchaseRequisitionMain",
                        principalColumn: "PurReqId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderMain_Cat_SubSection_SubSectId",
                        column: x => x.SubSectId,
                        principalTable: "Cat_SubSection",
                        principalColumn: "SubSectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderMain_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderSub",
                columns: table => new
                {
                    PurOrderSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLNo = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    RequisitionQty = table.Column<int>(nullable: true),
                    RemainingReqQty = table.Column<int>(nullable: true),
                    PurchaseQty = table.Column<int>(nullable: true),
                    Rate = table.Column<float>(nullable: true),
                    TotalValue = table.Column<float>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 60, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    PurReqSubId = table.Column<int>(nullable: true),
                    PurOrderMainId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderSub", x => x.PurOrderSubId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderSub_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderSub_PurchaseOrderMain_PurOrderMainId",
                        column: x => x.PurOrderMainId,
                        principalTable: "PurchaseOrderMain",
                        principalColumn: "PurOrderMainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderSub_PurchaseRequisitionSub_PurReqSubId",
                        column: x => x.PurReqSubId,
                        principalTable: "PurchaseRequisitionSub",
                        principalColumn: "PurReqSubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderMain_CurrencyId",
                table: "PurchaseOrderMain",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderMain_PaymentTypeId",
                table: "PurchaseOrderMain",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderMain_PrdUnitId",
                table: "PurchaseOrderMain",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderMain_PurReqId",
                table: "PurchaseOrderMain",
                column: "PurReqId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderMain_SubSectId",
                table: "PurchaseOrderMain",
                column: "SubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderMain_SupplierId",
                table: "PurchaseOrderMain",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderSub_ProductId",
                table: "PurchaseOrderSub",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderSub_PurOrderMainId",
                table: "PurchaseOrderSub",
                column: "PurOrderMainId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderSub_PurReqSubId",
                table: "PurchaseOrderSub",
                column: "PurReqSubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrderSub");

            migrationBuilder.DropTable(
                name: "PurchaseOrderMain");
        }
    }
}
