using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class StatusforEverystep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReqStatus",
                table: "StoreRequisitionMain");

            migrationBuilder.DropColumn(
                name: "ReqStatus",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropColumn(
                name: "Addition",
                table: "GoodsReceiveMain");

            migrationBuilder.DropColumn(
                name: "Deduction",
                table: "GoodsReceiveMain");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "StoreRequisitionMain",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PurchaseRequisitionMain",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PurchaseOrderMain",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "IssueMain",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Addition",
                table: "GoodsReceiveSub",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Deduction",
                table: "GoodsReceiveSub",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "GoodsReceiveMain",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "StoreRequisitionMain");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PurchaseRequisitionMain");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PurchaseOrderMain");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "Addition",
                table: "GoodsReceiveSub");

            migrationBuilder.DropColumn(
                name: "Deduction",
                table: "GoodsReceiveSub");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "GoodsReceiveMain");

            migrationBuilder.AddColumn<string>(
                name: "ReqStatus",
                table: "StoreRequisitionMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReqStatus",
                table: "PurchaseRequisitionMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Addition",
                table: "GoodsReceiveMain",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Deduction",
                table: "GoodsReceiveMain",
                type: "real",
                nullable: true);
        }
    }
}
