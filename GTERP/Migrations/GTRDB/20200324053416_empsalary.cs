using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class empsalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "HR_Emp_Address");

            migrationBuilder.CreateTable(
                name: "Cat_Location",
                columns: table => new
                {
                    LId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(maxLength: 30, nullable: false),
                    LocationNameB = table.Column<string>(maxLength: 30, nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 60, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Location", x => x.LId);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_Salary",
                columns: table => new
                {
                    SalaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    EmpId = table.Column<int>(nullable: false),
                    LId1 = table.Column<int>(nullable: false),
                    LId2 = table.Column<int>(nullable: true),
                    LId3 = table.Column<int>(nullable: true),
                    BId = table.Column<int>(nullable: true),
                    PFLId = table.Column<int>(nullable: true),
                    WelfareLId = table.Column<int>(nullable: true),
                    MCLId = table.Column<int>(nullable: true),
                    HBLId = table.Column<int>(nullable: true),
                    BasicSalary = table.Column<float>(nullable: false),
                    IsBS = table.Column<bool>(nullable: false),
                    HouseRent = table.Column<float>(nullable: true),
                    IsHr = table.Column<bool>(nullable: false),
                    MadicalAllow = table.Column<float>(nullable: true),
                    IsMa = table.Column<bool>(nullable: false),
                    ConveyanceAllow = table.Column<float>(nullable: true),
                    IsConvAllow = table.Column<bool>(nullable: false),
                    DearnessAllow = table.Column<float>(nullable: true),
                    IsDearAllow = table.Column<bool>(nullable: false),
                    GasAllow = table.Column<float>(nullable: true),
                    IsGasAllow = table.Column<bool>(nullable: false),
                    PersonalPay = table.Column<float>(nullable: true),
                    IsPersonalPay = table.Column<bool>(nullable: false),
                    ArrearBasic = table.Column<float>(nullable: true),
                    IsArrearBasic = table.Column<bool>(nullable: false),
                    ArrearBonus = table.Column<float>(nullable: true),
                    IsArrearBonus = table.Column<bool>(nullable: false),
                    WashingAllow = table.Column<float>(nullable: true),
                    IsWashingAllow = table.Column<bool>(nullable: false),
                    SiftAllow = table.Column<float>(nullable: true),
                    ChargeAllow = table.Column<float>(nullable: true),
                    IsChargAllow = table.Column<bool>(nullable: false),
                    MiscAdd = table.Column<float>(nullable: true),
                    IsMiscAdd = table.Column<bool>(nullable: false),
                    ContainSub = table.Column<float>(nullable: true),
                    IsContainSub = table.Column<bool>(nullable: false),
                    ComPfCount = table.Column<float>(nullable: true),
                    IsComPfcount = table.Column<bool>(nullable: false),
                    EduAllow = table.Column<float>(nullable: true),
                    IsEduAllow = table.Column<bool>(nullable: false),
                    TiffinAllow = table.Column<float>(nullable: true),
                    IsTiffinAllow = table.Column<bool>(nullable: false),
                    CanteenAllow = table.Column<float>(nullable: true),
                    IsCanteenAllow = table.Column<bool>(nullable: false),
                    AttAllow = table.Column<float>(nullable: true),
                    IsAttAllow = table.Column<bool>(nullable: false),
                    FestivalBonus = table.Column<float>(nullable: true),
                    IsFestivalBonus = table.Column<bool>(nullable: false),
                    RiskAllow = table.Column<float>(nullable: true),
                    IsRiskAllow = table.Column<bool>(nullable: false),
                    NightAllow = table.Column<float>(nullable: true),
                    IsNightAllow = table.Column<bool>(nullable: false),
                    MobileAllow = table.Column<float>(nullable: true),
                    IsMobileAllow = table.Column<bool>(nullable: false),
                    Pf = table.Column<float>(nullable: true),
                    IsPf = table.Column<bool>(nullable: false),
                    PfAdd = table.Column<float>(nullable: true),
                    IsPfAdd = table.Column<bool>(nullable: false),
                    HrExp = table.Column<float>(nullable: true),
                    IsHrexp = table.Column<bool>(nullable: false),
                    FesBonusDed = table.Column<float>(nullable: true),
                    IsFesBonus = table.Column<bool>(nullable: false),
                    Transportcharge = table.Column<float>(nullable: true),
                    IsTrncharge = table.Column<bool>(nullable: false),
                    TeliphoneCharge = table.Column<float>(nullable: true),
                    IsTelcharge = table.Column<bool>(nullable: false),
                    TAExpense = table.Column<float>(nullable: true),
                    IsTAExp = table.Column<bool>(nullable: false),
                    SalaryAdv = table.Column<float>(nullable: true),
                    IsSalaryAdv = table.Column<bool>(nullable: false),
                    PurchaseAdv = table.Column<float>(nullable: true),
                    McloanDed = table.Column<float>(nullable: true),
                    IsMcloan = table.Column<bool>(nullable: false),
                    HbloanDed = table.Column<float>(nullable: true),
                    IsHbloan = table.Column<bool>(nullable: false),
                    PfloannDed = table.Column<float>(nullable: true),
                    IsPfloann = table.Column<bool>(nullable: false),
                    WfloanLocal = table.Column<float>(nullable: true),
                    IsWfloanLocal = table.Column<bool>(nullable: false),
                    WfloanOther = table.Column<float>(nullable: true),
                    IsWfloanOther = table.Column<bool>(nullable: false),
                    WpfloanDed = table.Column<float>(nullable: true),
                    IsWpfloanDed = table.Column<bool>(nullable: false),
                    MaterialLoanDed = table.Column<float>(nullable: true),
                    IsMaterialLoan = table.Column<bool>(nullable: false),
                    MiscDed = table.Column<float>(nullable: true),
                    IsMiscDed = table.Column<bool>(nullable: false),
                    AdvAgainstExp = table.Column<float>(nullable: true),
                    IsAdvAgainstExp = table.Column<bool>(nullable: false),
                    AdvFacility = table.Column<float>(nullable: true),
                    IsAdvFacility = table.Column<bool>(nullable: false),
                    ElectricCharge = table.Column<float>(nullable: true),
                    IsElectricCharge = table.Column<bool>(nullable: false),
                    Gascharge = table.Column<float>(nullable: true),
                    IsGascharge = table.Column<bool>(nullable: false),
                    HazScheme = table.Column<float>(nullable: true),
                    IsHazScheme = table.Column<bool>(nullable: false),
                    Donaton = table.Column<float>(nullable: true),
                    IsDonaton = table.Column<bool>(nullable: false),
                    Dishantenna = table.Column<float>(nullable: true),
                    IsDishantenna = table.Column<bool>(nullable: false),
                    RevenueStamp = table.Column<float>(nullable: true),
                    IsRevenueStamp = table.Column<bool>(nullable: false),
                    OwaSub = table.Column<float>(nullable: true),
                    IsOwaSub = table.Column<bool>(nullable: false),
                    DedIncBns = table.Column<float>(nullable: true),
                    IsDedIncBns = table.Column<bool>(nullable: false),
                    DapEmpClub = table.Column<float>(nullable: true),
                    IsDapEmpClub = table.Column<bool>(nullable: false),
                    Moktab = table.Column<float>(nullable: true),
                    IsMoktab = table.Column<bool>(nullable: false),
                    ChemicalForum = table.Column<float>(nullable: true),
                    IsChemicalForum = table.Column<bool>(nullable: false),
                    DiplomaassoDed = table.Column<float>(nullable: true),
                    IsDiplomaassoDed = table.Column<bool>(nullable: false),
                    EnggassoDed = table.Column<float>(nullable: true),
                    IsEnggassoDed = table.Column<bool>(nullable: false),
                    Wfsub = table.Column<float>(nullable: true),
                    IsWfsub = table.Column<bool>(nullable: false),
                    EduAlloDed = table.Column<float>(nullable: true),
                    IsEduAlloDed = table.Column<bool>(nullable: false),
                    PurChange = table.Column<float>(nullable: true),
                    IsPurChange = table.Column<bool>(nullable: false),
                    IncomeTax = table.Column<float>(nullable: true),
                    IsIncomeTax = table.Column<bool>(nullable: false),
                    ArrearInTaxDed = table.Column<float>(nullable: true),
                    IsArrearInTaxDed = table.Column<bool>(nullable: false),
                    OffWlfareAsso = table.Column<float>(nullable: true),
                    IsOffWlfareAsso = table.Column<bool>(nullable: false),
                    OfficeclubDed = table.Column<float>(nullable: true),
                    IsOfficeclubDed = table.Column<bool>(nullable: false),
                    IncBonusDed = table.Column<float>(nullable: true),
                    IsIncBonusDed = table.Column<bool>(nullable: false),
                    Watercharge = table.Column<float>(nullable: true),
                    IsWatercharge = table.Column<bool>(nullable: false),
                    ChemicalAsso = table.Column<float>(nullable: true),
                    IsChemicalAsso = table.Column<bool>(nullable: false),
                    AdvInTaxDed = table.Column<float>(nullable: true),
                    IsAdvInTaxDed = table.Column<bool>(nullable: false),
                    ConvAllowDed = table.Column<float>(nullable: true),
                    IsConvAllowDed = table.Column<bool>(nullable: false),
                    DedIncBonusOf = table.Column<float>(nullable: true),
                    IsDedIncBonusOf = table.Column<bool>(nullable: false),
                    UnionSubDed = table.Column<float>(nullable: true),
                    IsUnionSubDed = table.Column<bool>(nullable: false),
                    EmpClubDed = table.Column<float>(nullable: true),
                    IsEmpClubDed = table.Column<bool>(nullable: false),
                    MedicalExp = table.Column<float>(nullable: true),
                    IsMedicalExp = table.Column<bool>(nullable: false),
                    WagesaAdv = table.Column<float>(nullable: true),
                    IsWagesaAdv = table.Column<bool>(nullable: false),
                    MedicalLoanDed = table.Column<float>(nullable: true),
                    IsMedicalLoanDed = table.Column<bool>(nullable: false),
                    AdvWagesDed = table.Column<float>(nullable: true),
                    IsAdvWagesDed = table.Column<bool>(nullable: false),
                    WFL = table.Column<float>(nullable: true),
                    IsWFL = table.Column<bool>(nullable: false),
                    CheForum = table.Column<float>(nullable: true),
                    IsCheForum = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_Salary", x => x.SalaryId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_BuildingType_BId",
                        column: x => x.BId,
                        principalTable: "Cat_BuildingType",
                        principalColumn: "BId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_HBLId",
                        column: x => x.HBLId,
                        principalTable: "Cat_Location",
                        principalColumn: "LId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_LId1",
                        column: x => x.LId1,
                        principalTable: "Cat_Location",
                        principalColumn: "LId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_LId2",
                        column: x => x.LId2,
                        principalTable: "Cat_Location",
                        principalColumn: "LId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_LId3",
                        column: x => x.LId3,
                        principalTable: "Cat_Location",
                        principalColumn: "LId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_MCLId",
                        column: x => x.MCLId,
                        principalTable: "Cat_Location",
                        principalColumn: "LId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_PFLId",
                        column: x => x.PFLId,
                        principalTable: "Cat_Location",
                        principalColumn: "LId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Emp_Salary_Cat_Location_WelfareLId",
                        column: x => x.WelfareLId,
                        principalTable: "Cat_Location",
                        principalColumn: "LId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_BId",
                table: "HR_Emp_Salary",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_EmpId",
                table: "HR_Emp_Salary",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_HBLId",
                table: "HR_Emp_Salary",
                column: "HBLId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_LId1",
                table: "HR_Emp_Salary",
                column: "LId1");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_LId2",
                table: "HR_Emp_Salary",
                column: "LId2");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_LId3",
                table: "HR_Emp_Salary",
                column: "LId3");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_MCLId",
                table: "HR_Emp_Salary",
                column: "MCLId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_PFLId",
                table: "HR_Emp_Salary",
                column: "PFLId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Salary_WelfareLId",
                table: "HR_Emp_Salary",
                column: "WelfareLId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Emp_Salary");

            migrationBuilder.DropTable(
                name: "Cat_Location");

            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "HR_Emp_Address",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
