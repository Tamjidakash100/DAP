using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Departmentid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "GoodsReceiveMain");

            migrationBuilder.AddColumn<float>(
                name: "GoodsRcvRtnQty",
                table: "Inventory",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "IssueRtnQty",
                table: "Inventory",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "Quality",
                table: "GoodsReceiveSub",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "GoodsReceiveMain",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveMain_DeptId",
                table: "GoodsReceiveMain",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsReceiveMain_Cat_Department_DeptId",
                table: "GoodsReceiveMain",
                column: "DeptId",
                principalTable: "Cat_Department",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsReceiveMain_Cat_Department_DeptId",
                table: "GoodsReceiveMain");

            migrationBuilder.DropIndex(
                name: "IX_GoodsReceiveMain_DeptId",
                table: "GoodsReceiveMain");

            migrationBuilder.DropColumn(
                name: "GoodsRcvRtnQty",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "IssueRtnQty",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "GoodsReceiveMain");

            migrationBuilder.AlterColumn<float>(
                name: "Quality",
                table: "GoodsReceiveSub",
                type: "real",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "GoodsReceiveMain",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
