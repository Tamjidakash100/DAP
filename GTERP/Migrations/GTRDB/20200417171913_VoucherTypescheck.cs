using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class VoucherTypescheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherMains_Acc_VoucherTypes_Acc_VoucherTypeVoucherTypeId",
                table: "Acc_VoucherMains");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherMains_Acc_VoucherTypeVoucherTypeId",
                table: "Acc_VoucherMains");

            migrationBuilder.DropColumn(
                name: "Acc_VoucherTypeVoucherTypeId",
                table: "Acc_VoucherMains");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMains_VoucherTypeId",
                table: "Acc_VoucherMains",
                column: "VoucherTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherMains_Acc_VoucherTypes_VoucherTypeId",
                table: "Acc_VoucherMains",
                column: "VoucherTypeId",
                principalTable: "Acc_VoucherTypes",
                principalColumn: "VoucherTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherMains_Acc_VoucherTypes_VoucherTypeId",
                table: "Acc_VoucherMains");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherMains_VoucherTypeId",
                table: "Acc_VoucherMains");

            migrationBuilder.AddColumn<int>(
                name: "Acc_VoucherTypeVoucherTypeId",
                table: "Acc_VoucherMains",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherMains_Acc_VoucherTypeVoucherTypeId",
                table: "Acc_VoucherMains",
                column: "Acc_VoucherTypeVoucherTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherMains_Acc_VoucherTypes_Acc_VoucherTypeVoucherTypeId",
                table: "Acc_VoucherMains",
                column: "Acc_VoucherTypeVoucherTypeId",
                principalTable: "Acc_VoucherTypes",
                principalColumn: "VoucherTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
