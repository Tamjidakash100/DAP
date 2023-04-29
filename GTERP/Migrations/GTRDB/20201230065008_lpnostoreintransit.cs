using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class lpnostoreintransit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LPDate",
                table: "Acc_GovtSchedule_StoreInTransit",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LPNo",
                table: "Acc_GovtSchedule_StoreInTransit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LPDate",
                table: "Acc_GovtSchedule_StoreInTransit");

            migrationBuilder.DropColumn(
                name: "LPNo",
                table: "Acc_GovtSchedule_StoreInTransit");
        }
    }
}
