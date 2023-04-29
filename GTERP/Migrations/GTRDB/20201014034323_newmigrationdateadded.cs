using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class newmigrationdateadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "fA_Masters",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "fA_Masters",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "fA_Masters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "fA_Masters",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "fA_Masters",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "FA_Details",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "FA_Details",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "FA_Details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "FA_Details",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "FA_Details",
                maxLength: 80,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "fA_Masters");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "FA_Details");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "FA_Details");
        }
    }
}
