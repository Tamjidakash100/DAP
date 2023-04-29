using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class sohel3raihan1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_Catagory",
                columns: table => new
                {
                    CatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatName = table.Column<string>(maxLength: 25, nullable: false),
                    Remarks = table.Column<string>(maxLength: 25, nullable: true),
                    SlNo = table.Column<int>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(maxLength: 25, nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Catagory", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_IncenBand",
                columns: table => new
                {
                    InBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncenBandName = table.Column<string>(maxLength: 25, nullable: false),
                    Remarks = table.Column<string>(maxLength: 25, nullable: true),
                    SlNo = table.Column<int>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(maxLength: 25, nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_IncenBand", x => x.InBId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_InsurGrade",
                columns: table => new
                {
                    InGId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InSurGrade = table.Column<string>(maxLength: 25, nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 25, nullable: true),
                    SlNo = table.Column<int>(nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(maxLength: 25, nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_InsurGrade", x => x.InGId);
                });

            migrationBuilder.CreateTable(
                name: "HrEmpReleased",
                columns: table => new
                {
                    RelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(nullable: true),
                    EmpId = table.Column<int>(nullable: false),
                    DtReleased = table.Column<DateTime>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 120, nullable: true),
                    RelType = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    DtPresentLast = table.Column<DateTime>(nullable: true),
                    DtSubmit = table.Column<DateTime>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmpReleased", x => x.RelId);
                    table.ForeignKey(
                        name: "FK_HrEmpReleased_HrEmpInfo_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HrEmpInfo",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpReleased_EmpId",
                table: "HrEmpReleased",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_Catagory");

            migrationBuilder.DropTable(
                name: "Cat_IncenBand");

            migrationBuilder.DropTable(
                name: "Cat_InsurGrade");

            migrationBuilder.DropTable(
                name: "HrEmpReleased");
        }
    }
}
