using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class combangla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DtTran",
                table: "HR_Loan_HouseBuilding",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtTran",
                table: "HR_Loan_Data_HouseBuilding",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddressBangla",
                table: "Companys",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyNameBangla",
                table: "Companys",
                maxLength: 80,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyAddressBangla",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "CompanyNameBangla",
                table: "Companys");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtTran",
                table: "HR_Loan_HouseBuilding",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtTran",
                table: "HR_Loan_Data_HouseBuilding",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
