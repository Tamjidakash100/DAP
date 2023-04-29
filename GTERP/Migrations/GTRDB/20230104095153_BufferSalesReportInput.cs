using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class BufferSalesReportInput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BufferSaleReportInputs",
                columns: table => new
                {
                    BufferSalesReportInputId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    FiscalMonthId = table.Column<int>(type: "int", nullable: false),
                    BufferID = table.Column<int>(type: "int", nullable: false),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReciveByBuffer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesByBuffer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BufferSaleReportInputs", x => x.BufferSalesReportInputId);
                    table.ForeignKey(
                        name: "FK_BufferSaleReportInputs_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BufferSaleReportInputs_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BufferSaleReportInputs_Buffers_BufferID",
                        column: x => x.BufferID,
                        principalTable: "Buffers",
                        principalColumn: "BufferListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BufferSaleReportInputs_BufferID",
                table: "BufferSaleReportInputs",
                column: "BufferID");

            migrationBuilder.CreateIndex(
                name: "IX_BufferSaleReportInputs_FiscalMonthId",
                table: "BufferSaleReportInputs",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_BufferSaleReportInputs_FiscalYearId",
                table: "BufferSaleReportInputs",
                column: "FiscalYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BufferSaleReportInputs");
        }
    }
}
