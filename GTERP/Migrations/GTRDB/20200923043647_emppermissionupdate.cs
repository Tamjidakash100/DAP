using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class emppermissionupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePermission");

            migrationBuilder.AddColumn<bool>(
                name: "IsMainWarehouse",
                table: "Warehouses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMedicalWarehouse",
                table: "Warehouses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsProductionWarehouse",
                table: "Warehouses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "HR_Employee_VariablePermission",
                columns: table => new
                {
                    EmpPermissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    EmpSecretId = table.Column<string>(maxLength: 128, nullable: true),
                    IsStoreRateCheck = table.Column<bool>(nullable: false),
                    IsMainStorePerson = table.Column<bool>(nullable: false),
                    IsSubStorePerson = table.Column<bool>(nullable: false),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UerId = table.Column<string>(maxLength: 128, nullable: true),
                    UserIdUpdated = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Employee_VariablePermission", x => x.EmpPermissionId);
                    table.ForeignKey(
                        name: "FK_HR_Employee_VariablePermission_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Employee_VariablePermission_EmpId",
                table: "HR_Employee_VariablePermission",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Employee_VariablePermission");

            migrationBuilder.DropColumn(
                name: "IsMainWarehouse",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "IsMedicalWarehouse",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "IsProductionWarehouse",
                table: "Warehouses");

            migrationBuilder.CreateTable(
                name: "EmployeePermission",
                columns: table => new
                {
                    EmpPermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    EmpSecretId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IsMainStorePerson = table.Column<bool>(type: "bit", nullable: false),
                    IsStoreRateCheck = table.Column<bool>(type: "bit", nullable: false),
                    IsSubStorePerson = table.Column<bool>(type: "bit", nullable: false),
                    UerId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UserIdUpdated = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePermission", x => x.EmpPermissionId);
                    table.ForeignKey(
                        name: "FK_EmployeePermission_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermission_EmpId",
                table: "EmployeePermission",
                column: "EmpId");
        }
    }
}
