using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class purchaserequisition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purpose",
                columns: table => new
                {
                    PurposeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurposeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purpose", x => x.PurposeId);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequisitionMain",
                columns: table => new
                {
                    PurReqId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrdUnitId = table.Column<int>(nullable: false),
                    PRNo = table.Column<int>(nullable: true),
                    ReqRef = table.Column<string>(nullable: true),
                    ReqDate = table.Column<DateTime>(nullable: false),
                    BoardMeetingDate = table.Column<DateTime>(nullable: false),
                    PurposeId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    ApprovedByEmpId = table.Column<int>(nullable: false),
                    RecommenedByEmpId = table.Column<int>(nullable: false),
                    ReqStatus = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    RequiredDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequisitionMain", x => x.PurReqId);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitionMain_Employee_ApprovedByEmpId",
                        column: x => x.ApprovedByEmpId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitionMain_Cat_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Cat_Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitionMain_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitionMain_Purpose_PurposeId",
                        column: x => x.PurposeId,
                        principalTable: "Purpose",
                        principalColumn: "PurposeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitionMain_Employee_RecommenedByEmpId",
                        column: x => x.RecommenedByEmpId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequisitionSub",
                columns: table => new
                {
                    PurReqSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLNo = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    PurReqQty = table.Column<int>(nullable: false),
                    RemainingReqQty = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    PurReqId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequisitionSub", x => x.PurReqSubId);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitionSub_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitionSub_PurchaseRequisitionMain_PurReqId",
                        column: x => x.PurReqId,
                        principalTable: "PurchaseRequisitionMain",
                        principalColumn: "PurReqId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitionMain_ApprovedByEmpId",
                table: "PurchaseRequisitionMain",
                column: "ApprovedByEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitionMain_DepartmentId",
                table: "PurchaseRequisitionMain",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitionMain_PrdUnitId",
                table: "PurchaseRequisitionMain",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitionMain_PurposeId",
                table: "PurchaseRequisitionMain",
                column: "PurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitionMain_RecommenedByEmpId",
                table: "PurchaseRequisitionMain",
                column: "RecommenedByEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitionSub_ProductId",
                table: "PurchaseRequisitionSub",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitionSub_PurReqId",
                table: "PurchaseRequisitionSub",
                column: "PurReqId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseRequisitionSub");

            migrationBuilder.DropTable(
                name: "PurchaseRequisitionMain");

            migrationBuilder.DropTable(
                name: "Purpose");
        }
    }
}
