using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class utilitiesconsump : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Consumption",
                table: "UseUtilities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "GatePass",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Consumption",
                table: "UseUtilities");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "GatePass");
        }
    }
}
