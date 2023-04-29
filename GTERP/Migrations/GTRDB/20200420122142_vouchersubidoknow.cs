using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class vouchersubidoknow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubChecnos_Acc_VoucherSubs_Acc_VoucherSubVoucherSubId",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubSections_Acc_VoucherSubs_Acc_VoucherSubVoucherSubId",
                table: "Acc_VoucherSubSections");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubSections_Acc_VoucherSubVoucherSubId",
                table: "Acc_VoucherSubSections");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubChecnos_Acc_VoucherSubVoucherSubId",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.DropColumn(
                name: "Acc_VoucherSubVoucherSubId",
                table: "Acc_VoucherSubSections");

            migrationBuilder.DropColumn(
                name: "Acc_VoucherSubVoucherSubId",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubSections_VoucherSubId",
                table: "Acc_VoucherSubSections",
                column: "VoucherSubId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubChecnos_VoucherSubId",
                table: "Acc_VoucherSubChecnos",
                column: "VoucherSubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubChecnos_Acc_VoucherSubs_VoucherSubId",
                table: "Acc_VoucherSubChecnos",
                column: "VoucherSubId",
                principalTable: "Acc_VoucherSubs",
                principalColumn: "VoucherSubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubSections_Acc_VoucherSubs_VoucherSubId",
                table: "Acc_VoucherSubSections",
                column: "VoucherSubId",
                principalTable: "Acc_VoucherSubs",
                principalColumn: "VoucherSubId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubChecnos_Acc_VoucherSubs_VoucherSubId",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubSections_Acc_VoucherSubs_VoucherSubId",
                table: "Acc_VoucherSubSections");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubSections_VoucherSubId",
                table: "Acc_VoucherSubSections");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubChecnos_VoucherSubId",
                table: "Acc_VoucherSubChecnos");

            migrationBuilder.AddColumn<int>(
                name: "Acc_VoucherSubVoucherSubId",
                table: "Acc_VoucherSubSections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Acc_VoucherSubVoucherSubId",
                table: "Acc_VoucherSubChecnos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubSections_Acc_VoucherSubVoucherSubId",
                table: "Acc_VoucherSubSections",
                column: "Acc_VoucherSubVoucherSubId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubChecnos_Acc_VoucherSubVoucherSubId",
                table: "Acc_VoucherSubChecnos",
                column: "Acc_VoucherSubVoucherSubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubChecnos_Acc_VoucherSubs_Acc_VoucherSubVoucherSubId",
                table: "Acc_VoucherSubChecnos",
                column: "Acc_VoucherSubVoucherSubId",
                principalTable: "Acc_VoucherSubs",
                principalColumn: "VoucherSubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubSections_Acc_VoucherSubs_Acc_VoucherSubVoucherSubId",
                table: "Acc_VoucherSubSections",
                column: "Acc_VoucherSubVoucherSubId",
                principalTable: "Acc_VoucherSubs",
                principalColumn: "VoucherSubId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
