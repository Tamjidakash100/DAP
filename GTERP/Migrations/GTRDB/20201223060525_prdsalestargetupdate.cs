using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class prdsalestargetupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionTargetSetup_Products_ProductId",
                table: "ProductionTargetSetup");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesTargetSetup_Products_ProductId",
                table: "SalesTargetSetup");

            migrationBuilder.DropIndex(
                name: "IX_SalesTargetSetup_ProductId",
                table: "SalesTargetSetup");

            migrationBuilder.DropIndex(
                name: "IX_ProductionTargetSetup_ProductId",
                table: "ProductionTargetSetup");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SalesTargetSetup");

            migrationBuilder.DropColumn(
                name: "PrdProwerMonth",
                table: "ProductionTargetSetup");

            migrationBuilder.DropColumn(
                name: "PrdProwerYear",
                table: "ProductionTargetSetup");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductionTargetSetup");

            migrationBuilder.AddColumn<float>(
                name: "PrdCapacityMonth",
                table: "ProductionTargetSetup",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PrdCapacityYear",
                table: "ProductionTargetSetup",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<bool>(
                name: "isPrdUnit",
                table: "PrdUnits",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrdCapacityMonth",
                table: "ProductionTargetSetup");

            migrationBuilder.DropColumn(
                name: "PrdCapacityYear",
                table: "ProductionTargetSetup");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SalesTargetSetup",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PrdProwerMonth",
                table: "ProductionTargetSetup",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PrdProwerYear",
                table: "ProductionTargetSetup",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductionTargetSetup",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isPrdUnit",
                table: "PrdUnits",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.CreateIndex(
                name: "IX_SalesTargetSetup_ProductId",
                table: "SalesTargetSetup",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTargetSetup_ProductId",
                table: "ProductionTargetSetup",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionTargetSetup_Products_ProductId",
                table: "ProductionTargetSetup",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesTargetSetup_Products_ProductId",
                table: "SalesTargetSetup",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
