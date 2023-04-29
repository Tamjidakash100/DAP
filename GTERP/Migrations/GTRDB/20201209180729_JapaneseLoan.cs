using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class JapaneseLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acc_GovtSchedule_JapanLoans",
                columns: table => new
                {
                    GovtScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(nullable: false),
                    GroupByName = table.Column<string>(nullable: true),
                    PortyionType = table.Column<string>(nullable: true),
                    Criteria = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    DateOfPayment = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    MilestonePortionYen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplyPortionYen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterestPortionYen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmountYen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MilestonePortionTaka = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplyPortionTaka = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterestPortionTaka = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExchangeLossGainTaka = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmountTaka = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_Acc_GovtSchedule_JapanLoans", x => x.GovtScheduleId);
                    table.ForeignKey(
                        name: "FK_Acc_GovtSchedule_JapanLoans_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_GovtSchedule_JapanLoans_AccId",
                table: "Acc_GovtSchedule_JapanLoans",
                column: "AccId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_GovtSchedule_JapanLoans");
        }
    }
}
