using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class voucehrRefCustomerSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Acc_VoucherSubs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Acc_VoucherSubs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubs_CustomerId",
                table: "Acc_VoucherSubs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_VoucherSubs_SupplierId",
                table: "Acc_VoucherSubs",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubs_Customers_CustomerId",
                table: "Acc_VoucherSubs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acc_VoucherSubs_Suppliers_SupplierId",
                table: "Acc_VoucherSubs",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubs_Customers_CustomerId",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_Acc_VoucherSubs_Suppliers_SupplierId",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubs_CustomerId",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropIndex(
                name: "IX_Acc_VoucherSubs_SupplierId",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Acc_VoucherSubs");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Acc_VoucherSubs");
        }
    }
}
