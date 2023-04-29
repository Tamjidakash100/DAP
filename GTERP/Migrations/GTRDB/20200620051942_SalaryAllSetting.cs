using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class SalaryAllSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_SalarySettings");

            migrationBuilder.CreateTable(
                name: "Cat_ElectricChargeSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTypeId = table.Column<int>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    BId = table.Column<int>(nullable: false),
                    BS = table.Column<float>(nullable: false),
                    ElectricCharge = table.Column<float>(nullable: false),
                    IsPersentage = table.Column<bool>(nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_ElectricChargeSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_ElectricChargeSetting_Cat_BuildingType_BId",
                        column: x => x.BId,
                        principalTable: "Cat_BuildingType",
                        principalColumn: "BId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_ElectricChargeSetting_Cat_Emp_Type_EmpTypeId",
                        column: x => x.EmpTypeId,
                        principalTable: "Cat_Emp_Type",
                        principalColumn: "EmpTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_ElectricChargeSetting_Cat_Location_LId",
                        column: x => x.LId,
                        principalTable: "Cat_Location",
                        principalColumn: "LId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cat_GasChargeSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTypeId = table.Column<int>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    BId = table.Column<int>(nullable: false),
                    BS = table.Column<float>(nullable: false),
                    GasCharge = table.Column<float>(nullable: false),
                    IsPersentage = table.Column<bool>(nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_GasChargeSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_GasChargeSetting_Cat_BuildingType_BId",
                        column: x => x.BId,
                        principalTable: "Cat_BuildingType",
                        principalColumn: "BId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_GasChargeSetting_Cat_Emp_Type_EmpTypeId",
                        column: x => x.EmpTypeId,
                        principalTable: "Cat_Emp_Type",
                        principalColumn: "EmpTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_GasChargeSetting_Cat_Location_LId",
                        column: x => x.LId,
                        principalTable: "Cat_Location",
                        principalColumn: "LId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cat_HRExpSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTypeId = table.Column<int>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    BId = table.Column<int>(nullable: false),
                    BS = table.Column<float>(nullable: false),
                    HRExp = table.Column<float>(nullable: false),
                    IsPersentage = table.Column<bool>(nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_HRExpSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_HRExpSetting_Cat_BuildingType_BId",
                        column: x => x.BId,
                        principalTable: "Cat_BuildingType",
                        principalColumn: "BId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_HRExpSetting_Cat_Emp_Type_EmpTypeId",
                        column: x => x.EmpTypeId,
                        principalTable: "Cat_Emp_Type",
                        principalColumn: "EmpTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_HRExpSetting_Cat_Location_LId",
                        column: x => x.LId,
                        principalTable: "Cat_Location",
                        principalColumn: "LId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cat_HRSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTypeId = table.Column<int>(nullable: false),
                    LId = table.Column<int>(nullable: false),
                    BId = table.Column<int>(nullable: false),
                    BS = table.Column<float>(nullable: false),
                    HR = table.Column<float>(nullable: false),
                    MA = table.Column<float>(nullable: false),
                    IsPersentage = table.Column<bool>(nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_HRSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_HRSetting_Cat_BuildingType_BId",
                        column: x => x.BId,
                        principalTable: "Cat_BuildingType",
                        principalColumn: "BId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_HRSetting_Cat_Emp_Type_EmpTypeId",
                        column: x => x.EmpTypeId,
                        principalTable: "Cat_Emp_Type",
                        principalColumn: "EmpTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_HRSetting_Cat_Location_LId",
                        column: x => x.LId,
                        principalTable: "Cat_Location",
                        principalColumn: "LId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_ElectricChargeSetting_BId",
                table: "Cat_ElectricChargeSetting",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_ElectricChargeSetting_EmpTypeId",
                table: "Cat_ElectricChargeSetting",
                column: "EmpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_ElectricChargeSetting_LId",
                table: "Cat_ElectricChargeSetting",
                column: "LId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_GasChargeSetting_BId",
                table: "Cat_GasChargeSetting",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_GasChargeSetting_EmpTypeId",
                table: "Cat_GasChargeSetting",
                column: "EmpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_GasChargeSetting_LId",
                table: "Cat_GasChargeSetting",
                column: "LId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_HRExpSetting_BId",
                table: "Cat_HRExpSetting",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_HRExpSetting_EmpTypeId",
                table: "Cat_HRExpSetting",
                column: "EmpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_HRExpSetting_LId",
                table: "Cat_HRExpSetting",
                column: "LId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_HRSetting_BId",
                table: "Cat_HRSetting",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_HRSetting_EmpTypeId",
                table: "Cat_HRSetting",
                column: "EmpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_HRSetting_LId",
                table: "Cat_HRSetting",
                column: "LId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_ElectricChargeSetting");

            migrationBuilder.DropTable(
                name: "Cat_GasChargeSetting");

            migrationBuilder.DropTable(
                name: "Cat_HRExpSetting");

            migrationBuilder.DropTable(
                name: "Cat_HRSetting");

            migrationBuilder.CreateTable(
                name: "Cat_SalarySettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BId = table.Column<int>(type: "int", nullable: false),
                    BS = table.Column<float>(type: "real", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ElectricCharge = table.Column<float>(type: "real", nullable: false),
                    EmpTypeId = table.Column<int>(type: "int", nullable: false),
                    GasAllowance = table.Column<float>(type: "real", nullable: false),
                    GasCharge = table.Column<float>(type: "real", nullable: false),
                    HR = table.Column<float>(type: "real", nullable: false),
                    HRExp = table.Column<float>(type: "real", nullable: false),
                    LId = table.Column<int>(type: "int", nullable: false),
                    MA = table.Column<float>(type: "real", nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
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
                        name: "FK_Cat_SalarySettings_Cat_Emp_Type_EmpTypeId",
                        column: x => x.EmpTypeId,
                        principalTable: "Cat_Emp_Type",
                        principalColumn: "EmpTypeId",
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
                name: "IX_Cat_SalarySettings_EmpTypeId",
                table: "Cat_SalarySettings",
                column: "EmpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_SalarySettings_LId",
                table: "Cat_SalarySettings",
                column: "LId");
        }
    }
}
