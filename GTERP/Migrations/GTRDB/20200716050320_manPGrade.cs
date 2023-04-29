using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class manPGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "HR_LvEncashment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TtlManPowerWorker",
                table: "Cat_Grade",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "HR_LvEncashment");

            migrationBuilder.DropColumn(
                name: "TtlManPowerWorker",
                table: "Cat_Grade");
        }
    }
}
