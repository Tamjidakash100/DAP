using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fa99999 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FA_FixedAssetCalculation_FA_FixedAssetAdd_FA_FixedAssetAddId",
                table: "FA_FixedAssetCalculation");

            migrationBuilder.DropTable(
                name: "FA_FixedAssetAdd");

            migrationBuilder.DropIndex(
                name: "IX_FA_FixedAssetCalculation_FA_FixedAssetAddId",
                table: "FA_FixedAssetCalculation");

            migrationBuilder.DropColumn(
                name: "FA_FixedAssetAddId",
                table: "FA_FixedAssetCalculation");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FA_FixedAssetSell",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignTo",
                table: "FA_FixedAssets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComId",
                table: "FA_FixedAssets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EVAULife",
                table: "FA_FixedAssets",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "FoD",
                table: "FA_FixedAssets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IssuId",
                table: "FA_FixedAssets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "FA_FixedAssets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "PurchaseValue",
                table: "FA_FixedAssets",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchseDate",
                table: "FA_FixedAssets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RemainingYear",
                table: "FA_FixedAssets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsefullLife",
                table: "FA_FixedAssets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "FA_FixedAssetCalculation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FA_FixedAssetSell");

            migrationBuilder.DropColumn(
                name: "AssignTo",
                table: "FA_FixedAssets");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "FA_FixedAssets");

            migrationBuilder.DropColumn(
                name: "EVAULife",
                table: "FA_FixedAssets");

            migrationBuilder.DropColumn(
                name: "FoD",
                table: "FA_FixedAssets");

            migrationBuilder.DropColumn(
                name: "IssuId",
                table: "FA_FixedAssets");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "FA_FixedAssets");

            migrationBuilder.DropColumn(
                name: "PurchaseValue",
                table: "FA_FixedAssets");

            migrationBuilder.DropColumn(
                name: "PurchseDate",
                table: "FA_FixedAssets");

            migrationBuilder.DropColumn(
                name: "RemainingYear",
                table: "FA_FixedAssets");

            migrationBuilder.DropColumn(
                name: "UsefullLife",
                table: "FA_FixedAssets");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "FA_FixedAssetCalculation");

            migrationBuilder.AddColumn<int>(
                name: "FA_FixedAssetAddId",
                table: "FA_FixedAssetCalculation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FA_FixedAssetAdd",
                columns: table => new
                {
                    FA_FixedAssetAddId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EVAULife = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FA_FixedAssetId = table.Column<int>(type: "int", nullable: false),
                    FoD = table.Column<int>(type: "int", nullable: false),
                    IssuId = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemainingYear = table.Column<int>(type: "int", nullable: false),
                    UsefullLife = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FA_FixedAssetAdd", x => x.FA_FixedAssetAddId);
                    table.ForeignKey(
                        name: "FK_FA_FixedAssetAdd_FA_FixedAssets_FA_FixedAssetId",
                        column: x => x.FA_FixedAssetId,
                        principalTable: "FA_FixedAssets",
                        principalColumn: "FA_FixedAssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FA_FixedAssetCalculation_FA_FixedAssetAddId",
                table: "FA_FixedAssetCalculation",
                column: "FA_FixedAssetAddId");

            migrationBuilder.CreateIndex(
                name: "IX_FA_FixedAssetAdd_FA_FixedAssetId",
                table: "FA_FixedAssetAdd",
                column: "FA_FixedAssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_FA_FixedAssetCalculation_FA_FixedAssetAdd_FA_FixedAssetAddId",
                table: "FA_FixedAssetCalculation",
                column: "FA_FixedAssetAddId",
                principalTable: "FA_FixedAssetAdd",
                principalColumn: "FA_FixedAssetAddId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
