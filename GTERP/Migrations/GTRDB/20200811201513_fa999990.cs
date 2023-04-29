using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fa999990 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FA_FixedAssetCalculation");

            migrationBuilder.DropTable(
                name: "FA_FixedAssetSell");

            migrationBuilder.DropTable(
                name: "FA_FixedAssets");

            migrationBuilder.CreateTable(
                name: "fA_Masters",
                columns: table => new
                {
                    FA_MasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(nullable: true),
                    DMId = table.Column<int>(nullable: false),
                    Parcentage = table.Column<decimal>(nullable: false),
                    DepreciationExpenseAccountId = table.Column<int>(nullable: false),
                    AccumulateDepreciationAccountId = table.Column<int>(nullable: false),
                    FoD = table.Column<int>(nullable: false),
                    ComId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fA_Masters", x => x.FA_MasterId);
                    table.ForeignKey(
                        name: "FK_fA_Masters_DepreciationMethods_DMId",
                        column: x => x.DMId,
                        principalTable: "DepreciationMethods",
                        principalColumn: "DMId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fA_Masters_depreciationFrequencies_FoD",
                        column: x => x.FoD,
                        principalTable: "depreciationFrequencies",
                        principalColumn: "FoDId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fA_Masters_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FA_Details",
                columns: table => new
                {
                    FA_DetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FA_MasterId = table.Column<int>(nullable: false),
                    AssetItem = table.Column<string>(nullable: true),
                    IssuNo = table.Column<string>(nullable: true),
                    PurchseDate = table.Column<DateTime>(nullable: false),
                    PurchaseValue = table.Column<decimal>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    AssignTo = table.Column<string>(nullable: true),
                    UsefullLife = table.Column<int>(nullable: false),
                    RemainingYear = table.Column<int>(nullable: false),
                    EVAULife = table.Column<decimal>(nullable: false),
                    ComId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FA_Details", x => x.FA_DetailsId);
                    table.ForeignKey(
                        name: "FK_FA_Details_fA_Masters_FA_MasterId",
                        column: x => x.FA_MasterId,
                        principalTable: "fA_Masters",
                        principalColumn: "FA_MasterId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FA_Calculation",
                columns: table => new
                {
                    FA_CalculationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FA_DetailsId = table.Column<int>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    FA_MasterId = table.Column<int>(nullable: false),
                    Year = table.Column<string>(nullable: true),
                    Month = table.Column<string>(nullable: true),
                    CalculatedValue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FA_Calculation", x => x.FA_CalculationId);
                    table.ForeignKey(
                        name: "FK_FA_Calculation_FA_Details_FA_DetailsId",
                        column: x => x.FA_DetailsId,
                        principalTable: "FA_Details",
                        principalColumn: "FA_DetailsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FA_Calculation_fA_Masters_FA_MasterId",
                        column: x => x.FA_MasterId,
                        principalTable: "fA_Masters",
                        principalColumn: "FA_MasterId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "fA_Sells",
                columns: table => new
                {
                    FA_SellId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FA_DetailsId = table.Column<int>(nullable: false),
                    FA_MasterId = table.Column<int>(nullable: false),
                    SellsPrice = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fA_Sells", x => x.FA_SellId);
                    table.ForeignKey(
                        name: "FK_fA_Sells_FA_Details_FA_DetailsId",
                        column: x => x.FA_DetailsId,
                        principalTable: "FA_Details",
                        principalColumn: "FA_DetailsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fA_Sells_fA_Masters_FA_MasterId",
                        column: x => x.FA_MasterId,
                        principalTable: "fA_Masters",
                        principalColumn: "FA_MasterId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FA_Calculation_FA_DetailsId",
                table: "FA_Calculation",
                column: "FA_DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_FA_Calculation_FA_MasterId",
                table: "FA_Calculation",
                column: "FA_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_FA_Details_FA_MasterId",
                table: "FA_Details",
                column: "FA_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_fA_Masters_DMId",
                table: "fA_Masters",
                column: "DMId");

            migrationBuilder.CreateIndex(
                name: "IX_fA_Masters_FoD",
                table: "fA_Masters",
                column: "FoD");

            migrationBuilder.CreateIndex(
                name: "IX_fA_Masters_ProductId",
                table: "fA_Masters",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_fA_Sells_FA_DetailsId",
                table: "fA_Sells",
                column: "FA_DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_fA_Sells_FA_MasterId",
                table: "fA_Sells",
                column: "FA_MasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FA_Calculation");

            migrationBuilder.DropTable(
                name: "fA_Sells");

            migrationBuilder.DropTable(
                name: "FA_Details");

            migrationBuilder.DropTable(
                name: "fA_Masters");

            migrationBuilder.CreateTable(
                name: "FA_FixedAssetCalculation",
                columns: table => new
                {
                    FA_FixedAssetCalculationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalculatedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FA_FixedAssetCalculation", x => x.FA_FixedAssetCalculationId);
                });

            migrationBuilder.CreateTable(
                name: "FA_FixedAssets",
                columns: table => new
                {
                    FA_FixedAssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccumulateDepreciationAccountId = table.Column<int>(type: "int", nullable: false),
                    AssignTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DMId = table.Column<int>(type: "int", nullable: false),
                    DepreciationExpenseAccountId = table.Column<int>(type: "int", nullable: false),
                    DepreciationMethodDMId = table.Column<int>(type: "int", nullable: true),
                    DeprecitionRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EVAULife = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoD = table.Column<int>(type: "int", nullable: false),
                    IssuId = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PurchaseValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemainingYear = table.Column<int>(type: "int", nullable: false),
                    UsefullLife = table.Column<int>(type: "int", nullable: false)
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
                name: "FA_FixedAssetSell",
                columns: table => new
                {
                    FA_FixedAssetSellId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FA_FixedAssetId = table.Column<int>(type: "int", nullable: false),
                    SellsPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
    }
}
