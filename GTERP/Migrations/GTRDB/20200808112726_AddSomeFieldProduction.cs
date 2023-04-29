using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class AddSomeFieldProduction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Production_Products_ProductId",
                table: "Production");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Production",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<float>(
                name: "AmmoniaPerTon",
                table: "Production",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PhosphoricPerTon",
                table: "Production",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SandPerTon",
                table: "Production",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SulfuricPerTon",
                table: "Production",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddForeignKey(
                name: "FK_Production_Products_ProductId",
                table: "Production",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Production_Products_ProductId",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "AmmoniaPerTon",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "PhosphoricPerTon",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "SandPerTon",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "SulfuricPerTon",
                table: "Production");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Production",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Production_Products_ProductId",
                table: "Production",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
