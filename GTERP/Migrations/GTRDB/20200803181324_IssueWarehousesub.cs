using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class IssueWarehousesub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueSubWarehouse",
                columns: table => new
                {
                    IssueSubWarehouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(nullable: true),
                    IssueQty = table.Column<float>(nullable: false),
                    IssueSubId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueSubWarehouse", x => x.IssueSubWarehouseId);
                    table.ForeignKey(
                        name: "FK_IssueSubWarehouse_IssueSub_IssueSubId",
                        column: x => x.IssueSubId,
                        principalTable: "IssueSub",
                        principalColumn: "IssueSubId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssueSubWarehouse_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueSubWarehouse_IssueSubId",
                table: "IssueSubWarehouse",
                column: "IssueSubId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueSubWarehouse_WarehouseId",
                table: "IssueSubWarehouse",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueSubWarehouse");
        }
    }
}
