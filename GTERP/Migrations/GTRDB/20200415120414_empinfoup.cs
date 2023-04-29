using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class empinfoup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdateByUserId",
                table: "HR_Loan_Data_HouseBuilding",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateByUserId",
                table: "HR_Emp_PersonalInfo",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactName",
                table: "HR_Emp_PersonalInfo",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactNo",
                table: "HR_Emp_PersonalInfo",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpFileNo",
                table: "HR_Emp_PersonalInfo",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeCodeBCIC",
                table: "HR_Emp_PersonalInfo",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "HR_Emp_PersonalInfo",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicalBookNo",
                table: "HR_Emp_PersonalInfo",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PFFileNo",
                table: "HR_Emp_PersonalInfo",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PoliceVerificationStatus",
                table: "HR_Emp_PersonalInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RelationEmerContact",
                table: "HR_Emp_PersonalInfo",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmpName",
                table: "HR_Emp_Info",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmpCode",
                table: "HR_Emp_Info",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpNameB",
                table: "HR_Emp_Info",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpFatherB",
                table: "HR_Emp_Family",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpMotherB",
                table: "HR_Emp_Family",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpSpouseB",
                table: "HR_Emp_Family",
                maxLength: 60,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmergencyContactName",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "EmergencyContactNo",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "EmpFileNo",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "EmployeeCodeBCIC",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "MedicalBookNo",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "PFFileNo",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "PoliceVerificationStatus",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "RelationEmerContact",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "EmpNameB",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpFatherB",
                table: "HR_Emp_Family");

            migrationBuilder.DropColumn(
                name: "EmpMotherB",
                table: "HR_Emp_Family");

            migrationBuilder.DropColumn(
                name: "EmpSpouseB",
                table: "HR_Emp_Family");

            migrationBuilder.AlterColumn<string>(
                name: "UpdateByUserId",
                table: "HR_Loan_Data_HouseBuilding",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdateByUserId",
                table: "HR_Emp_PersonalInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmpName",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EmpCode",
                table: "HR_Emp_Info",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
