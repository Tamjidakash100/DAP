using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class moreledgermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_ITInvestmentItem",
                columns: table => new
                {
                    ITInvestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    FYID = table.Column<int>(nullable: false),
                    DtInput = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    ReceivedTK = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NSCBAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DPSAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DSSMFundAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LIPAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_Cat_ITInvestmentItem", x => x.ITInvestId);
                    table.ForeignKey(
                        name: "FK_Cat_ITInvestmentItem_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_ITInvestmentItem_Acc_FiscalYears_FYID",
                        column: x => x.FYID,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gratuity_Ledgers",
                columns: table => new
                {
                    GratuityLedgerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankAccountId = table.Column<int>(nullable: false),
                    VoucherNo = table.Column<string>(nullable: true),
                    ChequeNo = table.Column<string>(nullable: true),
                    Criteria = table.Column<string>(nullable: true),
                    AmountType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TranDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    ReceivedTK = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTK = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isPrinciple = table.Column<bool>(nullable: false),
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
                    table.PrimaryKey("PK_Gratuity_Ledgers", x => x.GratuityLedgerId);
                    table.ForeignKey(
                        name: "FK_Gratuity_Ledgers_BankAccountNos_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccountNos",
                        principalColumn: "BankAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WF_Ledgers",
                columns: table => new
                {
                    WFLedgerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankAccountId = table.Column<int>(nullable: false),
                    VoucherNo = table.Column<string>(nullable: true),
                    ChequeNo = table.Column<string>(nullable: true),
                    Criteria = table.Column<string>(nullable: true),
                    AmountType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TranDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    ReceivedTK = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentTK = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isPrinciple = table.Column<bool>(nullable: false),
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
                    table.PrimaryKey("PK_WF_Ledgers", x => x.WFLedgerId);
                    table.ForeignKey(
                        name: "FK_WF_Ledgers_BankAccountNos_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccountNos",
                        principalColumn: "BankAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_ITInvestmentItem_EmpId",
                table: "Cat_ITInvestmentItem",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_ITInvestmentItem_FYID",
                table: "Cat_ITInvestmentItem",
                column: "FYID");

            migrationBuilder.CreateIndex(
                name: "IX_Gratuity_Ledgers_BankAccountId",
                table: "Gratuity_Ledgers",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_WF_Ledgers_BankAccountId",
                table: "WF_Ledgers",
                column: "BankAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_ITInvestmentItem");

            migrationBuilder.DropTable(
                name: "Gratuity_Ledgers");

            migrationBuilder.DropTable(
                name: "WF_Ledgers");
        }
    }
}
