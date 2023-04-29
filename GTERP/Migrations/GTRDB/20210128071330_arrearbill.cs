using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class arrearbill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_Emp_ArrearBill",
                columns: table => new
                {
                    ArrBillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    EmpId = table.Column<int>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false),
                    DtFrom = table.Column<DateTime>(nullable: false),
                    DtTo = table.Column<DateTime>(nullable: false),
                    TtlMonth = table.Column<float>(nullable: false),
                    TtlDay = table.Column<float>(nullable: false),
                    DtFromMonth = table.Column<DateTime>(nullable: false),
                    DtToMonth = table.Column<DateTime>(nullable: false),
                    NewBS = table.Column<float>(nullable: true),
                    OldBS = table.Column<float>(nullable: true),
                    BSDiff = table.Column<float>(nullable: true),
                    TtlArrearBS = table.Column<float>(nullable: true),
                    NewHR = table.Column<float>(nullable: true),
                    OldHR = table.Column<float>(nullable: true),
                    HRDiff = table.Column<float>(nullable: true),
                    TtlArrearHR = table.Column<float>(nullable: true),
                    NewMA = table.Column<float>(nullable: true),
                    OldMA = table.Column<float>(nullable: true),
                    MADiff = table.Column<float>(nullable: true),
                    TtlArrearMA = table.Column<float>(nullable: true),
                    NewEduAllow = table.Column<float>(nullable: true),
                    OldEduAllow = table.Column<float>(nullable: true),
                    EduAllowDiff = table.Column<float>(nullable: true),
                    TtlArrearEduAllow = table.Column<float>(nullable: true),
                    NewTiffinAllow = table.Column<float>(nullable: true),
                    OldTiffinAllow = table.Column<float>(nullable: true),
                    TiffinAllowDiff = table.Column<float>(nullable: true),
                    TtlArrearTiffinAllow = table.Column<float>(nullable: true),
                    NewRiskAllow = table.Column<float>(nullable: true),
                    OldRiskAllow = table.Column<float>(nullable: true),
                    RiskAllowDiff = table.Column<float>(nullable: true),
                    TtlArrearRiskAllow = table.Column<float>(nullable: true),
                    NewPF = table.Column<float>(nullable: true),
                    OldPF = table.Column<float>(nullable: true),
                    PFDiff = table.Column<float>(nullable: true),
                    TtlPF = table.Column<float>(nullable: true),
                    TotalArrearPayable = table.Column<float>(nullable: true),
                    DAAllowDed = table.Column<float>(nullable: true),
                    Adv = table.Column<float>(nullable: true),
                    Stamp = table.Column<float>(nullable: true),
                    TotalArrearDeduction = table.Column<float>(nullable: true),
                    NetArrearPayable = table.Column<float>(nullable: true),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_ArrearBill", x => x.ArrBillId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_ArrearBill_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_ArrearBill_EmpId",
                table: "HR_Emp_ArrearBill",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Emp_ArrearBill");
        }
    }
}
