using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class addEmpInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HrEmpInfo",
                columns: table => new
                {
                    EmpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(nullable: true),
                    EmpCode = table.Column<string>(nullable: true),
                    EmpName = table.Column<string>(nullable: false),
                    EmpFather = table.Column<string>(nullable: true),
                    EmpMother = table.Column<string>(nullable: true),
                    EmpSpouse = table.Column<string>(nullable: true),
                    EmpCurrAdd = table.Column<string>(nullable: true),
                    EmpCurrVill = table.Column<string>(nullable: true),
                    EmpCurrPo = table.Column<string>(nullable: true),
                    EmpCurrPs = table.Column<string>(nullable: true),
                    EmpCurrDistId = table.Column<int>(nullable: false),
                    EmpPerAdd = table.Column<string>(nullable: true),
                    EmpPerVill = table.Column<string>(nullable: true),
                    EmpPerPo = table.Column<string>(nullable: true),
                    EmpPerPs = table.Column<string>(nullable: true),
                    EmpPerCity = table.Column<string>(nullable: true),
                    EmpPerDistId = table.Column<int>(nullable: false),
                    EmpPerZip = table.Column<string>(nullable: true),
                    EmpPhone = table.Column<string>(nullable: true),
                    EmpMobile = table.Column<string>(nullable: true),
                    EmpEmail = table.Column<string>(nullable: true),
                    EmpPicLocation = table.Column<string>(nullable: true),
                    EmpRemarks = table.Column<string>(maxLength: 120, nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    RelgionId = table.Column<int>(nullable: false),
                    Caste = table.Column<string>(nullable: true),
                    BloodId = table.Column<int>(nullable: false),
                    MaritalSts = table.Column<string>(nullable: true),
                    DtBirth = table.Column<DateTime>(nullable: true),
                    DtJoin = table.Column<DateTime>(nullable: true),
                    DtReleased = table.Column<DateTime>(nullable: true),
                    DtIncrement = table.Column<DateTime>(nullable: true),
                    IsConfirm = table.Column<bool>(nullable: false),
                    DtConfirm = table.Column<DateTime>(nullable: true),
                    ConfDay = table.Column<int>(nullable: false),
                    DeptId = table.Column<int>(nullable: false),
                    SectId = table.Column<int>(nullable: false),
                    SubSectId = table.Column<int>(nullable: false),
                    DesigId = table.Column<int>(nullable: false),
                    GradeId = table.Column<int>(nullable: false),
                    FloorId = table.Column<int>(nullable: false),
                    LineId = table.Column<int>(nullable: false),
                    EmpCategory = table.Column<string>(nullable: true),
                    WorkPlace = table.Column<string>(nullable: true),
                    ShiftId = table.Column<int>(nullable: false),
                    Nationality = table.Column<string>(nullable: true),
                    PassportNo = table.Column<string>(nullable: true),
                    VoterNo = table.Column<string>(nullable: true),
                    BirthCertNo = table.Column<string>(nullable: true),
                    IsAllowPf = table.Column<bool>(nullable: false),
                    DtPf = table.Column<DateTime>(nullable: true),
                    IsAllowOt = table.Column<bool>(nullable: false),
                    PaySource = table.Column<string>(nullable: true),
                    PayMode = table.Column<string>(nullable: true),
                    EmpType = table.Column<string>(nullable: true),
                    EmpSts = table.Column<string>(nullable: true),
                    CardNo = table.Column<string>(nullable: true),
                    BankId = table.Column<int>(nullable: false),
                    BankAcNo = table.Column<string>(nullable: true),
                    Fpid = table.Column<string>(nullable: true),
                    WeekDayId = table.Column<byte>(nullable: true),
                    OldEmpId = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    NickName = table.Column<string>(maxLength: 20, nullable: true),
                    DtApprove = table.Column<DateTime>(nullable: true),
                    ChildNo = table.Column<int>(nullable: true),
                    EmpCurrDist = table.Column<string>(nullable: true),
                    EmpPerDist = table.Column<string>(nullable: true),
                    EduLvl = table.Column<string>(maxLength: 20, nullable: true),
                    EmpRef = table.Column<string>(nullable: true),
                    EmpRefMob = table.Column<string>(nullable: true),
                    IsTax = table.Column<bool>(nullable: false),
                    IsAcc = table.Column<bool>(nullable: false),
                    EmpCurrZip = table.Column<string>(nullable: true),
                    EmpCurrCity = table.Column<string>(nullable: true),
                    DtTransport = table.Column<DateTime>(nullable: true),
                    IsDisabled = table.Column<bool>(nullable: false),
                    EmpNomineeName = table.Column<string>(nullable: true),
                    EmpNomineeMob = table.Column<string>(nullable: true),
                    EmergencyName = table.Column<string>(nullable: true),
                    EmergencyMob = table.Column<string>(nullable: true),
                    EmployementType = table.Column<string>(nullable: true),
                    EmpCatagory = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    DtCardAssign = table.Column<DateTime>(nullable: true),
                    IsContract = table.Column<bool>(nullable: false),
                    WorkType = table.Column<string>(nullable: true),
                    DtMarrige = table.Column<DateTime>(nullable: true),
                    CardNoOld = table.Column<string>(nullable: true),
                    IsNid = table.Column<bool>(nullable: false),
                    ChildM = table.Column<byte>(nullable: false),
                    ChildF = table.Column<byte>(nullable: false),
                    EmpPflocation = table.Column<string>(nullable: true),
                    EmpMclocation = table.Column<string>(nullable: true),
                    EmpHblocation = table.Column<string>(nullable: true),
                    EmpWflocation = table.Column<string>(nullable: true),
                    IsInactive = table.Column<bool>(nullable: false),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrEmpInfo", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_HrEmpInfo_Cat_BloodGroup_BloodId",
                        column: x => x.BloodId,
                        principalTable: "Cat_BloodGroup",
                        principalColumn: "BloodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrEmpInfo_Cat_Department_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrEmpInfo_Cat_Designation_DesigId",
                        column: x => x.DesigId,
                        principalTable: "Cat_Designation",
                        principalColumn: "DesigId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrEmpInfo_Cat_District_EmpCurrDistId",
                        column: x => x.EmpCurrDistId,
                        principalTable: "Cat_District",
                        principalColumn: "DistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrEmpInfo_Cat_District_EmpPerDistId",
                        column: x => x.EmpPerDistId,
                        principalTable: "Cat_District",
                        principalColumn: "DistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrEmpInfo_Cat_Floor_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Cat_Floor",
                        principalColumn: "FloorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrEmpInfo_Cat_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Cat_Grade",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrEmpInfo_Cat_Line_LineId",
                        column: x => x.LineId,
                        principalTable: "Cat_Line",
                        principalColumn: "LineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrEmpInfo_Cat_Religion_RelgionId",
                        column: x => x.RelgionId,
                        principalTable: "Cat_Religion",
                        principalColumn: "RelgionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrEmpInfo_Cat_Section_SectId",
                        column: x => x.SectId,
                        principalTable: "Cat_Section",
                        principalColumn: "SectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrEmpInfo_Cat_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Cat_Shift",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HrEmpInfo_Cat_SubSection_SubSectId",
                        column: x => x.SubSectId,
                        principalTable: "Cat_SubSection",
                        principalColumn: "SubSectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_BloodId",
                table: "HrEmpInfo",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_DeptId",
                table: "HrEmpInfo",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_DesigId",
                table: "HrEmpInfo",
                column: "DesigId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_EmpCurrDistId",
                table: "HrEmpInfo",
                column: "EmpCurrDistId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_EmpPerDistId",
                table: "HrEmpInfo",
                column: "EmpPerDistId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_FloorId",
                table: "HrEmpInfo",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_GradeId",
                table: "HrEmpInfo",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_LineId",
                table: "HrEmpInfo",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_RelgionId",
                table: "HrEmpInfo",
                column: "RelgionId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_SectId",
                table: "HrEmpInfo",
                column: "SectId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_ShiftId",
                table: "HrEmpInfo",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_SubSectId",
                table: "HrEmpInfo",
                column: "SubSectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrEmpInfo");
        }
    }
}
