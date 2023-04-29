using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class GRRSubProvisionDebitAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Debit",
                table: "GoodsReceiveProvision",
                newName: "DebitAmount");

            migrationBuilder.RenameColumn(
                name: "Credit",
                table: "GoodsReceiveProvision",
                newName: "CreditAmount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DebitAmount",
                table: "GoodsReceiveProvision",
                newName: "Debit");

            migrationBuilder.RenameColumn(
                name: "CreditAmount",
                table: "GoodsReceiveProvision",
                newName: "Credit");
        }
    }
}
