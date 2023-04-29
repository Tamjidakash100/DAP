using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fa2221 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "depreciationFrequencies");

            migrationBuilder.AddColumn<string>(
                name: "CompoundingPeriod",
                table: "depreciationFrequencies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FractionOfOneYear",
                table: "depreciationFrequencies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompoundingPeriod",
                table: "depreciationFrequencies");

            migrationBuilder.DropColumn(
                name: "FractionOfOneYear",
                table: "depreciationFrequencies");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "depreciationFrequencies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
