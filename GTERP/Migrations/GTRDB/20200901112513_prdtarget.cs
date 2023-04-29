using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class prdtarget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrductionTargetSetup",
                columns: table => new
                {
                    PrdTargetSetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrdUnitId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    FiscalYearId = table.Column<int>(nullable: false),
                    PrdProwerYear = table.Column<float>(nullable: false),
                    PrdProwerMonth = table.Column<float>(nullable: true),
                    FiscalYearGoal = table.Column<float>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 300, nullable: true),
                    AddedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdatedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrductionTargetSetup", x => x.PrdTargetSetId);
                    table.ForeignKey(
                        name: "FK_PrductionTargetSetup_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrductionTargetSetup_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrductionTargetSetup_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesTargetSetup",
                columns: table => new
                {
                    SaleTargetSetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrdUnitId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    FiscalYearId = table.Column<int>(nullable: false),
                    FiscalYearGoal = table.Column<float>(nullable: false),
                    FiscalMonthGoal = table.Column<float>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 300, nullable: true),
                    AddedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdatedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTargetSetup", x => x.SaleTargetSetId);
                    table.ForeignKey(
                        name: "FK_SalesTargetSetup_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesTargetSetup_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesTargetSetup_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrductionTargetSetup_FiscalYearId",
                table: "PrductionTargetSetup",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PrductionTargetSetup_PrdUnitId",
                table: "PrductionTargetSetup",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PrductionTargetSetup_ProductId",
                table: "PrductionTargetSetup",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTargetSetup_FiscalYearId",
                table: "SalesTargetSetup",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTargetSetup_PrdUnitId",
                table: "SalesTargetSetup",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTargetSetup_ProductId",
                table: "SalesTargetSetup",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrductionTargetSetup");

            migrationBuilder.DropTable(
                name: "SalesTargetSetup");
        }
    }
}
