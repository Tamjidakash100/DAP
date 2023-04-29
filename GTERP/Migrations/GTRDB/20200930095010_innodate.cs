using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class innodate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "INDate",
                table: "IssueMain",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "INNo",
                table: "IssueMain",
                maxLength: 25,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "INDate",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "INNo",
                table: "IssueMain");
        }
    }
}
