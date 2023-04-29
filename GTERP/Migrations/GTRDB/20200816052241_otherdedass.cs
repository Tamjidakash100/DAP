using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class otherdedass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OtherLoanType",
                table: "HR_Loan_IncreaseInfo",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HR_OtherDedAssociation",
                columns: table => new
                {
                    OtherDedAssId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProssType = table.Column<string>(maxLength: 20, nullable: true),
                    OtherDedName = table.Column<string>(maxLength: 20, nullable: true),
                    OtherDedNameB = table.Column<string>(maxLength: 20, nullable: true),
                    AccountNo = table.Column<string>(maxLength: 30, nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_OtherDedAssociation", x => x.OtherDedAssId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_OtherDedAssociation");

            migrationBuilder.AlterColumn<string>(
                name: "OtherLoanType",
                table: "HR_Loan_IncreaseInfo",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
