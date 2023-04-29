using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GTERP.Migrations.GTRDB
{
    public partial class shareholdings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoteDescriptions",
                columns: table => new
                {
                    NoteDescriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteNo = table.Column<string>(nullable: true),
                    NoteDetails = table.Column<string>(nullable: true),
                    NoteRemarks = table.Column<string>(nullable: true),
                    SLNo = table.Column<int>(nullable: false),
                    FiscalYearId = table.Column<int>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    Updatedby = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    comid = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteDescriptions", x => x.NoteDescriptionId);
                    table.ForeignKey(
                        name: "FK_NoteDescriptions_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShareHoldings",
                columns: table => new
                {
                    ShareHoldingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteNo = table.Column<string>(nullable: true),
                    ShareHolderName = table.Column<string>(nullable: true),
                    ShareHolderDesignation = table.Column<string>(nullable: true),
                    SLNo = table.Column<int>(nullable: false),
                    NoOfShareHoldings = table.Column<int>(nullable: false),
                    FiscalYearId = table.Column<int>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    Updatedby = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    comid = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareHoldings", x => x.ShareHoldingId);
                    table.ForeignKey(
                        name: "FK_ShareHoldings_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteDescriptions_FiscalYearId",
                table: "NoteDescriptions",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ShareHoldings_FiscalYearId",
                table: "ShareHoldings",
                column: "FiscalYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteDescriptions");

            migrationBuilder.DropTable(
                name: "ShareHoldings");
        }
    }
}
