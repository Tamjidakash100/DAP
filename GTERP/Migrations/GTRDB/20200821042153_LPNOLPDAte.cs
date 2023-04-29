using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class LPNOLPDAte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LCDate",
                table: "GoodsReceiveMain");

            migrationBuilder.DropColumn(
                name: "LCNo",
                table: "GoodsReceiveMain");

            migrationBuilder.AddColumn<DateTime>(
                name: "LPDate",
                table: "GoodsReceiveMain",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LPNo",
                table: "GoodsReceiveMain",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LPDate",
                table: "GoodsReceiveMain");

            migrationBuilder.DropColumn(
                name: "LPNo",
                table: "GoodsReceiveMain");

            migrationBuilder.AddColumn<DateTime>(
                name: "LCDate",
                table: "GoodsReceiveMain",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LCNo",
                table: "GoodsReceiveMain",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
