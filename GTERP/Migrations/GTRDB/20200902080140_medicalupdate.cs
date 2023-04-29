using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class medicalupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medical_Master_Cat_Designation_DesigId",
                table: "Medical_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_Medical_Master_PrdUnits_PrdUnitId",
                table: "Medical_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_Medical_Master_Cat_Section_SectId",
                table: "Medical_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_Medical_Master_Cat_Unit_UnitId",
                table: "Medical_Master");

            migrationBuilder.DropIndex(
                name: "IX_Medical_Master_DesigId",
                table: "Medical_Master");

            migrationBuilder.DropIndex(
                name: "IX_Medical_Master_PrdUnitId",
                table: "Medical_Master");

            migrationBuilder.DropIndex(
                name: "IX_Medical_Master_SectId",
                table: "Medical_Master");

            migrationBuilder.DropIndex(
                name: "IX_Medical_Master_UnitId",
                table: "Medical_Master");

            migrationBuilder.DropColumn(
                name: "DesigId",
                table: "Medical_Master");

            migrationBuilder.DropColumn(
                name: "PrdUnitId",
                table: "Medical_Master");

            migrationBuilder.DropColumn(
                name: "SectId",
                table: "Medical_Master");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Medical_Master");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Medical_Master",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Patient",
                table: "Medical_Master",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Master_DoctorId",
                table: "Medical_Master",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medical_Master_HR_Emp_Info_DoctorId",
                table: "Medical_Master",
                column: "DoctorId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medical_Master_HR_Emp_Info_DoctorId",
                table: "Medical_Master");

            migrationBuilder.DropIndex(
                name: "IX_Medical_Master_DoctorId",
                table: "Medical_Master");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Medical_Master");

            migrationBuilder.DropColumn(
                name: "Patient",
                table: "Medical_Master");

            migrationBuilder.AddColumn<int>(
                name: "DesigId",
                table: "Medical_Master",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrdUnitId",
                table: "Medical_Master",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectId",
                table: "Medical_Master",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Medical_Master",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Medical_Master_DesigId",
                table: "Medical_Master",
                column: "DesigId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Medical_Master_Cat_Designation_DesigId",
                table: "Medical_Master",
                column: "DesigId",
                principalTable: "Cat_Designation",
                principalColumn: "DesigId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medical_Master_PrdUnits_PrdUnitId",
                table: "Medical_Master",
                column: "PrdUnitId",
                principalTable: "PrdUnits",
                principalColumn: "PrdUnitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medical_Master_Cat_Section_SectId",
                table: "Medical_Master",
                column: "SectId",
                principalTable: "Cat_Section",
                principalColumn: "SectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medical_Master_Cat_Unit_UnitId",
                table: "Medical_Master",
                column: "UnitId",
                principalTable: "Cat_Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
