using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class Termsmain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "TermsMain",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "TermsMain",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "TermsMain",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "useridUpdate",
                table: "TermsMain",
                maxLength: 128,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "TermsMain");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "TermsMain");

            migrationBuilder.DropColumn(
                name: "useridUpdate",
                table: "TermsMain");

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "TermsMain",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);
        }
    }
}
