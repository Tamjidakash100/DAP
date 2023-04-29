using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GTERP.Migrations.GTRDB
{
    public partial class wh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_ProssType_WHDay",
                columns: table => new
                {
                    WHId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dtPunchDate = table.Column<DateTime>(nullable: true),
                    DaySts = table.Column<string>(maxLength: 20, nullable: true),
                    DayStsB = table.Column<string>(maxLength: 20, nullable: true),
                    Remarks = table.Column<string>(maxLength: 200, nullable: true),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_ProssType_WHDay", x => x.WHId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_ProssType_WHDay");
        }
    }
}
