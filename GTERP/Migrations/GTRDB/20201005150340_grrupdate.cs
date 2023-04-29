using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class grrupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CertificateDate",
                table: "GoodsReceiveMain",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CertificateNo",
                table: "GoodsReceiveMain",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ChallanDate",
                table: "GoodsReceiveMain",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChallanNo",
                table: "GoodsReceiveMain",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CertificateDate",
                table: "GoodsReceiveMain");

            migrationBuilder.DropColumn(
                name: "CertificateNo",
                table: "GoodsReceiveMain");

            migrationBuilder.DropColumn(
                name: "ChallanDate",
                table: "GoodsReceiveMain");

            migrationBuilder.DropColumn(
                name: "ChallanNo",
                table: "GoodsReceiveMain");
        }
    }
}
