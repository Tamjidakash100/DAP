using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class purchasemainsubsresearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasePaymentSubs");

            migrationBuilder.DropTable(
                name: "PurchaseTermsSubs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchasePaymentSubs",
                columns: table => new
                {
                    PurchasePaymentSubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PaymentCardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    PurchaseMainPurchaseId = table.Column<int>(type: "int", nullable: true),
                    RowNo = table.Column<int>(type: "int", nullable: true),
                    isPosted = table.Column<bool>(type: "bit", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    vChartofAccountsAccId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePaymentSubs", x => x.PurchasePaymentSubId);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentSubs_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentSubs_PurchaseMains_PurchaseMainPurchaseId",
                        column: x => x.PurchaseMainPurchaseId,
                        principalTable: "PurchaseMains",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentSubs_Acc_ChartOfAccounts_vChartofAccountsAccId",
                        column: x => x.vChartofAccountsAccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseTermsSubs",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseMainPurchaseId = table.Column<int>(type: "int", nullable: true),
                    RowNo = table.Column<int>(type: "int", nullable: false),
                    Terms = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTermsSubs", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_PurchaseTermsSubs_PurchaseMains_PurchaseMainPurchaseId",
                        column: x => x.PurchaseMainPurchaseId,
                        principalTable: "PurchaseMains",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentSubs_PaymentTypeId",
                table: "PurchasePaymentSubs",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentSubs_PurchaseMainPurchaseId",
                table: "PurchasePaymentSubs",
                column: "PurchaseMainPurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentSubs_vChartofAccountsAccId",
                table: "PurchasePaymentSubs",
                column: "vChartofAccountsAccId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTermsSubs_PurchaseMainPurchaseId",
                table: "PurchaseTermsSubs",
                column: "PurchaseMainPurchaseId");
        }
    }
}
