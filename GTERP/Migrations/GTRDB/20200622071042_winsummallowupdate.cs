using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class winsummallowupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_SummerWinterAllowance");

            migrationBuilder.DropTable(
                name: "HR_SummurWinterAlowance");

            migrationBuilder.CreateTable(
                name: "Cat_SummerWinterAllowanceSetting",
                columns: table => new
                {
                    SWAllowanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dtMonth = table.Column<DateTime>(nullable: false),
                    SummerAllow = table.Column<float>(nullable: false),
                    WinterAllow = table.Column<float>(nullable: false),
                    RainCoatAndGumbootAllow = table.Column<float>(nullable: false),
                    VatDiduction = table.Column<float>(nullable: false),
                    TaxDiduction = table.Column<float>(nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_SummerWinterAllowanceSetting", x => x.SWAllowanceId);
                });

            migrationBuilder.CreateTable(
                name: "HR_SummerWinterAllowance",
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
                    table.PrimaryKey("PK_HR_SummerWinterAllowance", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_SummerWinterAllowanceSetting");

            migrationBuilder.DropTable(
                name: "HR_SummerWinterAllowance");

            migrationBuilder.CreateTable(
                name: "Cat_SummerWinterAllowance",
                columns: table => new
                {
                    SWAllowanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RainCoatAndGumbootAllow = table.Column<float>(type: "real", nullable: false),
                    SummerAllow = table.Column<float>(type: "real", nullable: false),
                    TaxDiduction = table.Column<float>(type: "real", nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    VatDiduction = table.Column<float>(type: "real", nullable: false),
                    WinterAllow = table.Column<float>(type: "real", nullable: false),
                    dtMonth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_SummerWinterAllowance", x => x.SWAllowanceId);
                });

            migrationBuilder.CreateTable(
                name: "HR_SummurWinterAlowance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(type: "real", nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    GumbootAllow = table.Column<float>(type: "real", nullable: true),
                    IsRaincoat = table.Column<bool>(type: "bit", nullable: false),
                    IsSummer = table.Column<bool>(type: "bit", nullable: false),
                    IsWinter = table.Column<bool>(type: "bit", nullable: false),
                    NetAmount = table.Column<float>(type: "real", nullable: true),
                    RainCoatAllow = table.Column<float>(type: "real", nullable: true),
                    Stamp = table.Column<float>(type: "real", nullable: true),
                    TaxDed = table.Column<float>(type: "real", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    VatDed = table.Column<float>(type: "real", nullable: true),
                    WinterAllow = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_SummurWinterAlowance", x => x.Id);
                });
        }
    }
}
