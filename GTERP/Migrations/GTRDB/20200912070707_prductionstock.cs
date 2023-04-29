using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class prductionstock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColosingBagStock",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "ColosingSeedStock",
                table: "Production");

            migrationBuilder.AddColumn<float>(
                name: "ClosingBagStock",
                table: "Production",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ClosingSeedStock",
                table: "Production",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingBagStock",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "ClosingSeedStock",
                table: "Production");

            migrationBuilder.AddColumn<float>(
                name: "ColosingBagStock",
                table: "Production",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ColosingSeedStock",
                table: "Production",
                type: "real",
                nullable: true);
        }
    }
}
