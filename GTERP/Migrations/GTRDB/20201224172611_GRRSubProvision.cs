using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class GRRSubProvision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoodsReceiveProvision",
                columns: table => new
                {
                    GRRProvisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLNo = table.Column<int>(nullable: true),
                    AccId = table.Column<int>(nullable: false),
                    Addition = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    GRRMainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsReceiveProvision", x => x.GRRProvisionId);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveProvision_Acc_ChartOfAccounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Acc_ChartOfAccounts",
                        principalColumn: "AccId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoodsReceiveProvision_GoodsReceiveMain_GRRMainId",
                        column: x => x.GRRMainId,
                        principalTable: "GoodsReceiveMain",
                        principalColumn: "GRRMainId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveProvision_AccId",
                table: "GoodsReceiveProvision",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsReceiveProvision_GRRMainId",
                table: "GoodsReceiveProvision",
                column: "GRRMainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsReceiveProvision");
        }
    }
}
