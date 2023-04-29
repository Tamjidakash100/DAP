using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class SalesTermsSubs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesTermsSubs",
                columns: table => new
                {
                    SalesId = table.Column<int>(nullable: false),
                    Terms = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RowNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTermsSubs", x => x.SalesId);
                    table.ForeignKey(
                        name: "FK_SalesTermsSubs_SalesMains_SalesId",
                        column: x => x.SalesId,
                        principalTable: "SalesMains",
                        principalColumn: "SalesId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesTermsSubs");
        }
    }
}
