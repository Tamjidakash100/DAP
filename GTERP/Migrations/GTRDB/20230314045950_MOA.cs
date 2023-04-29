using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class MOA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearlyAllotmentMOA",
                table: "FactoryInfos",
                newName: "Deposit");

            migrationBuilder.CreateTable(
                name: "BufferAllotment_MOA",
                columns: table => new
                {
                    MOA_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    FiscalMonthId = table.Column<int>(type: "int", nullable: false),
                    BufferId = table.Column<int>(type: "int", nullable: false),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllotmentMOA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BufferAllotment_MOA", x => x.MOA_ID);
                    table.ForeignKey(
                        name: "FK_BufferAllotment_MOA_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BufferAllotment_MOA_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BufferAllotment_MOA_Buffers_BufferId",
                        column: x => x.BufferId,
                        principalTable: "Buffers",
                        principalColumn: "BufferListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BufferAllotment_MOA_BufferId",
                table: "BufferAllotment_MOA",
                column: "BufferId");

            migrationBuilder.CreateIndex(
                name: "IX_BufferAllotment_MOA_FiscalMonthId",
                table: "BufferAllotment_MOA",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_BufferAllotment_MOA_FiscalYearId",
                table: "BufferAllotment_MOA",
                column: "FiscalYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BufferAllotment_MOA");

            migrationBuilder.RenameColumn(
                name: "Deposit",
                table: "FactoryInfos",
                newName: "YearlyAllotmentMOA");
        }
    }
}
