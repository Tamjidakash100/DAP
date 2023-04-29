using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class checkvouchernoprefixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherNoPrefixes_Acc_VoucherTypes_vVoucherTypesVoucherTypeId",
                table: "Acc_VoucherNoPrefixes");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherNoPrefixes_vVoucherTypesVoucherTypeId",
                table: "Acc_VoucherNoPrefixes");

            migrationBuilder.DropColumn(
                name: "vVoucherTypesVoucherTypeId",
                table: "Acc_VoucherNoPrefixes");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherNoPrefixes_VoucherTypeId",
                table: "Acc_VoucherNoPrefixes",
                column: "VoucherTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherNoPrefixes_Acc_VoucherTypes_VoucherTypeId",
                table: "Acc_VoucherNoPrefixes",
                column: "VoucherTypeId",
                principalTable: "Acc_VoucherTypes",
                principalColumn: "VoucherTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherNoPrefixes_Acc_VoucherTypes_VoucherTypeId",
                table: "Acc_VoucherNoPrefixes");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherNoPrefixes_VoucherTypeId",
                table: "Acc_VoucherNoPrefixes");

            migrationBuilder.AddColumn<int>(
                name: "vVoucherTypesVoucherTypeId",
                table: "Acc_VoucherNoPrefixes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherNoPrefixes_vVoucherTypesVoucherTypeId",
                table: "Acc_VoucherNoPrefixes",
                column: "vVoucherTypesVoucherTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherNoPrefixes_Acc_VoucherTypes_vVoucherTypesVoucherTypeId",
                table: "Acc_VoucherNoPrefixes",
                column: "vVoucherTypesVoucherTypeId",
                principalTable: "Acc_VoucherTypes",
                principalColumn: "VoucherTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
