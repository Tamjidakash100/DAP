using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class empaddeduexp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpInfo_Cat_District_EmpCurrDistId",
                table: "HrEmpInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpInfo_Cat_District_EmpPerDistId",
                table: "HrEmpInfo");

            migrationBuilder.DropIndex(
                name: "IX_HrEmpInfo_EmpCurrDistId",
                table: "HrEmpInfo");

            migrationBuilder.DropIndex(
                name: "IX_HrEmpInfo_EmpPerDistId",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpCurrAdd",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpCurrDistId",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpCurrPo",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpCurrPs",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpCurrVill",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpPerAdd",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpPerCity",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpPerDistId",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpPerPo",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpPerPs",
                table: "HrEmpInfo");

            migrationBuilder.DropColumn(
                name: "EmpPerVill",
                table: "HrEmpInfo");

            migrationBuilder.CreateTable(
                name: "Hr_EmpAddress",
                columns: table => new
                {
                    EmpAddId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    EmpCurrCityVill = table.Column<string>(maxLength: 200, nullable: true),
                    EmpRemarksCurr = table.Column<string>(maxLength: 200, nullable: true),
                    EmpRemarksPer = table.Column<string>(maxLength: 200, nullable: true),
                    EmpCurrPOId = table.Column<int>(nullable: true),
                    EmpPerPOId = table.Column<int>(nullable: true),
                    EmpCurrPSId = table.Column<int>(nullable: true),
                    EmpPerPSId = table.Column<int>(nullable: true),
                    EmpCurrDistId = table.Column<int>(nullable: true),
                    EmpPerDistId = table.Column<int>(nullable: true),
                    PcName = table.Column<string>(maxLength: 30, nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_EmpAddress", x => x.EmpAddId);
                    table.ForeignKey(
                        name: "FK_Hr_EmpAddress_Cat_District_EmpCurrDistId",
                        column: x => x.EmpCurrDistId,
                        principalTable: "Cat_District",
                        principalColumn: "DistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hr_EmpAddress_Cat_PostOffice_EmpCurrPOId",
                        column: x => x.EmpCurrPOId,
                        principalTable: "Cat_PostOffice",
                        principalColumn: "POId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hr_EmpAddress_Cat_PoliceStation_EmpCurrPSId",
                        column: x => x.EmpCurrPSId,
                        principalTable: "Cat_PoliceStation",
                        principalColumn: "PStationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hr_EmpAddress_HrEmpInfo_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HrEmpInfo",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hr_EmpAddress_Cat_District_EmpPerDistId",
                        column: x => x.EmpPerDistId,
                        principalTable: "Cat_District",
                        principalColumn: "DistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hr_EmpAddress_Cat_PostOffice_EmpPerPOId",
                        column: x => x.EmpPerPOId,
                        principalTable: "Cat_PostOffice",
                        principalColumn: "POId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hr_EmpAddress_Cat_PoliceStation_EmpPerPSId",
                        column: x => x.EmpPerPSId,
                        principalTable: "Cat_PoliceStation",
                        principalColumn: "PStationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hr_EmpEducation",
                columns: table => new
                {
                    EmpEduId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    ExamName = table.Column<string>(maxLength: 30, nullable: true),
                    ExamResult = table.Column<string>(maxLength: 30, nullable: true),
                    MajorSub = table.Column<string>(maxLength: 30, nullable: true),
                    InstituteName = table.Column<string>(maxLength: 30, nullable: true),
                    BoardName = table.Column<string>(maxLength: 30, nullable: true),
                    PassingYear = table.Column<string>(maxLength: 30, nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(maxLength: 30, nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_EmpEducation", x => x.EmpEduId);
                    table.ForeignKey(
                        name: "FK_Hr_EmpEducation_HrEmpInfo_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HrEmpInfo",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hr_EmpExperience",
                columns: table => new
                {
                    EmpExpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    PrevCompany = table.Column<string>(maxLength: 30, nullable: true),
                    PrevDesignation = table.Column<string>(maxLength: 30, nullable: true),
                    PrevSalary = table.Column<string>(maxLength: 30, nullable: true),
                    DtFromJob = table.Column<DateTime>(maxLength: 30, nullable: true),
                    DtToJob = table.Column<DateTime>(maxLength: 30, nullable: true),
                    ExpYear = table.Column<string>(maxLength: 10, nullable: true),
                    Remarks = table.Column<string>(maxLength: 200, nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(maxLength: 30, nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_EmpExperience", x => x.EmpExpId);
                    table.ForeignKey(
                        name: "FK_Hr_EmpExperience_HrEmpInfo_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HrEmpInfo",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hr_EmpAddress_EmpCurrDistId",
                table: "Hr_EmpAddress",
                column: "EmpCurrDistId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_EmpAddress_EmpCurrPOId",
                table: "Hr_EmpAddress",
                column: "EmpCurrPOId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_EmpAddress_EmpCurrPSId",
                table: "Hr_EmpAddress",
                column: "EmpCurrPSId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_EmpAddress_EmpId",
                table: "Hr_EmpAddress",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hr_EmpAddress_EmpPerDistId",
                table: "Hr_EmpAddress",
                column: "EmpPerDistId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_EmpAddress_EmpPerPOId",
                table: "Hr_EmpAddress",
                column: "EmpPerPOId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_EmpAddress_EmpPerPSId",
                table: "Hr_EmpAddress",
                column: "EmpPerPSId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_EmpEducation_EmpId",
                table: "Hr_EmpEducation",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_EmpExperience_EmpId",
                table: "Hr_EmpExperience",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hr_EmpAddress");

            migrationBuilder.DropTable(
                name: "Hr_EmpEducation");

            migrationBuilder.DropTable(
                name: "Hr_EmpExperience");

            migrationBuilder.AddColumn<string>(
                name: "EmpCurrAdd",
                table: "HrEmpInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpCurrDistId",
                table: "HrEmpInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpCurrPo",
                table: "HrEmpInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpCurrPs",
                table: "HrEmpInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpCurrVill",
                table: "HrEmpInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpPerAdd",
                table: "HrEmpInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpPerCity",
                table: "HrEmpInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpPerDistId",
                table: "HrEmpInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpPerPo",
                table: "HrEmpInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpPerPs",
                table: "HrEmpInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpPerVill",
                table: "HrEmpInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_EmpCurrDistId",
                table: "HrEmpInfo",
                column: "EmpCurrDistId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_EmpPerDistId",
                table: "HrEmpInfo",
                column: "EmpPerDistId");

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpInfo_Cat_District_EmpCurrDistId",
                table: "HrEmpInfo",
                column: "EmpCurrDistId",
                principalTable: "Cat_District",
                principalColumn: "DistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpInfo_Cat_District_EmpPerDistId",
                table: "HrEmpInfo",
                column: "EmpPerDistId",
                principalTable: "Cat_District",
                principalColumn: "DistId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
