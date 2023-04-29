using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class techmasterupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Technical",
                table: "Technical");

            migrationBuilder.DropColumn(
                name: "TechicalId",
                table: "Technical");

            migrationBuilder.DropColumn(
                name: "LicenseRcvName",
                table: "Technical");

            migrationBuilder.AlterColumn<string>(
                name: "MeetingType",
                table: "Technical",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TechnicalId",
                table: "Technical",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "LicenseApplicationDate",
                table: "Technical",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeetingType",
                table: "Cat_Meeting",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Meeting",
                table: "Cat_Meeting",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technical",
                table: "Technical",
                column: "TechnicalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Technical",
                table: "Technical");

            migrationBuilder.DropColumn(
                name: "TechnicalId",
                table: "Technical");

            migrationBuilder.DropColumn(
                name: "LicenseApplicationDate",
                table: "Technical");

            migrationBuilder.AlterColumn<string>(
                name: "MeetingType",
                table: "Technical",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TechicalId",
                table: "Technical",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "LicenseRcvName",
                table: "Technical",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeetingType",
                table: "Cat_Meeting",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Meeting",
                table: "Cat_Meeting",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technical",
                table: "Technical",
                column: "TechicalId");
        }
    }
}
