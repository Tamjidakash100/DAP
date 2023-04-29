using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class deletesalestermssub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesTermsSubs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesTermsSubs",
                columns: table => new
                {
                    SalesId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowNo = table.Column<int>(type: "int", nullable: false),
                    Terms = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
