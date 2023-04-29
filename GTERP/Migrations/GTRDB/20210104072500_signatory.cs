using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class signatory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_ReportSignatory",
                columns: table => new
                {
                    SignatoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Signatory1 = table.Column<string>(maxLength: 30, nullable: false),
                    Signatory1B = table.Column<string>(maxLength: 30, nullable: true),
                    Signatory2 = table.Column<string>(maxLength: 30, nullable: true),
                    Signatory2B = table.Column<string>(maxLength: 30, nullable: true),
                    Signatory3 = table.Column<string>(maxLength: 30, nullable: true),
                    Signatory3B = table.Column<string>(maxLength: 30, nullable: true),
                    Signatory4 = table.Column<string>(maxLength: 30, nullable: true),
                    Signatory4B = table.Column<string>(maxLength: 30, nullable: true),
                    Signatory5 = table.Column<string>(maxLength: 30, nullable: true),
                    Signatory5B = table.Column<string>(maxLength: 30, nullable: true),
                    Signatory6 = table.Column<string>(maxLength: 30, nullable: true),
                    Signatory6B = table.Column<string>(maxLength: 30, nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_ReportSignatory", x => x.SignatoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_ReportSignatory");
        }
    }
}
