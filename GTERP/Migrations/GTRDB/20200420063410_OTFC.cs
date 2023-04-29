using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class OTFC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_OT_FC",
                columns: table => new
                {
                    OtFcId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    ttlOT = table.Column<float>(nullable: true),
                    ttlFC = table.Column<float>(nullable: true),
                    ttlNight = table.Column<float>(nullable: true),
                    ttlShiftNight = table.Column<float>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_OT_FC", x => x.OtFcId);
                    table.ForeignKey(
                        name: "FK_HR_OT_FC_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_OT_FC_EmpId",
                table: "HR_OT_FC",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_OT_FC");
        }
    }
}
