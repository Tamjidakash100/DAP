using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class coscalculated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreReqId",
                table: "CostCalculated",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "CostCalculated",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_StoreReqId",
                table: "CostCalculated",
                column: "StoreReqId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_StoreRequisitionMain_StoreReqId",
                table: "CostCalculated",
                column: "StoreReqId",
                principalTable: "StoreRequisitionMain",
                principalColumn: "StoreReqId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_StoreRequisitionMain_StoreReqId",
                table: "CostCalculated");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_StoreReqId",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "StoreReqId",
                table: "CostCalculated");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "CostCalculated");
        }
    }
}
