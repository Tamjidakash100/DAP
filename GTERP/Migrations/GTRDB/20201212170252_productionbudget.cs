using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class productionbudget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budget_ProductionTargets",
                columns: table => new
                {
                    ProductionTargetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    PrdUnitId = table.Column<int>(nullable: true),
                    InstalledCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromDateProposed = table.Column<DateTime>(nullable: false),
                    ToDateProposed = table.Column<DateTime>(nullable: false),
                    ProposedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromDateRevised = table.Column<DateTime>(nullable: false),
                    ToDateRevised = table.Column<DateTime>(nullable: false),
                    RevisedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromDateEstimate = table.Column<DateTime>(nullable: false),
                    ToDateEstimate = table.Column<DateTime>(nullable: false),
                    EstimageQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromDateActual = table.Column<DateTime>(nullable: false),
                    ToDateActual = table.Column<DateTime>(nullable: false),
                    ActualQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromDateApproved = table.Column<DateTime>(nullable: false),
                    ToDateApproved = table.Column<DateTime>(nullable: false),
                    ApprovedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromDatePreviousActual = table.Column<DateTime>(nullable: false),
                    ToDatePreviousActual = table.Column<DateTime>(nullable: false),
                    PreviousActualQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isPost = table.Column<bool>(nullable: false),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridCheck = table.Column<string>(maxLength: 128, nullable: true),
                    useridApprove = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget_ProductionTargets", x => x.ProductionTargetId);
                    table.ForeignKey(
                        name: "FK_Budget_ProductionTargets_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budget_ProductionTargets_PrdUnitId",
                table: "Budget_ProductionTargets",
                column: "PrdUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budget_ProductionTargets");
        }
    }
}
