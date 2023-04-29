using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class LCNOLCDAte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LCDate",
                table: "GoodsReceiveMain",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LCNo",
                table: "GoodsReceiveMain",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LCDate",
                table: "GoodsReceiveMain");

            migrationBuilder.DropColumn(
                name: "LCNo",
                table: "GoodsReceiveMain");
        }
    }
}
