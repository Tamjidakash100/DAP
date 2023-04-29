using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class salsetMin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinimumHRExp",
                table: "Cat_HRExpSetting");

            migrationBuilder.AddColumn<float>(
                name: "MinHR",
                table: "Cat_HRSetting",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinHR",
                table: "Cat_HRSetting");

            migrationBuilder.AddColumn<float>(
                name: "MinimumHRExp",
                table: "Cat_HRExpSetting",
                type: "real",
                nullable: true);
        }
    }
}
