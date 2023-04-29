using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class SomeChangesbyfahad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueMain_PaymentTypes_PaymentTypeId",
                table: "IssueMain");

            migrationBuilder.DropIndex(
                name: "IX_IssueMain_PaymentTypeId",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "ExpectedReciveDate",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "GateInHouseDate",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "TermsAndCondition",
                table: "IssueMain");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequiredDate",
                table: "StoreRequisitionMain",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "PONo",
                table: "PurchaseOrderMain",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "IssueSub",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IssueNo",
                table: "IssueMain",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "GoodsReceiveSub",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GRRNo",
                table: "GoodsReceiveMain",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                name: "IX_IssueSub_WarehouseId",
                table: "IssueSub",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_ComId_IssueNo",
                table: "IssueMain",
                columns: new[] { "ComId", "IssueNo" },
                unique: true,
                filter: "[ComId] IS NOT NULL AND [IssueNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveSub_WarehouseId",
                table: "GoodsReceiveSub",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveMain_ComId_GRRNo",
                table: "GoodsReceiveMain",
                columns: new[] { "ComId", "GRRNo" },
                unique: true,
                filter: "[ComId] IS NOT NULL AND [GRRNo] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiveSub_Warehouses_WarehouseId",
                table: "GoodsReceiveSub",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueSub_Warehouses_WarehouseId",
                table: "IssueSub",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiveSub_Warehouses_WarehouseId",
                table: "GoodsReceiveSub");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueSub_Warehouses_WarehouseId",
                table: "IssueSub");

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
                name: "IX_IssueSub_WarehouseId",
                table: "IssueSub");

            migrationBuilder.DropIndex(
                name: "IX_IssueMain_ComId_IssueNo",
                table: "IssueMain");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiveSub_WarehouseId",
                table: "GoodsReceiveSub");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiveMain_ComId_GRRNo",
                table: "GoodsReceiveMain");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "IssueSub");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "GoodsReceiveSub");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequiredDate",
                table: "StoreRequisitionMain",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PONo",
                table: "PurchaseOrderMain",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IssueNo",
                table: "IssueMain",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedReciveDate",
                table: "IssueMain",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GateInHouseDate",
                table: "IssueMain",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "IssueMain",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermsAndCondition",
                table: "IssueMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GRRNo",
                table: "GoodsReceiveMain",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssueMain_PaymentTypeId",
                table: "IssueMain",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueMain_PaymentTypes_PaymentTypeId",
                table: "IssueMain",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "PaymentTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
