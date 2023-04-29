using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class GovtSchedule_loan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_GovtSchedules");

            migrationBuilder.CreateTable(
                name: "Acc_GovtSchedule_Equity",
                columns: table => new
                {
                    GovtScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(nullable: false),
                    Criteria = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Loan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Development = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CDVAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_Acc_GovtSchedule_Equity", x => x.GovtScheduleId);
                    table.ForeignKey(
                        name: "FK_Acc_GovtSchedule_Equity_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acc_GovtSchedule_Loans",
                columns: table => new
                {
                    GovtScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(nullable: false),
                    Criteria = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Principle = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Interest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalLoan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_Acc_GovtSchedule_Loans", x => x.GovtScheduleId);
                    table.ForeignKey(
                        name: "FK_Acc_GovtSchedule_Loans_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_GovtSchedule_Equity_AccId",
                table: "Acc_GovtSchedule_Equity",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_GovtSchedule_Loans_AccId",
                table: "Acc_GovtSchedule_Loans",
                column: "AccId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_GovtSchedule_Equity");

            migrationBuilder.DropTable(
                name: "Acc_GovtSchedule_Loans");

            migrationBuilder.CreateTable(
                name: "Acc_GovtSchedules",
                columns: table => new
                {
                    GovtScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(type: "int", nullable: false),
                    CDVAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Development = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Loan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    comid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    isPost = table.Column<bool>(type: "bit", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    useridApprove = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    useridCheck = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_GovtSchedules", x => x.GovtScheduleId);
                    table.ForeignKey(
                        name: "FK_Acc_GovtSchedules_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_GovtSchedules_AccId",
                table: "Acc_GovtSchedules",
                column: "AccId");
        }
    }
}
