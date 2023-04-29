using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class salsettupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_ElectricChargeSetting_Cat_Emp_Type_EmpTypeId",
                table: "Cat_ElectricChargeSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_Cat_GasChargeSetting_Cat_Emp_Type_EmpTypeId",
                table: "Cat_GasChargeSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_Cat_HRSetting_Cat_BuildingType_BId",
                table: "Cat_HRSetting");

            migrationBuilder.DropIndex(
                name: "IX_Cat_HRSetting_BId",
                table: "Cat_HRSetting");

            migrationBuilder.DropIndex(
                name: "IX_Cat_GasChargeSetting_EmpTypeId",
                table: "Cat_GasChargeSetting");

            migrationBuilder.DropIndex(
                name: "IX_Cat_ElectricChargeSetting_EmpTypeId",
                table: "Cat_ElectricChargeSetting");

            migrationBuilder.DropColumn(
                name: "BId",
                table: "Cat_HRSetting");

            migrationBuilder.DropColumn(
                name: "EmpTypeId",
                table: "Cat_GasChargeSetting");

            migrationBuilder.DropColumn(
                name: "EmpTypeId",
                table: "Cat_ElectricChargeSetting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BId",
                table: "Cat_HRSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmpTypeId",
                table: "Cat_GasChargeSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmpTypeId",
                table: "Cat_ElectricChargeSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cat_HRSetting_BId",
                table: "Cat_HRSetting",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_GasChargeSetting_EmpTypeId",
                table: "Cat_GasChargeSetting",
                column: "EmpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_ElectricChargeSetting_EmpTypeId",
                table: "Cat_ElectricChargeSetting",
                column: "EmpTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_ElectricChargeSetting_Cat_Emp_Type_EmpTypeId",
                table: "Cat_ElectricChargeSetting",
                column: "EmpTypeId",
                principalTable: "Cat_Emp_Type",
                principalColumn: "EmpTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_GasChargeSetting_Cat_Emp_Type_EmpTypeId",
                table: "Cat_GasChargeSetting",
                column: "EmpTypeId",
                principalTable: "Cat_Emp_Type",
                principalColumn: "EmpTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_HRSetting_Cat_BuildingType_BId",
                table: "Cat_HRSetting",
                column: "BId",
                principalTable: "Cat_BuildingType",
                principalColumn: "BId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
