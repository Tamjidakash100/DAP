using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class catmeetingupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MeetingBangla",
                table: "Cat_Meeting",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SLNo",
                table: "Cat_Meeting",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetingBangla",
                table: "Cat_Meeting");

            migrationBuilder.DropColumn(
                name: "SLNo",
                table: "Cat_Meeting");
        }
    }
}
