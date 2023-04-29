using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class requisitionupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "INDate",
                table: "StoreRequisitionMain",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "INNo",
                table: "StoreRequisitionMain",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectId",
                table: "StoreRequisitionMain",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreRequisitionMain_SectId",
                table: "StoreRequisitionMain",
                column: "SectId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreRequisitionMain_Cat_Section_SectId",
                table: "StoreRequisitionMain",
                column: "SectId",
                principalTable: "Cat_Section",
                principalColumn: "SectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreRequisitionMain_Cat_Section_SectId",
                table: "StoreRequisitionMain");

            migrationBuilder.DropIndex(
                name: "IX_StoreRequisitionMain_SectId",
                table: "StoreRequisitionMain");

            migrationBuilder.DropColumn(
                name: "INDate",
                table: "StoreRequisitionMain");

            migrationBuilder.DropColumn(
                name: "INNo",
                table: "StoreRequisitionMain");

            migrationBuilder.DropColumn(
                name: "SectId",
                table: "StoreRequisitionMain");
        }
    }
}
