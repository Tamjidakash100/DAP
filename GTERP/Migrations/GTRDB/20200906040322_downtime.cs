using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class downtime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "LabourStrike");

            migrationBuilder.DropColumn(
                name: "To",
                table: "LabourStrike");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "FromTime",
                table: "LabourStrike",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<float>(
                name: "MoneyLoss",
                table: "LabourStrike",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ProductionLoss",
                table: "LabourStrike",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ToTime",
                table: "LabourStrike",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromTime",
                table: "LabourStrike");

            migrationBuilder.DropColumn(
                name: "MoneyLoss",
                table: "LabourStrike");

            migrationBuilder.DropColumn(
                name: "ProductionLoss",
                table: "LabourStrike");

            migrationBuilder.DropColumn(
                name: "ToTime",
                table: "LabourStrike");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "From",
                table: "LabourStrike",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "To",
                table: "LabourStrike",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
