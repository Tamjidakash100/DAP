using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class ReceivedFromBufferAndBankMOdel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BanksModel",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanksModel", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "ReceivedFromBufferBankAmountsModels",
                columns: table => new
                {
                    BankAmountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BufferId = table.Column<int>(type: "int", nullable: false),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    FiscalMonthId = table.Column<int>(type: "int", nullable: false),
                    BankID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    comid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedFromBufferBankAmountsModels", x => x.BankAmountId);
                    table.ForeignKey(
                        name: "FK_ReceivedFromBufferBankAmountsModels_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceivedFromBufferBankAmountsModels_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceivedFromBufferBankAmountsModels_BanksModel_BankID",
                        column: x => x.BankID,
                        principalTable: "BanksModel",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceivedFromBufferBankAmountsModels_Buffers_BufferId",
                        column: x => x.BufferId,
                        principalTable: "Buffers",
                        principalColumn: "BufferListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedFromBufferBankAmountsModels_BankID",
                table: "ReceivedFromBufferBankAmountsModels",
                column: "BankID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedFromBufferBankAmountsModels_BufferId",
                table: "ReceivedFromBufferBankAmountsModels",
                column: "BufferId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedFromBufferBankAmountsModels_FiscalMonthId",
                table: "ReceivedFromBufferBankAmountsModels",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedFromBufferBankAmountsModels_FiscalYearId",
                table: "ReceivedFromBufferBankAmountsModels",
                column: "FiscalYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceivedFromBufferBankAmountsModels");

            migrationBuilder.DropTable(
                name: "BanksModel");
        }
    }
}
