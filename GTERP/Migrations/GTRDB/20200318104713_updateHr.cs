using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class updateHr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpReleased_HrEmpInfo_EmpId",
                table: "HrEmpReleased");

            migrationBuilder.DropTable(
                name: "Hr_EmpAddress");

            migrationBuilder.DropTable(
                name: "Hr_EmpEducation");

            migrationBuilder.DropTable(
                name: "Hr_EmpExperience");

            migrationBuilder.DropTable(
                name: "HrEmpInfo");

            migrationBuilder.CreateTable(
                name: "HR_Emp_Info",
                columns: table => new
                {
                    EmpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(nullable: true),
                    EmpImage = table.Column<byte[]>(nullable: true),
                    EmpImagePath = table.Column<string>(nullable: true),
                    EmpImageExtension = table.Column<string>(nullable: true),
                    EmpCode = table.Column<string>(nullable: true),
                    EmpName = table.Column<string>(nullable: false),
                    RelgionId = table.Column<int>(nullable: false),
                    BloodId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    DeptId = table.Column<int>(nullable: false),
                    ShiftId = table.Column<int>(nullable: false),
                    DesigId = table.Column<int>(nullable: false),
                    SectId = table.Column<int>(nullable: false),
                    SubSectId = table.Column<int>(nullable: true),
                    DtBirth = table.Column<DateTime>(nullable: true),
                    DtJoin = table.Column<DateTime>(nullable: true),
                    DtIncrement = table.Column<DateTime>(nullable: true),
                    DtConfirm = table.Column<DateTime>(nullable: true),
                    DtPf = table.Column<DateTime>(nullable: true),
                    EmpType = table.Column<string>(maxLength: 20, nullable: true),
                    Sex = table.Column<string>(maxLength: 10, nullable: true),
                    NID = table.Column<string>(maxLength: 40, nullable: true),
                    FingerId = table.Column<string>(maxLength: 40, nullable: true),
                    EmpPhone1 = table.Column<string>(maxLength: 20, nullable: true),
                    EmpPhone2 = table.Column<string>(maxLength: 20, nullable: true),
                    IsInactive = table.Column<bool>(nullable: false),
                    EmpFather = table.Column<string>(nullable: true),
                    EmpMother = table.Column<string>(nullable: true),
                    EmpSpouse = table.Column<string>(nullable: true),
                    EmpPerZip = table.Column<string>(nullable: true),
                    EmpMobile = table.Column<string>(nullable: true),
                    EmpEmail = table.Column<string>(nullable: true),
                    EmpPicLocation = table.Column<string>(nullable: true),
                    EmpRemarks = table.Column<string>(maxLength: 120, nullable: true),
                    Caste = table.Column<string>(nullable: true),
                    MaritalSts = table.Column<string>(nullable: true),
                    DtReleased = table.Column<DateTime>(nullable: true),
                    IsConfirm = table.Column<bool>(nullable: false),
                    ConfDay = table.Column<int>(nullable: false),
                    GradeId = table.Column<int>(nullable: true),
                    FloorId = table.Column<int>(nullable: true),
                    LineId = table.Column<int>(nullable: true),
                    EmpCategory = table.Column<string>(nullable: true),
                    WorkPlace = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    PassportNo = table.Column<string>(nullable: true),
                    VoterNo = table.Column<string>(nullable: true),
                    BirthCertNo = table.Column<string>(nullable: true),
                    IsAllowPf = table.Column<bool>(nullable: false),
                    IsAllowOt = table.Column<bool>(nullable: false),
                    PaySource = table.Column<string>(nullable: true),
                    PayMode = table.Column<string>(nullable: true),
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
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Info", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Info_Cat_BloodGroup_BloodId",
                        column: x => x.BloodId,
                        principalTable: "Cat_BloodGroup",
                        principalColumn: "BloodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Info_Cat_Department_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Info_Cat_Designation_DesigId",
                        column: x => x.DesigId,
                        principalTable: "Cat_Designation",
                        principalColumn: "DesigId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Info_Cat_Floor_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Cat_Floor",
                        principalColumn: "FloorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Info_Cat_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Cat_Grade",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Info_Cat_Line_LineId",
                        column: x => x.LineId,
                        principalTable: "Cat_Line",
                        principalColumn: "LineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Info_Cat_Religion_RelgionId",
                        column: x => x.RelgionId,
                        principalTable: "Cat_Religion",
                        principalColumn: "RelgionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Info_Cat_Section_SectId",
                        column: x => x.SectId,
                        principalTable: "Cat_Section",
                        principalColumn: "SectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Info_Cat_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Cat_Shift",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Info_Cat_SubSection_SubSectId",
                        column: x => x.SubSectId,
                        principalTable: "Cat_SubSection",
                        principalColumn: "SubSectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Info_Cat_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Cat_Unit",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Address",
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
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    MyProperty = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(maxLength: 30, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Address", x => x.EmpAddId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Address_Cat_District_EmpCurrDistId",
                        column: x => x.EmpCurrDistId,
                        principalTable: "Cat_District",
                        principalColumn: "DistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Address_Cat_PostOffice_EmpCurrPOId",
                        column: x => x.EmpCurrPOId,
                        principalTable: "Cat_PostOffice",
                        principalColumn: "POId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Address_Cat_PoliceStation_EmpCurrPSId",
                        column: x => x.EmpCurrPSId,
                        principalTable: "Cat_PoliceStation",
                        principalColumn: "PStationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Address_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Address_Cat_District_EmpPerDistId",
                        column: x => x.EmpPerDistId,
                        principalTable: "Cat_District",
                        principalColumn: "DistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Address_Cat_PostOffice_EmpPerPOId",
                        column: x => x.EmpPerPOId,
                        principalTable: "Cat_PostOffice",
                        principalColumn: "POId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Address_Cat_PoliceStation_EmpPerPSId",
                        column: x => x.EmpPerPSId,
                        principalTable: "Cat_PoliceStation",
                        principalColumn: "PStationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Education",
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
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    PcName = table.Column<string>(maxLength: 30, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Education", x => x.EmpEduId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Education_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Experience",
                columns: table => new
                {
                    EmpExpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    PrevCompany = table.Column<string>(maxLength: 30, nullable: true),
                    PrevDesignation = table.Column<string>(maxLength: 30, nullable: true),
                    PrevSalary = table.Column<string>(maxLength: 30, nullable: true),
                    DtFromJob = table.Column<DateTime>(nullable: true),
                    DtToJob = table.Column<DateTime>(nullable: true),
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
                    table.PrimaryKey("PK_HR_Emp_Experience", x => x.EmpExpId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Experience_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Family",
                columns: table => new
                {
                    EmpFamilyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    EmpFather = table.Column<string>(maxLength: 60, nullable: true),
                    EmpFatherNID = table.Column<string>(maxLength: 25, nullable: true),
                    EmpFatherMobile = table.Column<string>(maxLength: 20, nullable: true),
                    EmpMother = table.Column<string>(maxLength: 60, nullable: true),
                    EmpMotherNID = table.Column<string>(maxLength: 25, nullable: true),
                    EmpMotherMobile = table.Column<string>(maxLength: 20, nullable: true),
                    EmpSpouse = table.Column<string>(maxLength: 60, nullable: true),
                    EmpSpouseNID = table.Column<string>(maxLength: 25, nullable: true),
                    EmpSpouseMobile = table.Column<string>(maxLength: 20, nullable: true),
                    EmpChildName1 = table.Column<string>(maxLength: 60, nullable: true),
                    EmpChildDOB1 = table.Column<DateTime>(nullable: true),
                    EmpChildEdu1 = table.Column<string>(maxLength: 20, nullable: true),
                    EmpChildBirthCer1 = table.Column<string>(maxLength: 25, nullable: true),
                    EmpChildName2 = table.Column<string>(maxLength: 60, nullable: true),
                    EmpChildDOB2 = table.Column<DateTime>(nullable: true),
                    EmpChildEdu2 = table.Column<string>(maxLength: 20, nullable: true),
                    EmpChildBirthCer2 = table.Column<string>(maxLength: 25, nullable: true),
                    EmpChildName3 = table.Column<string>(maxLength: 60, nullable: true),
                    EmpChildDOB3 = table.Column<DateTime>(nullable: true),
                    EmpChildEdu3 = table.Column<string>(maxLength: 20, nullable: true),
                    EmpChildBirthCer3 = table.Column<string>(maxLength: 25, nullable: true),
                    EmpChildName4 = table.Column<string>(maxLength: 60, nullable: true),
                    EmpChildDOB4 = table.Column<DateTime>(nullable: true),
                    EmpChildEdu4 = table.Column<string>(maxLength: 20, nullable: true),
                    EmpChildBirthCer4 = table.Column<string>(maxLength: 25, nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 30, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Family", x => x.EmpFamilyId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Family_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Increment",
                columns: table => new
                {
                    IncId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    EmpId = table.Column<int>(nullable: false),
                    IncType = table.Column<string>(maxLength: 50, nullable: true),
                    DtIncrement = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Percentage = table.Column<float>(nullable: false),
                    OldSalary = table.Column<double>(nullable: false),
                    NewSalary = table.Column<double>(nullable: false),
                    BS = table.Column<double>(nullable: false),
                    HR = table.Column<double>(nullable: false),
                    MA = table.Column<double>(nullable: false),
                    TA = table.Column<double>(nullable: false),
                    FA = table.Column<double>(nullable: false),
                    PA = table.Column<double>(nullable: false),
                    DA = table.Column<double>(nullable: false),
                    OldUnitId = table.Column<int>(nullable: false),
                    NewUnitId = table.Column<int>(nullable: false),
                    OldDeptId = table.Column<int>(nullable: false),
                    NewDeptId = table.Column<int>(nullable: false),
                    OldSectId = table.Column<int>(nullable: false),
                    NewSectId = table.Column<int>(nullable: false),
                    OldDesigId = table.Column<int>(nullable: false),
                    NewDesigId = table.Column<int>(nullable: false),
                    OldEmpType = table.Column<string>(maxLength: 30, nullable: true),
                    NewEmpType = table.Column<string>(maxLength: 30, nullable: true),
                    OldGrade = table.Column<string>(maxLength: 30, nullable: true),
                    NewGrade = table.Column<string>(maxLength: 30, nullable: true),
                    PcName = table.Column<string>(maxLength: 60, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Increment", x => x.IncId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Department_NewDeptId",
                        column: x => x.NewDeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Designation_NewDesigId",
                        column: x => x.NewDesigId,
                        principalTable: "Cat_Designation",
                        principalColumn: "DesigId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Section_NewSectId",
                        column: x => x.NewSectId,
                        principalTable: "Cat_Section",
                        principalColumn: "SectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Unit_NewUnitId",
                        column: x => x.NewUnitId,
                        principalTable: "Cat_Unit",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Department_OldDeptId",
                        column: x => x.OldDeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Designation_OldDesigId",
                        column: x => x.OldDesigId,
                        principalTable: "Cat_Designation",
                        principalColumn: "DesigId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Section_OldSectId",
                        column: x => x.OldSectId,
                        principalTable: "Cat_Section",
                        principalColumn: "SectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Increment_Cat_Unit_OldUnitId",
                        column: x => x.OldUnitId,
                        principalTable: "Cat_Unit",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Nominee",
                columns: table => new
                {
                    EmpNomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    EmpNomineeName1 = table.Column<string>(maxLength: 60, nullable: true),
                    EmpNomineeDOB1 = table.Column<DateTime>(nullable: true),
                    EmpNomineeJobType1 = table.Column<string>(maxLength: 50, nullable: true),
                    EmpNomineeMobile1 = table.Column<string>(maxLength: 20, nullable: true),
                    EmpNomineeNID1 = table.Column<string>(maxLength: 25, nullable: true),
                    EmpNomineeRelation1 = table.Column<string>(maxLength: 30, nullable: true),
                    EmpNomineePercentage1 = table.Column<string>(maxLength: 30, nullable: true),
                    EmpNomineeAddress1 = table.Column<string>(maxLength: 30, nullable: true),
                    EmpNomineeName2 = table.Column<string>(maxLength: 60, nullable: true),
                    EmpNomineeDOB2 = table.Column<DateTime>(nullable: true),
                    EmpNomineeJobType2 = table.Column<string>(maxLength: 50, nullable: true),
                    EmpNomineeMobile2 = table.Column<string>(maxLength: 20, nullable: true),
                    EmpNomineeNID2 = table.Column<string>(maxLength: 25, nullable: true),
                    EmpNomineeRelation2 = table.Column<string>(maxLength: 30, nullable: true),
                    EmpNomineePercentage2 = table.Column<string>(maxLength: 30, nullable: true),
                    EmpNomineeAddress2 = table.Column<string>(maxLength: 30, nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(maxLength: 30, nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Nominee", x => x.EmpNomId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Nominee_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_PersonalInfo",
                columns: table => new
                {
                    EmpPersInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    NickName = table.Column<string>(maxLength: 60, nullable: true),
                    PassportNo = table.Column<string>(maxLength: 60, nullable: true),
                    BirthCertificate = table.Column<string>(maxLength: 60, nullable: true),
                    TINNo = table.Column<string>(maxLength: 60, nullable: true),
                    MaritalStatus = table.Column<bool>(nullable: false),
                    ChildNo = table.Column<string>(maxLength: 10, nullable: true),
                    Nationality = table.Column<string>(maxLength: 30, nullable: true),
                    Caste = table.Column<string>(maxLength: 30, nullable: true),
                    IdentificationSign = table.Column<string>(maxLength: 60, nullable: true),
                    Height = table.Column<float>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    IsUsingHouse = table.Column<bool>(nullable: false),
                    BuildingNo = table.Column<string>(maxLength: 20, nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(maxLength: 30, nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_PersonalInfo", x => x.EmpPersInfoId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_PersonalInfo_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Leave_Avail",
                columns: table => new
                {
                    LvId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    DtLvInput = table.Column<DateTime>(nullable: true),
                    DtFrom = table.Column<DateTime>(nullable: false),
                    DtTo = table.Column<DateTime>(nullable: true),
                    InputType = table.Column<string>(nullable: true),
                    TotalDay = table.Column<double>(nullable: true),
                    LvType = table.Column<string>(maxLength: 25, nullable: false),
                    LvApp = table.Column<double>(nullable: false),
                    Remark = table.Column<string>(maxLength: 80, nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Leave_Avail", x => x.LvId);
                    table.ForeignKey(
                        name: "FK_HR_Leave_Avail_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Leave_Balance",
                columns: table => new
                {
                    LvBalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    DtOpBal = table.Column<DateTime>(nullable: false),
                    CL = table.Column<float>(nullable: false),
                    ACL = table.Column<float>(nullable: false),
                    SL = table.Column<float>(nullable: false),
                    ASL = table.Column<float>(nullable: false),
                    EL = table.Column<float>(nullable: false),
                    AEL = table.Column<float>(nullable: false),
                    ML = table.Column<float>(nullable: false),
                    AML = table.Column<float>(nullable: false),
                    LWP = table.Column<float>(nullable: false),
                    ALWP = table.Column<float>(nullable: false),
                    ACCL = table.Column<float>(nullable: false),
                    AACCL = table.Column<float>(nullable: false),
                    SPL = table.Column<float>(nullable: false),
                    ASPL = table.Column<float>(nullable: false),
                    TL = table.Column<float>(nullable: false),
                    ATL = table.Column<float>(nullable: false),
                    BL = table.Column<float>(nullable: false),
                    ABL = table.Column<float>(nullable: false),
                    PcName = table.Column<string>(maxLength: 60, nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Leave_Balance", x => x.LvBalId);
                    table.ForeignKey(
                        name: "FK_HR_Leave_Balance_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Address_EmpCurrDistId",
                table: "HR_Emp_Address",
                column: "EmpCurrDistId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Address_EmpCurrPOId",
                table: "HR_Emp_Address",
                column: "EmpCurrPOId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Address_EmpCurrPSId",
                table: "HR_Emp_Address",
                column: "EmpCurrPSId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Address_EmpId",
                table: "HR_Emp_Address",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Address_EmpPerDistId",
                table: "HR_Emp_Address",
                column: "EmpPerDistId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Address_EmpPerPOId",
                table: "HR_Emp_Address",
                column: "EmpPerPOId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Address_EmpPerPSId",
                table: "HR_Emp_Address",
                column: "EmpPerPSId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Education_EmpId",
                table: "HR_Emp_Education",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Experience_EmpId",
                table: "HR_Emp_Experience",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Family_EmpId",
                table: "HR_Emp_Family",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_EmpId",
                table: "HR_Emp_Increment",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_NewDeptId",
                table: "HR_Emp_Increment",
                column: "NewDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_NewDesigId",
                table: "HR_Emp_Increment",
                column: "NewDesigId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_NewSectId",
                table: "HR_Emp_Increment",
                column: "NewSectId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_NewUnitId",
                table: "HR_Emp_Increment",
                column: "NewUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_OldDeptId",
                table: "HR_Emp_Increment",
                column: "OldDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_OldDesigId",
                table: "HR_Emp_Increment",
                column: "OldDesigId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_OldSectId",
                table: "HR_Emp_Increment",
                column: "OldSectId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_OldUnitId",
                table: "HR_Emp_Increment",
                column: "OldUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Info_BloodId",
                table: "HR_Emp_Info",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Info_DeptId",
                table: "HR_Emp_Info",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Info_DesigId",
                table: "HR_Emp_Info",
                column: "DesigId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Info_FloorId",
                table: "HR_Emp_Info",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Info_GradeId",
                table: "HR_Emp_Info",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Info_LineId",
                table: "HR_Emp_Info",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Info_RelgionId",
                table: "HR_Emp_Info",
                column: "RelgionId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Info_SectId",
                table: "HR_Emp_Info",
                column: "SectId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Info_ShiftId",
                table: "HR_Emp_Info",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Info_SubSectId",
                table: "HR_Emp_Info",
                column: "SubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Info_UnitId",
                table: "HR_Emp_Info",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Nominee_EmpId",
                table: "HR_Emp_Nominee",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_PersonalInfo_EmpId",
                table: "HR_Emp_PersonalInfo",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leave_Avail_EmpId",
                table: "HR_Leave_Avail",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leave_Balance_EmpId",
                table: "HR_Leave_Balance",
                column: "EmpId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpReleased_HR_Emp_Info_EmpId",
                table: "HrEmpReleased",
                column: "EmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrEmpReleased_HR_Emp_Info_EmpId",
                table: "HrEmpReleased");

            migrationBuilder.DropTable(
                name: "HR_Emp_Address");

            migrationBuilder.DropTable(
                name: "HR_Emp_Education");

            migrationBuilder.DropTable(
                name: "HR_Emp_Experience");

            migrationBuilder.DropTable(
                name: "HR_Emp_Family");

            migrationBuilder.DropTable(
                name: "HR_Emp_Increment");

            migrationBuilder.DropTable(
                name: "HR_Emp_Nominee");

            migrationBuilder.DropTable(
                name: "HR_Emp_PersonalInfo");

            migrationBuilder.DropTable(
                name: "HR_Leave_Avail");

            migrationBuilder.DropTable(
                name: "HR_Leave_Balance");

            migrationBuilder.DropTable(
                name: "HR_Emp_Info");

            migrationBuilder.CreateTable(
                name: "HrEmpInfo",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    BankAcNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    BirthCertNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodId = table.Column<int>(type: "int", nullable: false),
                    CardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNoOld = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildF = table.Column<byte>(type: "tinyint", nullable: false),
                    ChildM = table.Column<byte>(type: "tinyint", nullable: false),
                    ChildNo = table.Column<int>(type: "int", nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfDay = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    DesigId = table.Column<int>(type: "int", nullable: false),
                    DtApprove = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtCardAssign = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtConfirm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtIncrement = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtJoin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtMarrige = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtPf = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtReleased = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtTransport = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EduLvl = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmergencyMob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpCatagory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpCurrCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpCurrDist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpCurrZip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpFather = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpHblocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EmpImageExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpMclocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpMother = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpNomineeMob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpNomineeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpPerDist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpPerZip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpPflocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpPhone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmpPhone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmpPicLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpRefMob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpRemarks = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    EmpSpouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpSts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmpWflocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployementType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FingerId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    FloorId = table.Column<int>(type: "int", nullable: true),
                    Fpid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeId = table.Column<int>(type: "int", nullable: true),
                    IsAcc = table.Column<bool>(type: "bit", nullable: false),
                    IsAllowOt = table.Column<bool>(type: "bit", nullable: false),
                    IsAllowPf = table.Column<bool>(type: "bit", nullable: false),
                    IsConfirm = table.Column<bool>(type: "bit", nullable: false),
                    IsContract = table.Column<bool>(type: "bit", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false),
                    IsNid = table.Column<bool>(type: "bit", nullable: false),
                    IsTax = table.Column<bool>(type: "bit", nullable: false),
                    LineId = table.Column<int>(type: "int", nullable: true),
                    MaritalSts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NID = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OldEmpId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaySource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelgionId = table.Column<int>(type: "int", nullable: false),
                    SectId = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    SubSectId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoterNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekDayId = table.Column<byte>(type: "tinyint", nullable: true),
                    WorkPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkType = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                        name: "FK_HrEmpInfo_Cat_Floor_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Cat_Floor",
                        principalColumn: "FloorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrEmpInfo_Cat_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Cat_Grade",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HrEmpInfo_Cat_Line_LineId",
                        column: x => x.LineId,
                        principalTable: "Cat_Line",
                        principalColumn: "LineId",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_HrEmpInfo_Cat_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Cat_Unit",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hr_EmpAddress",
                columns: table => new
                {
                    EmpAddId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpCurrCityVill = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmpCurrDistId = table.Column<int>(type: "int", nullable: true),
                    EmpCurrPOId = table.Column<int>(type: "int", nullable: true),
                    EmpCurrPSId = table.Column<int>(type: "int", nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    EmpPerDistId = table.Column<int>(type: "int", nullable: true),
                    EmpPerPOId = table.Column<int>(type: "int", nullable: true),
                    EmpPerPSId = table.Column<int>(type: "int", nullable: true),
                    EmpRemarksCurr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmpRemarksPer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    EmpEduId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    ExamName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ExamResult = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    InstituteName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MajorSub = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PassingYear = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    EmpExpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtFromJob = table.Column<DateTime>(type: "datetime2", maxLength: 30, nullable: true),
                    DtToJob = table.Column<DateTime>(type: "datetime2", maxLength: 30, nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    ExpYear = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PrevCompany = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PrevDesignation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PrevSalary = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_HrEmpInfo_UnitId",
                table: "HrEmpInfo",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_HrEmpReleased_HrEmpInfo_EmpId",
                table: "HrEmpReleased",
                column: "EmpId",
                principalTable: "HrEmpInfo",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
