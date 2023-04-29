using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class faprocessrecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FA_ProcessRecords",
                columns: table => new
                {
                    ProcessRecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FA_DetailsId = table.Column<int>(nullable: false),
                    DSDate = table.Column<DateTime>(nullable: false),
                    DEntryDate = table.Column<DateTime>(nullable: false),
                    NextDepDate = table.Column<DateTime>(nullable: false),
                    DepAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FA_ProcessRecords", x => x.ProcessRecordId);
                    table.ForeignKey(
                        name: "FK_FA_ProcessRecords_FA_Details_FA_DetailsId",
                        column: x => x.FA_DetailsId,
                        principalTable: "FA_Details",
                        principalColumn: "FA_DetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FA_ProcessRecords_FA_DetailsId",
                table: "FA_ProcessRecords",
                column: "FA_DetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FA_ProcessRecords");
        }
    }
}
