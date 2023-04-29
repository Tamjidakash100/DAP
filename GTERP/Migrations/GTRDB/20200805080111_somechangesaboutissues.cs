using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class somechangesaboutissues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetCategory_AccountDetails_AccountDetailsId",
                table: "AssetCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetCategory_FinanceBook_FinanceBookId",
                table: "AssetCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueSubWarehouse_IssueSub_IssueSubId",
                table: "IssueSubWarehouse");

            migrationBuilder.DropIndex(
                name: "IX_AssetCategory_AccountDetailsId",
                table: "AssetCategory");

            migrationBuilder.DropIndex(
                name: "IX_AssetCategory_FinanceBookId",
                table: "AssetCategory");

            migrationBuilder.DropColumn(
                name: "AccountDetailsId",
                table: "AssetCategory");

            migrationBuilder.DropColumn(
                name: "FinanceBookId",
                table: "AssetCategory");

            migrationBuilder.AlterColumn<int>(
                name: "IssueSubId",
                table: "IssueSubWarehouse",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetCategoryId",
                table: "FinanceBook",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccumulatedDepreciationAccountId",
                table: "AccountDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetCategoryId",
                table: "AccountDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CapitalWorkInProgressAccount",
                table: "AccountDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "AccountDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepreciationExpenseAccountId",
                table: "AccountDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FixedAssetAccountId",
                table: "AccountDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Production",
                columns: table => new
                {
                    ProductionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(nullable: false),
                    ItemDescId = table.Column<int>(nullable: false),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    ProductionQty = table.Column<float>(nullable: false),
                    Addedby = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    Updatedby = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    comid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Production", x => x.ProductionId);
                    table.ForeignKey(
                        name: "FK_Production_ItemDescs_ItemDescId",
                        column: x => x.ItemDescId,
                        principalTable: "ItemDescs",
                        principalColumn: "ItemDescId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Production_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinanceBook_AssetCategoryId",
                table: "FinanceBook",
                column: "AssetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDetails_AssetCategoryId",
                table: "AccountDetails",
                column: "AssetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Production_ItemDescId",
                table: "Production",
                column: "ItemDescId");

            migrationBuilder.CreateIndex(
                name: "IX_Production_UnitId",
                table: "Production",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDetails_AssetCategory_AssetCategoryId",
                table: "AccountDetails",
                column: "AssetCategoryId",
                principalTable: "AssetCategory",
                principalColumn: "AssetCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinanceBook_AssetCategory_AssetCategoryId",
                table: "FinanceBook",
                column: "AssetCategoryId",
                principalTable: "AssetCategory",
                principalColumn: "AssetCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueSubWarehouse_IssueSub_IssueSubId",
                table: "IssueSubWarehouse",
                column: "IssueSubId",
                principalTable: "IssueSub",
                principalColumn: "IssueSubId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDetails_AssetCategory_AssetCategoryId",
                table: "AccountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_FinanceBook_AssetCategory_AssetCategoryId",
                table: "FinanceBook");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueSubWarehouse_IssueSub_IssueSubId",
                table: "IssueSubWarehouse");

            migrationBuilder.DropTable(
                name: "Production");

            migrationBuilder.DropIndex(
                name: "IX_FinanceBook_AssetCategoryId",
                table: "FinanceBook");

            migrationBuilder.DropIndex(
                name: "IX_AccountDetails_AssetCategoryId",
                table: "AccountDetails");

            migrationBuilder.DropColumn(
                name: "AssetCategoryId",
                table: "FinanceBook");

            migrationBuilder.DropColumn(
                name: "AccumulatedDepreciationAccountId",
                table: "AccountDetails");

            migrationBuilder.DropColumn(
                name: "AssetCategoryId",
                table: "AccountDetails");

            migrationBuilder.DropColumn(
                name: "CapitalWorkInProgressAccount",
                table: "AccountDetails");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "AccountDetails");

            migrationBuilder.DropColumn(
                name: "DepreciationExpenseAccountId",
                table: "AccountDetails");

            migrationBuilder.DropColumn(
                name: "FixedAssetAccountId",
                table: "AccountDetails");

            migrationBuilder.AlterColumn<int>(
                name: "IssueSubId",
                table: "IssueSubWarehouse",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AccountDetailsId",
                table: "AssetCategory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinanceBookId",
                table: "AssetCategory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_AccountDetailsId",
                table: "AssetCategory",
                column: "AccountDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetCategory_FinanceBookId",
                table: "AssetCategory",
                column: "FinanceBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetCategory_AccountDetails_AccountDetailsId",
                table: "AssetCategory",
                column: "AccountDetailsId",
                principalTable: "AccountDetails",
                principalColumn: "AccountDetailsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetCategory_FinanceBook_FinanceBookId",
                table: "AssetCategory",
                column: "FinanceBookId",
                principalTable: "FinanceBook",
                principalColumn: "FinanceBookId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueSubWarehouse_IssueSub_IssueSubId",
                table: "IssueSubWarehouse",
                column: "IssueSubId",
                principalTable: "IssueSub",
                principalColumn: "IssueSubId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
