using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class reportPermissiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportPermissions",
                columns: table => new
                {
                    ReportPermissionsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<Guid>(maxLength: 128, nullable: false),
                    ReportId = table.Column<int>(nullable: false),
                    isChecked = table.Column<int>(nullable: false),
                    UserIdPermission = table.Column<string>(maxLength: 128, nullable: false),
                    UserId = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportPermissions", x => x.ReportPermissionsId);
                    table.ForeignKey(
                        name: "FK_ReportPermissions_HR_ReportType_ReportId",
                        column: x => x.ReportId,
                        principalTable: "HR_ReportType",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportPermissions_ReportId",
                table: "ReportPermissions",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportPermissions");
        }
    }
}
