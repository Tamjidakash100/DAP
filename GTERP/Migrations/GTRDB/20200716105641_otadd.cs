using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class otadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<TimeSpan>(
            //    name: "OTHour",
            //    table: "HR_ProcessedData",
            //    nullable: false,
            //    oldClrType: typeof(float),
            //    oldType: "real");

            migrationBuilder.AddColumn<float>(
                name: "OT",
                table: "HR_ProcessedData",
                nullable: false,
                defaultValue: 0f);

            //migrationBuilder.AlterColumn<TimeSpan>(
            //    name: "OTHour",
            //    table: "HR_AttFixed",
            //    nullable: false,
            //    oldClrType: typeof(float),
            //    oldType: "real");

            migrationBuilder.AddColumn<float>(
                name: "OT",
                table: "HR_AttFixed",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OT",
                table: "HR_ProcessedData");

            migrationBuilder.DropColumn(
                name: "OT",
                table: "HR_AttFixed");

            migrationBuilder.AlterColumn<float>(
                name: "OTHour",
                table: "HR_ProcessedData",
                type: "real",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<float>(
                name: "OTHour",
                table: "HR_AttFixed",
                type: "real",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }
    }
}
