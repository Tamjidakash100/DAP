using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class elencasement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_LvEncashment",
                columns: table => new
                {
                    LvEncashmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    DtFrom = table.Column<DateTime>(nullable: false),
                    DtTo = table.Column<DateTime>(nullable: false),
                    DtFromNext = table.Column<DateTime>(nullable: false),
                    DtToNext = table.Column<DateTime>(nullable: false),
                    TotalDays = table.Column<int>(nullable: false),
                    ELBalance = table.Column<int>(nullable: false),
                    IsELEnjoy = table.Column<bool>(nullable: false),
                    LvEncashmentIYear = table.Column<string>(nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_LvEncashment", x => x.LvEncashmentId);
                    table.ForeignKey(
                        name: "FK_HR_LvEncashment_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_LvEncashment_EmpId",
                table: "HR_LvEncashment",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_LvEncashment");
        }
    }
}
