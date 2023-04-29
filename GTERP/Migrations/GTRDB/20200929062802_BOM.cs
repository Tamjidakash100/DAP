using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class BOM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ProductionBagQty",
                table: "IssueMain",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ProductionSeedQty",
                table: "IssueMain",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BOMMain",
                columns: table => new
                {
                    BOMMainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    AssembleName = table.Column<string>(maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(maxLength: 300, nullable: true),
                    AddedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdatedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMMain", x => x.BOMMainId);
                    table.ForeignKey(
                        name: "FK_BOMMain_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BOMSub",
                columns: table => new
                {
                    BOMSubId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BOMMainId = table.Column<int>(nullable: false),
                    InvProductId = table.Column<int>(nullable: false),
                    Consumption = table.Column<float>(maxLength: 50, nullable: false),
                    Remarks = table.Column<string>(maxLength: 300, nullable: true),
                    AddedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdatedbyUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMSub", x => x.BOMSubId);
                    table.ForeignKey(
                        name: "FK_BOMSub_BOMMain_BOMMainId",
                        column: x => x.BOMMainId,
                        principalTable: "BOMMain",
                        principalColumn: "BOMMainId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOMSub_Products_InvProductId",
                        column: x => x.InvProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOMMain_ProductId",
                table: "BOMMain",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMSub_BOMMainId",
                table: "BOMSub",
                column: "BOMMainId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMSub_InvProductId",
                table: "BOMSub",
                column: "InvProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOMSub");

            migrationBuilder.DropTable(
                name: "BOMMain");

            migrationBuilder.DropColumn(
                name: "ProductionBagQty",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "ProductionSeedQty",
                table: "IssueMain");
        }
    }
}
