using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class salarysettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_SalarySettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpType = table.Column<string>(maxLength: 20, nullable: true),
                    LId = table.Column<int>(nullable: false),
                    BId = table.Column<int>(nullable: false),
                    BS = table.Column<float>(nullable: false),
                    HR = table.Column<float>(nullable: false),
                    HRExp = table.Column<float>(nullable: false),
                    MA = table.Column<float>(nullable: false),
                    GasAllowance = table.Column<float>(nullable: false),
                    GasCharge = table.Column<float>(nullable: false),
                    ElectricCharge = table.Column<float>(nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_SalarySettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_SalarySettings_Cat_BuildingType_BId",
                        column: x => x.BId,
                        principalTable: "Cat_BuildingType",
                        principalColumn: "BId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_SalarySettings_Cat_Location_LId",
                        column: x => x.LId,
                        principalTable: "Cat_Location",
                        principalColumn: "LId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_SalarySettings_BId",
                table: "Cat_SalarySettings",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_SalarySettings_LId",
                table: "Cat_SalarySettings",
                column: "LId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_SalarySettings");
        }
    }
}
