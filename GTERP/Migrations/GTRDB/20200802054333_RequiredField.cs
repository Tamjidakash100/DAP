using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class RequiredField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StoreRequisitionMain_ComId_SRNo",
                table: "StoreRequisitionMain");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequisitionMain_ComId_PRNo",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderMain_ComId_PONo",
                table: "PurchaseOrderMain");

            migrationBuilder.DropIndex(
                name: "IX_IssueMain_ComId_IssueNo",
                table: "IssueMain");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiveMain_ComId_GRRNo",
                table: "GoodsReceiveMain");

            migrationBuilder.AlterColumn<string>(
                name: "SRNo",
                table: "StoreRequisitionMain",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PRNo",
                table: "PurchaseRequisitionMain",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PONo",
                table: "PurchaseOrderMain",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IssueNo",
                table: "IssueMain",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GRRNo",
                table: "GoodsReceiveMain",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreRequisitionMain_ComId_SRNo",
                table: "StoreRequisitionMain",
                columns: new[] { "ComId", "SRNo" },
                unique: true,
                filter: "[ComId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitionMain_ComId_PRNo",
                table: "PurchaseRequisitionMain",
                columns: new[] { "ComId", "PRNo" },
                unique: true,
                filter: "[ComId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderMain_ComId_PONo",
                table: "PurchaseOrderMain",
                columns: new[] { "ComId", "PONo" },
                unique: true,
                filter: "[ComId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_ComId_IssueNo",
                table: "IssueMain",
                columns: new[] { "ComId", "IssueNo" },
                unique: true,
                filter: "[ComId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveMain_ComId_GRRNo",
                table: "GoodsReceiveMain",
                columns: new[] { "ComId", "GRRNo" },
                unique: true,
                filter: "[ComId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StoreRequisitionMain_ComId_SRNo",
                table: "StoreRequisitionMain");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseRequisitionMain_ComId_PRNo",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderMain_ComId_PONo",
                table: "PurchaseOrderMain");

            migrationBuilder.DropIndex(
                name: "IX_IssueMain_ComId_IssueNo",
                table: "IssueMain");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiveMain_ComId_GRRNo",
                table: "GoodsReceiveMain");

            migrationBuilder.AlterColumn<string>(
                name: "SRNo",
                table: "StoreRequisitionMain",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PRNo",
                table: "PurchaseRequisitionMain",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PONo",
                table: "PurchaseOrderMain",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "IssueNo",
                table: "IssueMain",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "GRRNo",
                table: "GoodsReceiveMain",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_StoreRequisitionMain_ComId_SRNo",
                table: "StoreRequisitionMain",
                columns: new[] { "ComId", "SRNo" },
                unique: true,
                filter: "[ComId] IS NOT NULL AND [SRNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitionMain_ComId_PRNo",
                table: "PurchaseRequisitionMain",
                columns: new[] { "ComId", "PRNo" },
                unique: true,
                filter: "[ComId] IS NOT NULL AND [PRNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderMain_ComId_PONo",
                table: "PurchaseOrderMain",
                columns: new[] { "ComId", "PONo" },
                unique: true,
                filter: "[ComId] IS NOT NULL AND [PONo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_ComId_IssueNo",
                table: "IssueMain",
                columns: new[] { "ComId", "IssueNo" },
                unique: true,
                filter: "[ComId] IS NOT NULL AND [IssueNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveMain_ComId_GRRNo",
                table: "GoodsReceiveMain",
                columns: new[] { "ComId", "GRRNo" },
                unique: true,
                filter: "[ComId] IS NOT NULL AND [GRRNo] IS NOT NULL");
        }
    }
}
