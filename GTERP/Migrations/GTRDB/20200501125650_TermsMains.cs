using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class TermsMains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TermsSub_TermsMain_TermsMainTermsId",
                table: "TermsSub");

            migrationBuilder.DropIndex(
                name: "IX_TermsSub_TermsMainTermsId",
                table: "TermsSub");

            migrationBuilder.DropColumn(
                name: "TermsMainTermsId",
                table: "TermsSub");

            migrationBuilder.AlterColumn<Guid>(
                name: "ComId",
                table: "CompanyPermissions",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_TermsSub_TermsId",
                table: "TermsSub",
                column: "TermsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TermsSub_TermsMain_TermsId",
                table: "TermsSub",
                column: "TermsId",
                principalTable: "TermsMain",
                principalColumn: "TermsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TermsSub_TermsMain_TermsId",
                table: "TermsSub");

            migrationBuilder.DropIndex(
                name: "IX_TermsSub_TermsId",
                table: "TermsSub");

            migrationBuilder.AddColumn<int>(
                name: "TermsMainTermsId",
                table: "TermsSub",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "CompanyPermissions",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(Guid),
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_TermsSub_TermsMainTermsId",
                table: "TermsSub",
                column: "TermsMainTermsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TermsSub_TermsMain_TermsMainTermsId",
                table: "TermsSub",
                column: "TermsMainTermsId",
                principalTable: "TermsMain",
                principalColumn: "TermsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
