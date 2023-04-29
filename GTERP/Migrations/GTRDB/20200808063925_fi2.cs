using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Companys_ComId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Depreciation_DepreciationId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_PurchaseType_PurchaseTypeId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Depreciation_DepreciationMethod_DMId",
                table: "Depreciation");

            migrationBuilder.DropIndex(
                name: "IX_Asset_ComId",
                table: "Asset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseType",
                table: "PurchaseType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Depreciation",
                table: "Depreciation");

            migrationBuilder.RenameTable(
                name: "PurchaseType",
                newName: "PurchaseTypes");

            migrationBuilder.RenameTable(
                name: "Depreciation",
                newName: "Depreciations");

            migrationBuilder.RenameIndex(
                name: "IX_Depreciation_DMId",
                table: "Depreciations",
                newName: "IX_Depreciations_DMId");

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Asset",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CompanyComId",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComId",
                table: "PurchaseTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComId",
                table: "Depreciations",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseTypes",
                table: "PurchaseTypes",
                column: "PurchaseTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Depreciations",
                table: "Depreciations",
                column: "DepreciationId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_CompanyComId",
                table: "Asset",
                column: "CompanyComId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Companys_CompanyComId",
                table: "Asset",
                column: "CompanyComId",
                principalTable: "Companys",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Depreciations_DepreciationId",
                table: "Asset",
                column: "DepreciationId",
                principalTable: "Depreciations",
                principalColumn: "DepreciationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_PurchaseTypes_PurchaseTypeId",
                table: "Asset",
                column: "PurchaseTypeId",
                principalTable: "PurchaseTypes",
                principalColumn: "PurchaseTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Depreciations_DepreciationMethod_DMId",
                table: "Depreciations",
                column: "DMId",
                principalTable: "DepreciationMethod",
                principalColumn: "DMId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Companys_CompanyComId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Depreciations_DepreciationId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_PurchaseTypes_PurchaseTypeId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Depreciations_DepreciationMethod_DMId",
                table: "Depreciations");

            migrationBuilder.DropIndex(
                name: "IX_Asset_CompanyComId",
                table: "Asset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseTypes",
                table: "PurchaseTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Depreciations",
                table: "Depreciations");

            migrationBuilder.DropColumn(
                name: "CompanyComId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "PurchaseTypes");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Depreciations");

            migrationBuilder.RenameTable(
                name: "PurchaseTypes",
                newName: "PurchaseType");

            migrationBuilder.RenameTable(
                name: "Depreciations",
                newName: "Depreciation");

            migrationBuilder.RenameIndex(
                name: "IX_Depreciations_DMId",
                table: "Depreciation",
                newName: "IX_Depreciation_DMId");

            migrationBuilder.AlterColumn<int>(
                name: "ComId",
                table: "Asset",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseType",
                table: "PurchaseType",
                column: "PurchaseTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Depreciation",
                table: "Depreciation",
                column: "DepreciationId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_ComId",
                table: "Asset",
                column: "ComId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Companys_ComId",
                table: "Asset",
                column: "ComId",
                principalTable: "Companys",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Depreciation_DepreciationId",
                table: "Asset",
                column: "DepreciationId",
                principalTable: "Depreciation",
                principalColumn: "DepreciationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_PurchaseType_PurchaseTypeId",
                table: "Asset",
                column: "PurchaseTypeId",
                principalTable: "PurchaseType",
                principalColumn: "PurchaseTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Depreciation_DepreciationMethod_DMId",
                table: "Depreciation",
                column: "DMId",
                principalTable: "DepreciationMethod",
                principalColumn: "DMId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
