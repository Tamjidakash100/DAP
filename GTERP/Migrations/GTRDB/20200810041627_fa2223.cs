using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fa2223 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Cat_Location_LocationId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Products_ProductId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Suppliers_VendorId",
                table: "Asset");

            migrationBuilder.AlterColumn<int>(
                name: "VendorId",
                table: "Asset",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Asset",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Asset",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentStateId",
                table: "Asset",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Cat_Location_LocationId",
                table: "Asset",
                column: "LocationId",
                principalTable: "Cat_Location",
                principalColumn: "LId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Products_ProductId",
                table: "Asset",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
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
                name: "FK_Asset_Cat_Location_LocationId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Products_ProductId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Suppliers_VendorId",
                table: "Asset");

            migrationBuilder.AlterColumn<int>(
                name: "VendorId",
                table: "Asset",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Asset",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Asset",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentStateId",
                table: "Asset",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Cat_Location_LocationId",
                table: "Asset",
                column: "LocationId",
                principalTable: "Cat_Location",
                principalColumn: "LId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Products_ProductId",
                table: "Asset",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Suppliers_VendorId",
                table: "Asset",
                column: "VendorId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
