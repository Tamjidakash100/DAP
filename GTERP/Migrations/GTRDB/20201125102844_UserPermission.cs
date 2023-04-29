using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class UserPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPermission",
                columns: table => new
                {
                    PermissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(maxLength: 128, nullable: true),
                    EmpId = table.Column<int>(nullable: false),
                    IsHRAndPayroll = table.Column<bool>(nullable: false),
                    IsAll = table.Column<bool>(nullable: false),
                    IsStoreAndAccounts = table.Column<bool>(nullable: false),
                    IsStore = table.Column<bool>(nullable: false),
                    IsAccouonts = table.Column<bool>(nullable: false),
                    IsMedical = table.Column<bool>(nullable: false),
                    IsProduction = table.Column<bool>(nullable: false),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => x.PermissionId);
                    table.ForeignKey(
                        name: "FK_UserPermission_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_EmpId",
                table: "UserPermission",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_ComId_EmpId_AppUserId",
                table: "UserPermission",
                columns: new[] { "ComId", "EmpId", "AppUserId" },
                unique: true,
                filter: "[ComId] IS NOT NULL AND [AppUserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPermission");
        }
    }
}
