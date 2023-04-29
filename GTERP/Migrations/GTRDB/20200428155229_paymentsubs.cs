using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class paymentsubs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchasePaymentSubs",
                columns: table => new
                {
                    PurchasePaymentSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: false),
                    PaymentCardNo = table.Column<string>(nullable: true),
                    isPosted = table.Column<bool>(nullable: false),
                    AccId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RowNo = table.Column<int>(nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: false),
                    userid = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePaymentSubs", x => x.PurchasePaymentSubId);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentSubs_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentSubs_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentSubs_PurchaseMains_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "PurchaseMains",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseTermsSubs",
                columns: table => new
                {
                    PurchaseTermsSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(nullable: false),
                    Terms = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RowNo = table.Column<int>(nullable: false),
                    ComId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTermsSubs", x => x.PurchaseTermsSubId);
                    table.ForeignKey(
                        name: "FK_PurchaseTermsSubs_PurchaseMains_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "PurchaseMains",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentSubs_AccId",
                table: "PurchasePaymentSubs",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentSubs_PaymentTypeId",
                table: "PurchasePaymentSubs",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentSubs_PurchaseId",
                table: "PurchasePaymentSubs",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTermsSubs_PurchaseId",
                table: "PurchaseTermsSubs",
                column: "PurchaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasePaymentSubs");

            migrationBuilder.DropTable(
                name: "PurchaseTermsSubs");
        }
    }
}
