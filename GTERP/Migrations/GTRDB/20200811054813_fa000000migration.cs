using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fa000000migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addedby",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "Updatedby",
                table: "Production");

            migrationBuilder.AddColumn<string>(
                name: "AddedbyUserId",
                table: "Production",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedbyUserId",
                table: "Production",
                maxLength: 128,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FA_FixedAssets",
                columns: table => new
                {
                    FA_FixedAssetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(nullable: true),
                    DMId = table.Column<int>(nullable: false),
                    DeprecitionRate = table.Column<decimal>(nullable: false),
                    DepreciationExpenseAccountId = table.Column<int>(nullable: false),
                    AccumulateDepreciationAccountId = table.Column<int>(nullable: false),
                    DepreciationMethodDMId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FA_FixedAssets", x => x.FA_FixedAssetId);
                    table.ForeignKey(
                        name: "FK_FA_FixedAssets_DepreciationMethods_DepreciationMethodDMId",
                        column: x => x.DepreciationMethodDMId,
                        principalTable: "DepreciationMethods",
                        principalColumn: "DMId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FA_FixedAssets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FA_FixedAssetAdd",
                columns: table => new
                {
                    FA_FixedAssetAddId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssuId = table.Column<int>(nullable: false),
                    PurchseDate = table.Column<DateTime>(nullable: false),
                    FA_FixedAssetId = table.Column<int>(nullable: false),
                    PurchaseValue = table.Column<decimal>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    AssignTo = table.Column<string>(nullable: true),
                    UsefullLife = table.Column<int>(nullable: false),
                    RemainingYear = table.Column<int>(nullable: false),
                    FoD = table.Column<int>(nullable: false),
                    EVAULife = table.Column<decimal>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "FA_FixedAssetSell",
                columns: table => new
                {
                    FA_FixedAssetSellId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FA_FixedAssetId = table.Column<int>(nullable: false),
                    SellsPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FA_FixedAssetSell", x => x.FA_FixedAssetSellId);
                    table.ForeignKey(
                        name: "FK_FA_FixedAssetSell_FA_FixedAssets_FA_FixedAssetId",
                        column: x => x.FA_FixedAssetId,
                        principalTable: "FA_FixedAssets",
                        principalColumn: "FA_FixedAssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FA_FixedAssetCalculation",
                columns: table => new
                {
                    FA_FixedAssetCalculationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FA_FixedAssetAddId = table.Column<int>(nullable: false),
                    Year = table.Column<string>(nullable: true),
                    Month = table.Column<string>(nullable: true),
                    CalculatedValue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FA_FixedAssetCalculation", x => x.FA_FixedAssetCalculationId);
                    table.ForeignKey(
                        name: "FK_FA_FixedAssetCalculation_FA_FixedAssetAdd_FA_FixedAssetAddId",
                        column: x => x.FA_FixedAssetAddId,
                        principalTable: "FA_FixedAssetAdd",
                        principalColumn: "FA_FixedAssetAddId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FA_FixedAssetAdd_FA_FixedAssetId",
                table: "FA_FixedAssetAdd",
                column: "FA_FixedAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_FA_FixedAssetCalculation_FA_FixedAssetAddId",
                table: "FA_FixedAssetCalculation",
                column: "FA_FixedAssetAddId");

            migrationBuilder.CreateIndex(
                name: "IX_FA_FixedAssets_DepreciationMethodDMId",
                table: "FA_FixedAssets",
                column: "DepreciationMethodDMId");

            migrationBuilder.CreateIndex(
                name: "IX_FA_FixedAssets_ProductId",
                table: "FA_FixedAssets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FA_FixedAssetSell_FA_FixedAssetId",
                table: "FA_FixedAssetSell",
                column: "FA_FixedAssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FA_FixedAssetCalculation");

            migrationBuilder.DropTable(
                name: "FA_FixedAssetSell");

            migrationBuilder.DropTable(
                name: "FA_FixedAssetAdd");

            migrationBuilder.DropTable(
                name: "FA_FixedAssets");

            migrationBuilder.DropColumn(
                name: "AddedbyUserId",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "UpdatedbyUserId",
                table: "Production");

            migrationBuilder.AddColumn<string>(
                name: "Addedby",
                table: "Production",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Updatedby",
                table: "Production",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
