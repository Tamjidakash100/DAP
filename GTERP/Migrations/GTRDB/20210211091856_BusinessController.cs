using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class BusinessController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_Emp_BusinessAllow",
                columns: table => new
                {
                    BAId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    ttlBusinessDuty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DtFrom = table.Column<DateTime>(nullable: true),
                    DtTo = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 40, nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_BusinessAllow", x => x.BAId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_BusinessAllow_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_BusinessAllow_EmpId",
                table: "HR_Emp_BusinessAllow",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Emp_BusinessAllow");
        }
    }
}
