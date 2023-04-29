using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class swallow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BS",
                table: "Cat_GasChargeSetting");

            migrationBuilder.DropColumn(
                name: "BS",
                table: "Cat_ElectricChargeSetting");

            migrationBuilder.CreateTable(
                name: "Cat_SummerWinterAllowance",
                columns: table => new
                {
                    SWAllowanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_Cat_SummerWinterAllowance", x => x.SWAllowanceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_SummerWinterAllowance");

            migrationBuilder.AddColumn<float>(
                name: "BS",
                table: "Cat_GasChargeSetting",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "BS",
                table: "Cat_ElectricChargeSetting",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
