using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class prdunitdeliverychallan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPrdUnit",
                table: "PrdUnits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrdUnitId",
                table: "DeliveryChallan",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryChallan_PrdUnitId",
                table: "DeliveryChallan",
                column: "PrdUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryChallan_PrdUnits_PrdUnitId",
                table: "DeliveryChallan",
                column: "PrdUnitId",
                principalTable: "PrdUnits",
                principalColumn: "PrdUnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryChallan_PrdUnits_PrdUnitId",
                table: "DeliveryChallan");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryChallan_PrdUnitId",
                table: "DeliveryChallan");

            migrationBuilder.DropColumn(
                name: "isPrdUnit",
                table: "PrdUnits");

            migrationBuilder.DropColumn(
                name: "PrdUnitId",
                table: "DeliveryChallan");
        }
    }
}
