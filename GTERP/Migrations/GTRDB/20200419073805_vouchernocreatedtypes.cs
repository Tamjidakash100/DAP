using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class vouchernocreatedtypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companys_Acc_VoucherNoCreatedTypes_vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId",
                table: "Companys");

            migrationBuilder.DropIndex(
                name: "IX_Companys_vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId",
                table: "Companys");

            migrationBuilder.CreateIndex(
                name: "IX_Companys_VoucherNoCreatedTypeId",
                table: "Companys",
                column: "VoucherNoCreatedTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companys_Acc_VoucherNoCreatedTypes_VoucherNoCreatedTypeId",
                table: "Companys",
                column: "VoucherNoCreatedTypeId",
                principalTable: "Acc_VoucherNoCreatedTypes",
                principalColumn: "VoucherNoCreatedTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companys_Acc_VoucherNoCreatedTypes_VoucherNoCreatedTypeId",
                table: "Companys");

            migrationBuilder.DropIndex(
                name: "IX_Companys_VoucherNoCreatedTypeId",
                table: "Companys");

            migrationBuilder.AddColumn<int>(
                name: "vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId",
                table: "Companys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companys_vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId",
                table: "Companys",
                column: "vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companys_Acc_VoucherNoCreatedTypes_vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId",
                table: "Companys",
                column: "vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId",
                principalTable: "Acc_VoucherNoCreatedTypes",
                principalColumn: "VoucherNoCreatedTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
