using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class GRRSubProvisionDebit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Addition",
                table: "GoodsReceiveProvision",
                newName: "Debit");

            migrationBuilder.AddColumn<decimal>(
                name: "Credit",
                table: "GoodsReceiveProvision",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credit",
                table: "GoodsReceiveProvision");

            migrationBuilder.RenameColumn(
                name: "Debit",
                table: "GoodsReceiveProvision",
                newName: "Addition");
        }
    }
}
