using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class signatorydate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "Cat_ReportSignatory");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "Cat_ReportSignatory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "Cat_ReportSignatory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "Cat_ReportSignatory");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "Cat_ReportSignatory");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "Cat_ReportSignatory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
