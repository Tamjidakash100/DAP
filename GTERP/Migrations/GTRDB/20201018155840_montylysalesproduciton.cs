using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class montylysalesproduciton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlySalesProductions",
                columns: table => new
                {
                    MonthlySalesProductionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrdUnitId = table.Column<int>(nullable: false),
                    FiscalYearId = table.Column<int>(nullable: false),
                    FiscalMonthId = table.Column<int>(nullable: true),
                    ProductionQty = table.Column<float>(nullable: false),
                    ProductionRate = table.Column<float>(nullable: true),
                    ProductionValue = table.Column<float>(nullable: true),
                    SalesQty = table.Column<float>(nullable: false),
                    SalesRate = table.Column<float>(nullable: true),
                    SalesValue = table.Column<float>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 300, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdatedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlySalesProductions", x => x.MonthlySalesProductionId);
                    table.ForeignKey(
                        name: "FK_MonthlySalesProductions_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonthlySalesProductions_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonthlySalesProductions_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlySalesProductions_FiscalMonthId",
                table: "MonthlySalesProductions",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlySalesProductions_FiscalYearId",
                table: "MonthlySalesProductions",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlySalesProductions_PrdUnitId",
                table: "MonthlySalesProductions",
                column: "PrdUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlySalesProductions");
        }
    }
}
