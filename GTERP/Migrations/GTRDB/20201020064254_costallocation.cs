using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class costallocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CostAllocation_Main",
                columns: table => new
                {
                    CostAlloMainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    FiscalYearId = table.Column<int>(nullable: false),
                    FiscalMonthId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 400, nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostAllocation_Main", x => x.CostAlloMainId);
                    table.ForeignKey(
                        name: "FK_CostAllocation_Main_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostAllocation_Main_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostAllocation_Details",
                columns: table => new
                {
                    CostAlloSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostAlloMainId = table.Column<int>(nullable: false),
                    Details_AccId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 400, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostAllocation_Details", x => x.CostAlloSubId);
                    table.ForeignKey(
                        name: "FK_CostAllocation_Details_CostAllocation_Main_CostAlloMainId",
                        column: x => x.CostAlloMainId,
                        principalTable: "CostAllocation_Main",
                        principalColumn: "CostAlloMainId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostAllocation_Details_Acc_ChartOfAccounts_Details_AccId",
                        column: x => x.Details_AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostAllocation_Distribute",
                columns: table => new
                {
                    CostAlloDistributeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(maxLength: 50, nullable: true),
                    Percentage = table.Column<float>(maxLength: 50, nullable: true),
                    CostAlloMainId = table.Column<int>(nullable: false),
                    CostAllocationMainId = table.Column<int>(nullable: true),
                    CostAlloSubId = table.Column<int>(nullable: false),
                    Details_AccId = table.Column<int>(nullable: false),
                    Distribute_AccId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 400, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostAllocation_Distribute", x => x.CostAlloDistributeId);
                    table.ForeignKey(
                        name: "FK_CostAllocation_Distribute_CostAllocation_Details_CostAlloSubId",
                        column: x => x.CostAlloSubId,
                        principalTable: "CostAllocation_Details",
                        principalColumn: "CostAlloSubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostAllocation_Distribute_CostAllocation_Main_CostAllocationMainId",
                        column: x => x.CostAllocationMainId,
                        principalTable: "CostAllocation_Main",
                        principalColumn: "CostAlloMainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostAllocation_Distribute_Acc_ChartOfAccounts_Distribute_AccId",
                        column: x => x.Distribute_AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostAllocation_Details_CostAlloMainId",
                table: "CostAllocation_Details",
                column: "CostAlloMainId");

            migrationBuilder.CreateIndex(
                name: "IX_CostAllocation_Details_Details_AccId",
                table: "CostAllocation_Details",
                column: "Details_AccId");

            migrationBuilder.CreateIndex(
                name: "IX_CostAllocation_Distribute_CostAlloSubId",
                table: "CostAllocation_Distribute",
                column: "CostAlloSubId");

            migrationBuilder.CreateIndex(
                name: "IX_CostAllocation_Distribute_CostAllocationMainId",
                table: "CostAllocation_Distribute",
                column: "CostAllocationMainId");

            migrationBuilder.CreateIndex(
                name: "IX_CostAllocation_Distribute_Distribute_AccId",
                table: "CostAllocation_Distribute",
                column: "Distribute_AccId");

            migrationBuilder.CreateIndex(
                name: "IX_CostAllocation_Main_FiscalMonthId",
                table: "CostAllocation_Main",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_CostAllocation_Main_FiscalYearId",
                table: "CostAllocation_Main",
                column: "FiscalYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostAllocation_Distribute");

            migrationBuilder.DropTable(
                name: "CostAllocation_Details");

            migrationBuilder.DropTable(
                name: "CostAllocation_Main");
        }
    }
}
