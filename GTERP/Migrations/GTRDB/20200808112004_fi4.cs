using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fi4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depreciations_DepreciationMethod_DMId",
                table: "Depreciations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepreciationMethod",
                table: "DepreciationMethod");

            migrationBuilder.RenameTable(
                name: "DepreciationMethod",
                newName: "DepreciationMethods");

            migrationBuilder.AddColumn<float>(
                name: "UsefulLife",
                table: "Asset",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepreciationMethods",
                table: "DepreciationMethods",
                column: "DMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depreciations_DepreciationMethods_DMId",
                table: "Depreciations",
                column: "DMId",
                principalTable: "DepreciationMethods",
                principalColumn: "DMId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depreciations_DepreciationMethods_DMId",
                table: "Depreciations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepreciationMethods",
                table: "DepreciationMethods");

            migrationBuilder.DropColumn(
                name: "UsefulLife",
                table: "Asset");

            migrationBuilder.RenameTable(
                name: "DepreciationMethods",
                newName: "DepreciationMethod");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepreciationMethod",
                table: "DepreciationMethod",
                column: "DMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depreciations_DepreciationMethod_DMId",
                table: "Depreciations",
                column: "DMId",
                principalTable: "DepreciationMethod",
                principalColumn: "DMId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
