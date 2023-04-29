using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class representativeaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RepresentativeAddress",
                table: "Representative",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepresentativeMobile",
                table: "Representative",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepresentativeAddress",
                table: "Representative");

            migrationBuilder.DropColumn(
                name: "RepresentativeMobile",
                table: "Representative");
        }
    }
}
