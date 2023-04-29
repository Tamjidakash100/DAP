using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class fa4444666666666 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DSADay",
                table: "depreciationFrequencies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DSAMonth",
                table: "depreciationFrequencies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DSADay",
                table: "depreciationFrequencies");

            migrationBuilder.DropColumn(
                name: "DSAMonth",
                table: "depreciationFrequencies");
        }
    }
}
