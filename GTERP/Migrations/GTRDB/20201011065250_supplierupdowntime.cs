using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class supplierupdowntime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Waste",
                table: "Cat_Waste");

            migrationBuilder.DropColumn(
                name: "License",
                table: "Cat_License");

            migrationBuilder.AddColumn<string>(
                name: "TinNo",
                table: "Suppliers",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TotalDownTime",
                table: "DownTime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cat_Waste",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LicenseNo",
                table: "Cat_License",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TinNo",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "TotalDownTime",
                table: "DownTime");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cat_Waste");

            migrationBuilder.DropColumn(
                name: "LicenseNo",
                table: "Cat_License");

            migrationBuilder.AddColumn<string>(
                name: "Waste",
                table: "Cat_Waste",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "License",
                table: "Cat_License",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
