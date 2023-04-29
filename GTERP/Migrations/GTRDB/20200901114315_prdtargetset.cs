using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class prdtargetset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrductionTargetSetup");

            migrationBuilder.CreateTable(
                name: "ProductionTargetSetup",
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
                    table.PrimaryKey("PK_ProductionTargetSetup", x => x.PrdTargetSetId);
                    table.ForeignKey(
                        name: "FK_ProductionTargetSetup_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionTargetSetup_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionTargetSetup_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTargetSetup_FiscalYearId",
                table: "ProductionTargetSetup",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTargetSetup_PrdUnitId",
                table: "ProductionTargetSetup",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTargetSetup_ProductId",
                table: "ProductionTargetSetup",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionTargetSetup");

            migrationBuilder.CreateTable(
                name: "PrductionTargetSetup",
                columns: table => new
                {
                    PrdTargetSetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedbyUserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FiscalYearGoal = table.Column<float>(type: "real", nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    PrdProwerMonth = table.Column<float>(type: "real", nullable: true),
                    PrdProwerYear = table.Column<float>(type: "real", nullable: false),
                    PrdUnitId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    UpdatedbyUserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
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
        }
    }
}
