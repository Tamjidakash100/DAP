using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class emppermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Advice",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "BP",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "Patient",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "Pulse",
                table: "IssueMain");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "IssueMain");

            migrationBuilder.CreateTable(
                name: "EmployeePermission",
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
                    table.PrimaryKey("PK_EmployeePermission", x => x.EmpPermissionId);
                    table.ForeignKey(
                        name: "FK_EmployeePermission_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_comid_ProductId_WareHouseId",
                table: "Inventory",
                columns: new[] { "comid", "ProductId", "WareHouseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePermission_EmpId",
                table: "EmployeePermission",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePermission");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_comid_ProductId_WareHouseId",
                table: "Inventory");

            migrationBuilder.AddColumn<string>(
                name: "Advice",
                table: "IssueMain",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BP",
                table: "IssueMain",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patient",
                table: "IssueMain",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Pulse",
                table: "IssueMain",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "IssueMain",
                type: "real",
                nullable: true);
        }
    }
}
