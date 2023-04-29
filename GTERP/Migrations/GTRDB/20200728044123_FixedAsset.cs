using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class FixedAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountDetails",
                columns: table => new
                {
                    AccountDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDetails", x => x.AccountDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(nullable: true),
                    Custodian = table.Column<string>(nullable: true),
                    DeptId = table.Column<int>(nullable: false),
                    DepartmentDeptId = table.Column<int>(nullable: true),
                    IsExistingAsset = table.Column<bool>(nullable: false),
                    OADepreciation = table.Column<decimal>(nullable: false),
                    NoDBooked = table.Column<int>(nullable: false),
                    CVADepreciation = table.Column<decimal>(nullable: false),
                    NDDate = table.Column<DateTime>(nullable: false),
                    CalculateDepreciation = table.Column<bool>(nullable: false),
                    AllowMonthlyDepreciation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalOptions_Cat_Department_DepartmentDeptId",
                        column: x => x.DepartmentDeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepreciationMethod",
                columns: table => new
                {
                    DMId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DMName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepreciationMethod", x => x.DMId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(nullable: true),
                    ItemHSCode = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(type: "VARCHAR(MAX)", maxLength: 100, nullable: false),
                    ItemShortName = table.Column<string>(maxLength: 100, nullable: false),
                    DOM = table.Column<int>(nullable: false),
                    Disabled = table.Column<bool>(nullable: false),
                    AllowAlternativeItem = table.Column<bool>(nullable: false),
                    MaintainStock = table.Column<bool>(nullable: false),
                    IncludeIteminManufacturing = table.Column<bool>(nullable: false),
                    ValuationRate = table.Column<bool>(nullable: false),
                    StandardSellingRate = table.Column<bool>(nullable: false),
                    IsFixedAsset = table.Column<bool>(nullable: false),
                    AutoCreateAssetsonPurchase = table.Column<bool>(nullable: false),
                    AllowancePercentage = table.Column<bool>(nullable: false),
                    UploadImage = table.Column<bool>(nullable: false),
                    Brand = table.Column<bool>(nullable: false),
                    Description = table.Column<bool>(nullable: false),
                    ItemGroupId = table.Column<int>(nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    isDelete = table.Column<bool>(nullable: false),
                    comid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_ItemGroups_ItemGroupId",
                        column: x => x.ItemGroupId,
                        principalTable: "ItemGroups",
                        principalColumn: "ItemGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinanceBook",
                columns: table => new
                {
                    FinanceBookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepreciationMethodId = table.Column<int>(nullable: false),
                    FoDepreciation = table.Column<string>(nullable: true),
                    DTotal = table.Column<string>(nullable: true),
                    DRate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceBook", x => x.FinanceBookId);
                    table.ForeignKey(
                        name: "FK_FinanceBook_DepreciationMethod_DepreciationMethodId",
                        column: x => x.DepreciationMethodId,
                        principalTable: "DepreciationMethod",
                        principalColumn: "DMId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetCategory",
                columns: table => new
                {
                    AssetCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatName = table.Column<string>(nullable: true),
                    FinanceBookId = table.Column<int>(nullable: true),
                    AccountDetailsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCategory", x => x.AssetCategoryId);
                    table.ForeignKey(
                        name: "FK_AssetCategory_AccountDetails_AccountDetailsId",
                        column: x => x.AccountDetailsId,
                        principalTable: "AccountDetails",
                        principalColumn: "AccountDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetCategory_FinanceBook_FinanceBookId",
                        column: x => x.FinanceBookId,
                        principalTable: "FinanceBook",
                        principalColumn: "FinanceBookId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    AssetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetName = table.Column<string>(nullable: true),
                    ItemsItemId = table.Column<int>(nullable: true),
                    AdditionalOptionsId = table.Column<int>(nullable: true),
                    AssetCategoryId = table.Column<int>(nullable: false),
                    ComId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Asset_AdditionalOptions_AdditionalOptionsId",
                        column: x => x.AdditionalOptionsId,
                        principalTable: "AdditionalOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_AssetCategory_AssetCategoryId",
                        column: x => x.AssetCategoryId,
                        principalTable: "AssetCategory",
                        principalColumn: "AssetCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Companys_ComId",
                        column: x => x.ComId,
                        principalTable: "Companys",
                        principalColumn: "ComId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Items_ItemsItemId",
                        column: x => x.ItemsItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_Cat_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Cat_Location",
                        principalColumn: "LId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalOptions_DepartmentDeptId",
                table: "AdditionalOptions",
                column: "DepartmentDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AdditionalOptionsId",
                table: "Asset",
                column: "AdditionalOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetCategoryId",
                table: "Asset",
                column: "AssetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ComId",
                table: "Asset",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ItemsItemId",
                table: "Asset",
                column: "ItemsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_LocationId",
                table: "Asset",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_AccountDetailsId",
                table: "AssetCategory",
                column: "AccountDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_FinanceBookId",
                table: "AssetCategory",
                column: "FinanceBookId");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceBook_DepreciationMethodId",
                table: "FinanceBook",
                column: "DepreciationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemGroupId",
                table: "Items",
                column: "ItemGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "AdditionalOptions");

            migrationBuilder.DropTable(
                name: "AssetCategory");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "AccountDetails");

            migrationBuilder.DropTable(
                name: "FinanceBook");

            migrationBuilder.DropTable(
                name: "DepreciationMethod");
        }
    }
}
