using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class prdclassupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UseUtilities_Products_ProductId",
                table: "UseUtilities");

            migrationBuilder.DropIndex(
                name: "IX_UseUtilities_ProductId",
                table: "UseUtilities");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "UseUtilities");

            migrationBuilder.AlterColumn<string>(
                name: "TotalDownTime",
                table: "DownTime",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "UseUtilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "TotalDownTime",
                table: "DownTime",
                type: "real",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UseUtilities_ProductId",
                table: "UseUtilities",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_UseUtilities_Products_ProductId",
                table: "UseUtilities",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
