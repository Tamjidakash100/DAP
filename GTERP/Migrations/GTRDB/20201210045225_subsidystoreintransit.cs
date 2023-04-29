using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class subsidystoreintransit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acc_AdvanceIncomeTax_Schedule",
                columns: table => new
                {
                    GovtScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(nullable: false),
                    GroupByName = table.Column<string>(nullable: true),
                    Criteria = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    ContractNo = table.Column<string>(nullable: true),
                    ContractDate = table.Column<DateTime>(nullable: true),
                    LCNo = table.Column<string>(nullable: true),
                    LCDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BENo = table.Column<string>(nullable: true),
                    BEDate = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    TotalAssesedAmountVat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AITAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAIT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_Acc_AdvanceIncomeTax_Schedule", x => x.GovtScheduleId);
                    table.ForeignKey(
                        name: "FK_Acc_AdvanceIncomeTax_Schedule_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acc_GovtSchedule_StoreInTransit",
                columns: table => new
                {
                    GovtScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(nullable: false),
                    Criteria = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_Acc_GovtSchedule_StoreInTransit", x => x.GovtScheduleId);
                    table.ForeignKey(
                        name: "FK_Acc_GovtSchedule_StoreInTransit_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acc_GovtSchedule_Subsidy",
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
                    ReceivablePlantOne = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceivablePlantTwo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceivableTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceivableCumulative = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceivedPlantOne = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceivedPlantTwo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceivedTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceivedCumulative = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalancePlantOne = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalancePlantTwo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceCumulative = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_Acc_GovtSchedule_Subsidy", x => x.GovtScheduleId);
                    table.ForeignKey(
                        name: "FK_Acc_GovtSchedule_Subsidy_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_AdvanceIncomeTax_Schedule_AccId",
                table: "Acc_AdvanceIncomeTax_Schedule",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_GovtSchedule_StoreInTransit_AccId",
                table: "Acc_GovtSchedule_StoreInTransit",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_GovtSchedule_Subsidy_AccId",
                table: "Acc_GovtSchedule_Subsidy",
                column: "AccId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_AdvanceIncomeTax_Schedule");

            migrationBuilder.DropTable(
                name: "Acc_GovtSchedule_StoreInTransit");

            migrationBuilder.DropTable(
                name: "Acc_GovtSchedule_Subsidy");
        }
    }
}
