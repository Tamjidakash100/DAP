using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class testingbyfahad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesSubs_ProductSerial_ProductSerialId",
                table: "SalesSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesSubs_SalesMains_SalesMainSalesId",
                table: "SalesSubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesSubs",
                table: "SalesSubs");

            migrationBuilder.DropIndex(
                name: "IX_SalesSubs_SalesMainSalesId",
                table: "SalesSubs");

            migrationBuilder.DropColumn(
                name: "testid",
                table: "SalesSubs");

            migrationBuilder.DropColumn(
                name: "SalesMainSalesId",
                table: "SalesSubs");

            migrationBuilder.AlterColumn<int>(
                name: "ProductSerialId",
                table: "SalesSubs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "SalesSubs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesId",
                table: "SalesSubs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesSubs",
                table: "SalesSubs",
                columns: new[] { "SalesId", "SalesTypeId", "ProductId", "ProductDescription", "ProductSerialId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SalesSubs_ProductSerial_ProductSerialId",
                table: "SalesSubs",
                column: "ProductSerialId",
                principalTable: "ProductSerial",
                principalColumn: "ProductSerialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesSubs_SalesMains_SalesId",
                table: "SalesSubs",
                column: "SalesId",
                principalTable: "SalesMains",
                principalColumn: "SalesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesSubs_ProductSerial_ProductSerialId",
                table: "SalesSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesSubs_SalesMains_SalesId",
                table: "SalesSubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesSubs",
                table: "SalesSubs");

            migrationBuilder.DropColumn(
                name: "SalesId",
                table: "SalesSubs");

            migrationBuilder.AlterColumn<int>(
                name: "ProductSerialId",
                table: "SalesSubs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "SalesSubs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "testid",
                table: "SalesSubs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SalesMainSalesId",
                table: "SalesSubs",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesSubs",
                table: "SalesSubs",
                column: "testid");

            migrationBuilder.CreateIndex(
                name: "IX_SalesSubs_SalesMainSalesId",
                table: "SalesSubs",
                column: "SalesMainSalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesSubs_ProductSerial_ProductSerialId",
                table: "SalesSubs",
                column: "ProductSerialId",
                principalTable: "ProductSerial",
                principalColumn: "ProductSerialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesSubs_SalesMains_SalesMainSalesId",
                table: "SalesSubs",
                column: "SalesMainSalesId",
                principalTable: "SalesMains",
                principalColumn: "SalesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
