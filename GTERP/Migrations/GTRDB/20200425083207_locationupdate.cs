using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class locationupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationNameShort",
                table: "Cat_Location",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationNameShortB",
                table: "Cat_Location",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationNameShort",
                table: "Cat_Location");

            migrationBuilder.DropColumn(
                name: "LocationNameShortB",
                table: "Cat_Location");
        }
    }
}
