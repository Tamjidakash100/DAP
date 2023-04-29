using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class FixedAssetMasterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_Acc_ChartOfAccountAccId",
                table: "fA_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_fA_Masters_depreciationFrequencies_FoD",
                table: "fA_Masters");

            migrationBuilder.DropIndex(
                name: "IX_fA_Masters_Acc_ChartOfAccountAccId",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "Acc_ChartOfAccountAccId",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "AccumulateDepreciationAccountId",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "DepreciationExpenseAccountId",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "SalvageParcentage",
                table: "fA_Masters");

            migrationBuilder.RenameColumn(
                name: "FoD",
                table: "fA_Masters",
                newName: "FOD");

            migrationBuilder.RenameIndex(
                name: "IX_fA_Masters_FoD",
                table: "fA_Masters",
                newName: "IX_fA_Masters_FOD");

            migrationBuilder.AddColumn<int>(
                name: "AccId_AccumulateDepreciation",
                table: "fA_Masters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccId_DepreciationExpense",
                table: "fA_Masters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AssetCode",
                table: "fA_Masters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_fA_Masters_AccId_AccumulateDepreciation",
                table: "fA_Masters",
                column: "AccId_AccumulateDepreciation");

            migrationBuilder.CreateIndex(
                name: "IX_fA_Masters_AccId_DepreciationExpense",
                table: "fA_Masters",
                column: "AccId_DepreciationExpense");

            migrationBuilder.AddForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_AccumulateDepreciation",
                table: "fA_Masters",
                column: "AccId_AccumulateDepreciation",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_DepreciationExpense",
                table: "fA_Masters",
                column: "AccId_DepreciationExpense",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_fA_Masters_depreciationFrequencies_FOD",
                table: "fA_Masters",
                column: "FOD",
                principalTable: "depreciationFrequencies",
                principalColumn: "FoDId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_AccumulateDepreciation",
                table: "fA_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_AccId_DepreciationExpense",
                table: "fA_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_fA_Masters_depreciationFrequencies_FOD",
                table: "fA_Masters");

            migrationBuilder.DropIndex(
                name: "IX_fA_Masters_AccId_AccumulateDepreciation",
                table: "fA_Masters");

            migrationBuilder.DropIndex(
                name: "IX_fA_Masters_AccId_DepreciationExpense",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "AccId_AccumulateDepreciation",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "AccId_DepreciationExpense",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "AssetCode",
                table: "fA_Masters");

            migrationBuilder.RenameColumn(
                name: "FOD",
                table: "fA_Masters",
                newName: "FoD");

            migrationBuilder.RenameIndex(
                name: "IX_fA_Masters_FOD",
                table: "fA_Masters",
                newName: "IX_fA_Masters_FoD");

            migrationBuilder.AddColumn<int>(
                name: "Acc_ChartOfAccountAccId",
                table: "fA_Masters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccumulateDepreciationAccountId",
                table: "fA_Masters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepreciationExpenseAccountId",
                table: "fA_Masters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "fA_Masters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SalvageParcentage",
                table: "fA_Masters",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_fA_Masters_Acc_ChartOfAccountAccId",
                table: "fA_Masters",
                column: "Acc_ChartOfAccountAccId");

            migrationBuilder.AddForeignKey(
                name: "FK_fA_Masters_Acc_ChartOfAccounts_Acc_ChartOfAccountAccId",
                table: "fA_Masters",
                column: "Acc_ChartOfAccountAccId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_fA_Masters_depreciationFrequencies_FoD",
                table: "fA_Masters",
                column: "FoD",
                principalTable: "depreciationFrequencies",
                principalColumn: "FoDId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
