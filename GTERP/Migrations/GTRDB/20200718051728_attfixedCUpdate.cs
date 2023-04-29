using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class attfixedCUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<float>(
            //    name: "OTHour",
            //    table: "HR_ProcessedData",
            //    nullable: false,
            //    oldClrType: typeof(TimeSpan),
            //    oldType: "time");

            //migrationBuilder.AlterColumn<float>(
            //    name: "OTHour",
            //    table: "HR_AttFixed",
            //    nullable: false,
            //    oldClrType: typeof(TimeSpan),
            //    oldType: "time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OTHour",
                table: "HR_ProcessedData",
                type: "time",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OTHour",
                table: "HR_AttFixed",
                type: "time",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
