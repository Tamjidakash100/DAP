using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class purchaseordervalidtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseOrderValidMains",
                columns: table => new
                {
                    PurOrderValidMainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POValidNo = table.Column<string>(nullable: false),
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
                    Status = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_PurchaseOrderValidMains", x => x.PurOrderValidMainId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderValidMains_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderValidMains_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderValidMains_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderValidMains_PurchaseRequisitionMain_PurReqId",
                        column: x => x.PurReqId,
                        principalTable: "PurchaseRequisitionMain",
                        principalColumn: "PurReqId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderValidMains_Cat_SubSection_SubSectId",
                        column: x => x.SubSectId,
                        principalTable: "Cat_SubSection",
                        principalColumn: "SubSectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderValidMains_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderValidSubs",
                columns: table => new
                {
                    PurOrderValidSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLNo = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    RequisitionQty = table.Column<int>(nullable: true),
                    RemainingReqQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PurchaseQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 60, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    PurReqSubId = table.Column<int>(nullable: true),
                    PurOrderValidMainId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderValidSubs", x => x.PurOrderValidSubId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderValidSubs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderValidSubs_PurchaseOrderValidMains_PurOrderValidMainId",
                        column: x => x.PurOrderValidMainId,
                        principalTable: "PurchaseOrderValidMains",
                        principalColumn: "PurOrderValidMainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderValidSubs_PurchaseRequisitionSub_PurReqSubId",
                        column: x => x.PurReqSubId,
                        principalTable: "PurchaseRequisitionSub",
                        principalColumn: "PurReqSubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderValidSubSuppliers",
                columns: table => new
                {
                    POValidSubSupplierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    SRowNo = table.Column<int>(nullable: false),
                    POValidQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurOrderValidSubId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderValidSubSuppliers", x => x.POValidSubSupplierId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderValidSubSuppliers_PurchaseOrderValidSubs_PurOrderValidSubId",
                        column: x => x.PurOrderValidSubId,
                        principalTable: "PurchaseOrderValidSubs",
                        principalColumn: "PurOrderValidSubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderValidSubSuppliers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderValidMains_CurrencyId",
                table: "PurchaseOrderValidMains",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderValidMains_PaymentTypeId",
                table: "PurchaseOrderValidMains",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderValidMains_PrdUnitId",
                table: "PurchaseOrderValidMains",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderValidMains_PurReqId",
                table: "PurchaseOrderValidMains",
                column: "PurReqId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderValidMains_SubSectId",
                table: "PurchaseOrderValidMains",
                column: "SubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderValidMains_SupplierId",
                table: "PurchaseOrderValidMains",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderValidSubs_ProductId",
                table: "PurchaseOrderValidSubs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderValidSubs_PurOrderValidMainId",
                table: "PurchaseOrderValidSubs",
                column: "PurOrderValidMainId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderValidSubs_PurReqSubId",
                table: "PurchaseOrderValidSubs",
                column: "PurReqSubId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderValidSubSuppliers_PurOrderValidSubId",
                table: "PurchaseOrderValidSubSuppliers",
                column: "PurOrderValidSubId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderValidSubSuppliers_SupplierId",
                table: "PurchaseOrderValidSubSuppliers",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrderValidSubSuppliers");

            migrationBuilder.DropTable(
                name: "PurchaseOrderValidSubs");

            migrationBuilder.DropTable(
                name: "PurchaseOrderValidMains");
        }
    }
}
