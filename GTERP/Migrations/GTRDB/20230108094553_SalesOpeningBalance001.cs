using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class SalesOpeningBalance001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesOpeningBalances",
                columns: table => new
                {
                    OpeningBalanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    FiscalMonthId = table.Column<int>(type: "int", nullable: false),
                    BufferID = table.Column<int>(type: "int", nullable: false),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReciveByOpening = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesByOpening = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BacklogOpening = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YearlyAllotmentMOA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOpeningBalances", x => x.OpeningBalanceId);
                    table.ForeignKey(
                        name: "FK_SalesOpeningBalances_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOpeningBalances_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOpeningBalances_Buffers_BufferID",
                        column: x => x.BufferID,
                        principalTable: "Buffers",
                        principalColumn: "BufferListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesOpeningBalances_BufferID",
                table: "SalesOpeningBalances",
                column: "BufferID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOpeningBalances_FiscalMonthId",
                table: "SalesOpeningBalances",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOpeningBalances_FiscalYearId",
                table: "SalesOpeningBalances",
                column: "FiscalYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesOpeningBalances");
        }
    }
}
