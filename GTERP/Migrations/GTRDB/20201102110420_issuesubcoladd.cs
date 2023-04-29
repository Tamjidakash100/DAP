using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class issuesubcoladd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BalanceQty",
                table: "IssueSub",
                type: "decimal(18,3)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtToDate",
                table: "HR_ProcessLock",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceQty",
                table: "IssueSub");

            migrationBuilder.DropColumn(
                name: "DtToDate",
                table: "HR_ProcessLock");
        }
    }
}
