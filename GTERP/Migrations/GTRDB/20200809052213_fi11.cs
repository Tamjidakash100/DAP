using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fi11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssetCurrentStateCurrentStateId",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignComponent",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignedTo",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentStateId",
                table: "Asset",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "Asset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Asset",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "assetCurrentStates",
                columns: table => new
                {
                    CurrentStateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentState = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assetCurrentStates", x => x.CurrentStateId);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true),
                    ComId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetCurrentStateCurrentStateId",
                table: "Asset",
                column: "AssetCurrentStateCurrentStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_assetCurrentStates_AssetCurrentStateCurrentStateId",
                table: "Asset",
                column: "AssetCurrentStateCurrentStateId",
                principalTable: "assetCurrentStates",
                principalColumn: "CurrentStateId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_assetCurrentStates_AssetCurrentStateCurrentStateId",
                table: "Asset");

            migrationBuilder.DropTable(
                name: "assetCurrentStates");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_Asset_AssetCurrentStateCurrentStateId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "AssetCurrentStateCurrentStateId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "AssignComponent",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "AssignedTo",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "CurrentStateId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "Asset");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Asset");
        }
    }
}
