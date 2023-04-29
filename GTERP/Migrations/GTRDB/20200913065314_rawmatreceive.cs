using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class rawmatreceive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AmmoniaReceive",
                table: "Production",
                maxLength: 300,
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "PhosphoricReceive",
                table: "Production",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SandReceive",
                table: "Production",
                maxLength: 300,
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SulfuricReceive",
                table: "Production",
                maxLength: 300,
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmmoniaReceive",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "PhosphoricReceive",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "SandReceive",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "SulfuricReceive",
                table: "Production");
        }
    }
}
