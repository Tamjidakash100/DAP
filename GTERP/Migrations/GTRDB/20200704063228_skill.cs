using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class skill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Skill",
                table: "HR_Emp_Info");

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "HR_Emp_Info",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cat_Skill",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(maxLength: 40, nullable: false),
                    SkillNameB = table.Column<string>(maxLength: 40, nullable: true),
                    ComId = table.Column<string>(maxLength: 128, nullable: true),
                    PcName = table.Column<string>(maxLength: 25, nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Skill", x => x.SkillId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Info_SkillId",
                table: "HR_Emp_Info",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Info_Cat_Skill_SkillId",
                table: "HR_Emp_Info",
                column: "SkillId",
                principalTable: "Cat_Skill",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Info_Cat_Skill_SkillId",
                table: "HR_Emp_Info");

            migrationBuilder.DropTable(
                name: "Cat_Skill");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Info_SkillId",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "HR_Emp_Info");

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "HR_Emp_Info",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
