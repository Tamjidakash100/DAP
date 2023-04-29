using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class medicalpart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_MedicalDiagnosis",
                columns: table => new
                {
                    DiagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagName = table.Column<string>(maxLength: 50, nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_MedicalDiagnosis", x => x.DiagId);
                });

            //migrationBuilder.CreateTable(
            //    name: "HR_Loan_IncreaseInfo",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EmpId = table.Column<int>(nullable: false),
            //        LoanType = table.Column<string>(maxLength: 20, nullable: true),
            //        TtlIncreaseMonth = table.Column<int>(nullable: false),
            //        DtEffectiveMonth = table.Column<DateTime>(nullable: false),
            //        Remarks = table.Column<string>(maxLength: 400, nullable: true),
            //        InputType = table.Column<string>(maxLength: 15, nullable: true),
            //        ComId = table.Column<string>(maxLength: 80, nullable: true),
            //        UserId = table.Column<string>(maxLength: 80, nullable: true),
            //        DateAdded = table.Column<DateTime>(nullable: true),
            //        UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
            //        DateUpdated = table.Column<DateTime>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HR_Loan_IncreaseInfo", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Medical_Master",
                columns: table => new
                {
                    MedicalMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    PrdUnitId = table.Column<int>(nullable: false),
                    DesigId = table.Column<int>(nullable: false),
                    SectId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    Pulse = table.Column<float>(nullable: false),
                    BP = table.Column<float>(nullable: false),
                    DiagId = table.Column<int>(nullable: false),
                    Advice = table.Column<string>(maxLength: 300, nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medical_Master", x => x.MedicalMasterId);
                    table.ForeignKey(
                        name: "FK_Medical_Master_Cat_Designation_DesigId",
                        column: x => x.DesigId,
                        principalTable: "Cat_Designation",
                        principalColumn: "DesigId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medical_Master_Cat_MedicalDiagnosis_DiagId",
                        column: x => x.DiagId,
                        principalTable: "Cat_MedicalDiagnosis",
                        principalColumn: "DiagId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medical_Master_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medical_Master_PrdUnits_PrdUnitId",
                        column: x => x.PrdUnitId,
                        principalTable: "PrdUnits",
                        principalColumn: "PrdUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medical_Master_Cat_Section_SectId",
                        column: x => x.SectId,
                        principalTable: "Cat_Section",
                        principalColumn: "SectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medical_Master_Cat_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Cat_Unit",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medical_Details",
                columns: table => new
                {
                    MedicalDetaisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalMasterId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    UOM = table.Column<string>(maxLength: 10, nullable: true),
                    Quantity = table.Column<float>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 100, nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medical_Details", x => x.MedicalDetaisId);
                    table.ForeignKey(
                        name: "FK_Medical_Details_Medical_Master_MedicalMasterId",
                        column: x => x.MedicalMasterId,
                        principalTable: "Medical_Master",
                        principalColumn: "MedicalMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medical_Details_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Details_MedicalMasterId",
                table: "Medical_Details",
                column: "MedicalMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Details_ProductId",
                table: "Medical_Details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Master_DesigId",
                table: "Medical_Master",
                column: "DesigId");

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Master_DiagId",
                table: "Medical_Master",
                column: "DiagId");

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Master_EmpId",
                table: "Medical_Master",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Master_PrdUnitId",
                table: "Medical_Master",
                column: "PrdUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Master_SectId",
                table: "Medical_Master",
                column: "SectId");

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Master_UnitId",
                table: "Medical_Master",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Loan_IncreaseInfo");

            migrationBuilder.DropTable(
                name: "Medical_Details");

            migrationBuilder.DropTable(
                name: "Medical_Master");

            migrationBuilder.DropTable(
                name: "Cat_MedicalDiagnosis");
        }
    }
}
