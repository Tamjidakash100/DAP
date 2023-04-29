using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class winsummallowadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_SummurWinterAlowance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    IsSummer = table.Column<bool>(nullable: false),
                    IsWinter = table.Column<bool>(nullable: false),
                    IsRaincoat = table.Column<bool>(nullable: false),
                    WinterAllow = table.Column<float>(nullable: true),
                    RainCoatAllow = table.Column<float>(nullable: true),
                    GumbootAllow = table.Column<float>(nullable: true),
                    VatDed = table.Column<float>(nullable: true),
                    TaxDed = table.Column<float>(nullable: true),
                    Amount = table.Column<float>(nullable: true),
                    Stamp = table.Column<float>(nullable: true),
                    NetAmount = table.Column<float>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_SummurWinterAlowance", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_SummurWinterAlowance");
        }
    }
}
