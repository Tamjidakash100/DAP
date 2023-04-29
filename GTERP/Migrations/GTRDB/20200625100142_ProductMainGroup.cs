using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class ProductMainGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductMainGroupId",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProssType",
                table: "Cat_IncomeTaxChk",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProductMainGroups",
                columns: table => new
                {
                    ProductMainGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductMainGroupCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ProductMainGroupDescription = table.Column<string>(maxLength: 300, nullable: false),
                    SLNo = table.Column<int>(nullable: false),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    IsInActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMainGroups", x => x.ProductMainGroupId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductMainGroupId",
                table: "Products",
                column: "ProductMainGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductMainGroups_ProductMainGroupId",
                table: "Products",
                column: "ProductMainGroupId",
                principalTable: "ProductMainGroups",
                principalColumn: "ProductMainGroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductMainGroups_ProductMainGroupId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductMainGroups");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductMainGroupId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductMainGroupId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "ProssType",
                table: "Cat_IncomeTaxChk",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);
        }
    }
}
