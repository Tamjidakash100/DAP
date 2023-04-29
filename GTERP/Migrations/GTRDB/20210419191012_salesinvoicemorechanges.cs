using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class salesinvoicemorechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesSubs_ProductSerial_ProductSerialId",
                table: "SalesSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesSubs_SalesType_SalesTypeId",
                table: "SalesSubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesSubs",
                table: "SalesSubs");

            migrationBuilder.AlterColumn<int>(
                name: "ProductSerialId",
                table: "SalesSubs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SalesTypeId",
                table: "SalesSubs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesSubs",
                table: "SalesSubs",
                columns: new[] { "SalesId", "ProductId", "ProductDescription" });

            migrationBuilder.AddForeignKey(
                name: "FK_SalesSubs_ProductSerial_ProductSerialId",
                table: "SalesSubs",
                column: "ProductSerialId",
                principalTable: "ProductSerial",
                principalColumn: "ProductSerialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesSubs_SalesType_SalesTypeId",
                table: "SalesSubs",
                column: "SalesTypeId",
                principalTable: "SalesType",
                principalColumn: "SalesTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesSubs_ProductSerial_ProductSerialId",
                table: "SalesSubs");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesSubs_SalesType_SalesTypeId",
                table: "SalesSubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesSubs",
                table: "SalesSubs");

            migrationBuilder.AlterColumn<int>(
                name: "SalesTypeId",
                table: "SalesSubs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductSerialId",
                table: "SalesSubs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesSubs_SalesType_SalesTypeId",
                table: "SalesSubs",
                column: "SalesTypeId",
                principalTable: "SalesType",
                principalColumn: "SalesTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
