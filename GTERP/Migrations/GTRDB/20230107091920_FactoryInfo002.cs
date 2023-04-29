using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class FactoryInfo002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenningBalance",
                table: "FactoryInfos");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "FactoryInfos",
                newName: "Production");

            migrationBuilder.RenameColumn(
                name: "Producttion",
                table: "FactoryInfos",
                newName: "OpeningBalance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Production",
                table: "FactoryInfos",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "OpeningBalance",
                table: "FactoryInfos",
                newName: "Producttion");

            migrationBuilder.AddColumn<decimal>(
                name: "OpenningBalance",
                table: "FactoryInfos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
