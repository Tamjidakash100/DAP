using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class longtextStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LongString",
                table: "UserLogingInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "UserLogingInfos",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongString",
                table: "UserLogingInfos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserLogingInfos");
        }
    }
}
