using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class costallowupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostAllocation_Distribute_CostAllocation_Main_CostAllocationMainId",
                table: "CostAllocation_Distribute");

            migrationBuilder.DropIndex(
                name: "IX_CostAllocation_Distribute_CostAllocationMainId",
                table: "CostAllocation_Distribute");

            migrationBuilder.DropColumn(
                name: "CostAllocationMainId",
                table: "CostAllocation_Distribute");

            migrationBuilder.CreateIndex(
                name: "IX_CostAllocation_Distribute_CostAlloMainId",
                table: "CostAllocation_Distribute",
                column: "CostAlloMainId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostAllocation_Distribute_CostAllocation_Main_CostAlloMainId",
                table: "CostAllocation_Distribute",
                column: "CostAlloMainId",
                principalTable: "CostAllocation_Main",
                principalColumn: "CostAlloMainId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostAllocation_Distribute_CostAllocation_Main_CostAlloMainId",
                table: "CostAllocation_Distribute");

            migrationBuilder.DropIndex(
                name: "IX_CostAllocation_Distribute_CostAlloMainId",
                table: "CostAllocation_Distribute");

            migrationBuilder.AddColumn<int>(
                name: "CostAllocationMainId",
                table: "CostAllocation_Distribute",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CostAllocation_Distribute_CostAllocationMainId",
                table: "CostAllocation_Distribute",
                column: "CostAllocationMainId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostAllocation_Distribute_CostAllocation_Main_CostAllocationMainId",
                table: "CostAllocation_Distribute",
                column: "CostAllocationMainId",
                principalTable: "CostAllocation_Main",
                principalColumn: "CostAlloMainId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
