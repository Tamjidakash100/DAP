using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class prosslockupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DtTran",
                table: "HR_ProcessLock");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "HR_ProcessLock",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "HR_ProcessLock",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "HR_ProcessLock",
                maxLength: 80,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "HR_ProcessLock");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "HR_ProcessLock");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "HR_ProcessLock");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtTran",
                table: "HR_ProcessLock",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
