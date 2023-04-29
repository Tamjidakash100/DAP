using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class pfcontribution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DtPf",
                table: "HR_Emp_Info");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtPF",
                table: "HR_Emp_PersonalInfo",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAllowPF",
                table: "HR_Emp_PersonalInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PFMember",
                table: "HR_Emp_PersonalInfo",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HR_PFContribution",
                columns: table => new
                {
                    PFContributionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    DtInput = table.Column<DateTime>(nullable: false),
                    DtJoin = table.Column<DateTime>(nullable: false),
                    PF = table.Column<string>(maxLength: 100, nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 60, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_PFContribution", x => x.PFContributionId);
                    table.ForeignKey(
                        name: "FK_HR_PFContribution_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_PFContribution_EmpId",
                table: "HR_PFContribution",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_PFContribution");

            migrationBuilder.DropColumn(
                name: "DtPF",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "IsAllowPF",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.DropColumn(
                name: "PFMember",
                table: "HR_Emp_PersonalInfo");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtPf",
                table: "HR_Emp_Info",
                type: "datetime2",
                nullable: true);
        }
    }
}
