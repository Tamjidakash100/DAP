using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class salescheduleid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FA_SellId",
                table: "DepreciationScheduleSales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DepreciationScheduleSales_FA_SellId",
                table: "DepreciationScheduleSales",
                column: "FA_SellId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepreciationScheduleSales_fA_Sells_FA_SellId",
                table: "DepreciationScheduleSales",
                column: "FA_SellId",
                principalTable: "fA_Sells",
                principalColumn: "FA_SellId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepreciationScheduleSales_fA_Sells_FA_SellId",
                table: "DepreciationScheduleSales");

            migrationBuilder.DropIndex(
                name: "IX_DepreciationScheduleSales_FA_SellId",
                table: "DepreciationScheduleSales");

            migrationBuilder.DropColumn(
                name: "FA_SellId",
                table: "DepreciationScheduleSales");
        }
    }
}
