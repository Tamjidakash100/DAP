using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_AdditionalOptions_AdditionalOptionsId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_AssetCategory_AssetCategoryId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Items_ItemsItemId",
                table: "Asset");

            migrationBuilder.DropTable(
                name: "AccountDetails");

            migrationBuilder.DropTable(
                name: "AdditionalOptions");

            migrationBuilder.DropTable(
                name: "FinanceBook");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "AssetCategory");

            migrationBuilder.DropIndex(
                name: "IX_Asset_AdditionalOptionsId",
                table: "Asset");

            migrationBuilder.DropIndex(
                name: "IX_Asset_AssetCategoryId",
                table: "Asset");

            migrationBuilder.DropIndex(
                name: "IX_Asset_ItemsItemId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "AdditionalOptionsId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "AssetCategoryId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ItemsItemId",
                table: "Asset");

            migrationBuilder.AddColumn<int>(
                name: "DepreciationId",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "Asset",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Asset",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "ProductCategoryId",
                table: "Asset",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Asset",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseTypeId",
                table: "Asset",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                table: "Asset",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Depreciation",
                columns: table => new
                {
                    DepreciationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoD = table.Column<int>(nullable: false),
                    TNoD = table.Column<int>(nullable: false),
                    DMId = table.Column<int>(nullable: false),
                    DSDate = table.Column<DateTime>(nullable: false),
                    EVAULife = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depreciation", x => x.DepreciationId);
                    table.ForeignKey(
                        name: "FK_Depreciation_DepreciationMethod_DMId",
                        column: x => x.DMId,
                        principalTable: "DepreciationMethod",
                        principalColumn: "DMId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseType",
                columns: table => new
                {
                    PurchaseTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseType", x => x.PurchaseTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_DepreciationId",
                table: "Asset",
                column: "DepreciationId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ProductCategoryId",
                table: "Asset",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ProductId",
                table: "Asset",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_PurchaseTypeId",
                table: "Asset",
                column: "PurchaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_VendorId",
                table: "Asset",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Depreciation_DMId",
                table: "Depreciation",
                column: "DMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Depreciation_DepreciationId",
                table: "Asset",
                column: "DepreciationId",
                principalTable: "Depreciation",
                principalColumn: "DepreciationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_ProductCategory_ProductCategoryId",
                table: "Asset",
                column: "ProductCategoryId",
                principalTable: "ProductCategory",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Products_ProductId",
                table: "Asset",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_PurchaseType_PurchaseTypeId",
                table: "Asset",
                column: "PurchaseTypeId",
                principalTable: "PurchaseType",
                principalColumn: "PurchaseTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Suppliers_VendorId",
                table: "Asset",
                column: "VendorId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Depreciation_DepreciationId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_ProductCategory_ProductCategoryId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Products_ProductId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_PurchaseType_PurchaseTypeId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Suppliers_VendorId",
                table: "Asset");

            migrationBuilder.DropTable(
                name: "Depreciation");

            migrationBuilder.DropTable(
                name: "PurchaseType");

            migrationBuilder.DropIndex(
                name: "IX_Asset_DepreciationId",
                table: "Asset");

            migrationBuilder.DropIndex(
                name: "IX_Asset_ProductCategoryId",
                table: "Asset");

            migrationBuilder.DropIndex(
                name: "IX_Asset_ProductId",
                table: "Asset");

            migrationBuilder.DropIndex(
                name: "IX_Asset_PurchaseTypeId",
                table: "Asset");

            migrationBuilder.DropIndex(
                name: "IX_Asset_VendorId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "DepreciationId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "PurchaseTypeId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Asset");

            migrationBuilder.AddColumn<int>(
                name: "AdditionalOptionsId",
                table: "Asset",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetCategoryId",
                table: "Asset",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemsItemId",
                table: "Asset",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdditionalOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllowMonthlyDepreciation = table.Column<bool>(type: "bit", nullable: false),
                    CVADepreciation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalculateDepreciation = table.Column<bool>(type: "bit", nullable: false),
                    Custodian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentDeptId = table.Column<int>(type: "int", nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    IsExistingAsset = table.Column<bool>(type: "bit", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NDDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoDBooked = table.Column<int>(type: "int", nullable: false),
                    OADepreciation = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                name: "AssetCategory",
                columns: table => new
                {
                    AssetCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCategory", x => x.AssetCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllowAlternativeItem = table.Column<bool>(type: "bit", nullable: false),
                    AllowancePercentage = table.Column<bool>(type: "bit", nullable: false),
                    AutoCreateAssetsonPurchase = table.Column<bool>(type: "bit", nullable: false),
                    Brand = table.Column<bool>(type: "bit", nullable: false),
                    DOM = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    IncludeIteminManufacturing = table.Column<bool>(type: "bit", nullable: false),
                    IsFixedAsset = table.Column<bool>(type: "bit", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemGroupId = table.Column<int>(type: "int", nullable: true),
                    ItemHSCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "VARCHAR(MAX)", maxLength: 100, nullable: false),
                    ItemShortName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaintainStock = table.Column<bool>(type: "bit", nullable: false),
                    StandardSellingRate = table.Column<bool>(type: "bit", nullable: false),
                    UploadImage = table.Column<bool>(type: "bit", nullable: false),
                    ValuationRate = table.Column<bool>(type: "bit", nullable: false),
                    comid = table.Column<int>(type: "int", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
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
                name: "AccountDetails",
                columns: table => new
                {
                    AccountDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccumulatedDepreciationAccountId = table.Column<int>(type: "int", nullable: true),
                    AssetCategoryId = table.Column<int>(type: "int", nullable: true),
                    CapitalWorkInProgressAccount = table.Column<bool>(type: "bit", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: true),
                    DepreciationExpenseAccountId = table.Column<int>(type: "int", nullable: true),
                    FixedAssetAccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDetails", x => x.AccountDetailsId);
                    table.ForeignKey(
                        name: "FK_AccountDetails_AssetCategory_AssetCategoryId",
                        column: x => x.AssetCategoryId,
                        principalTable: "AssetCategory",
                        principalColumn: "AssetCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinanceBook",
                columns: table => new
                {
                    FinanceBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetCategoryId = table.Column<int>(type: "int", nullable: true),
                    DRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DTotal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepreciationMethodId = table.Column<int>(type: "int", nullable: false),
                    FoDepreciation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceBook", x => x.FinanceBookId);
                    table.ForeignKey(
                        name: "FK_FinanceBook_AssetCategory_AssetCategoryId",
                        column: x => x.AssetCategoryId,
                        principalTable: "AssetCategory",
                        principalColumn: "AssetCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinanceBook_DepreciationMethod_DepreciationMethodId",
                        column: x => x.DepreciationMethodId,
                        principalTable: "DepreciationMethod",
                        principalColumn: "DMId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AdditionalOptionsId",
                table: "Asset",
                column: "AdditionalOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetCategoryId",
                table: "Asset",
                column: "AssetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ItemsItemId",
                table: "Asset",
                column: "ItemsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDetails_AssetCategoryId",
                table: "AccountDetails",
                column: "AssetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalOptions_DepartmentDeptId",
                table: "AdditionalOptions",
                column: "DepartmentDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceBook_AssetCategoryId",
                table: "FinanceBook",
                column: "AssetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceBook_DepreciationMethodId",
                table: "FinanceBook",
                column: "DepreciationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemGroupId",
                table: "Items",
                column: "ItemGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_AdditionalOptions_AdditionalOptionsId",
                table: "Asset",
                column: "AdditionalOptionsId",
                principalTable: "AdditionalOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_AssetCategory_AssetCategoryId",
                table: "Asset",
                column: "AssetCategoryId",
                principalTable: "AssetCategory",
                principalColumn: "AssetCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Items_ItemsItemId",
                table: "Asset",
                column: "ItemsItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
