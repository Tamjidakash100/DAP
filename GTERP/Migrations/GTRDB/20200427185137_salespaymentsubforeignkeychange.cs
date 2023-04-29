using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class salespaymentsubforeignkeychange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesPaymentSubs",
                table: "SalesPaymentSubs");

            migrationBuilder.DropIndex(
                name: "IX_SalesPaymentSubs_SalesId",
                table: "SalesPaymentSubs");

            migrationBuilder.DropColumn(
                name: "SalesPaymentSubId",
                table: "SalesPaymentSubs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesPaymentSubs",
                table: "SalesPaymentSubs",
                column: "SalesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesPaymentSubs",
                table: "SalesPaymentSubs");

            migrationBuilder.AddColumn<int>(
                name: "SalesPaymentSubId",
                table: "SalesPaymentSubs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesPaymentSubs",
                table: "SalesPaymentSubs",
                column: "SalesPaymentSubId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPaymentSubs_SalesId",
                table: "SalesPaymentSubs",
                column: "SalesId");
        }
    }
}
