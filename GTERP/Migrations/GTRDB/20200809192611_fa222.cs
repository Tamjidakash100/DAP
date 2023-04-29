using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fa222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoD",
                table: "Depreciations");

            migrationBuilder.AddColumn<int>(
                name: "FoDId",
                table: "Depreciations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "depreciationFrequencies",
                columns: table => new
                {
                    FoDId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ComId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_depreciationFrequencies", x => x.FoDId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Depreciations_FoDId",
                table: "Depreciations",
                column: "FoDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depreciations_depreciationFrequencies_FoDId",
                table: "Depreciations",
                column: "FoDId",
                principalTable: "depreciationFrequencies",
                principalColumn: "FoDId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depreciations_depreciationFrequencies_FoDId",
                table: "Depreciations");

            migrationBuilder.DropTable(
                name: "depreciationFrequencies");

            migrationBuilder.DropIndex(
                name: "IX_Depreciations_FoDId",
                table: "Depreciations");

            migrationBuilder.DropColumn(
                name: "FoDId",
                table: "Depreciations");

            migrationBuilder.AddColumn<int>(
                name: "FoD",
                table: "Depreciations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
