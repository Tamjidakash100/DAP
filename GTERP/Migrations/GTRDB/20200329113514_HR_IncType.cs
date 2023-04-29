using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class HR_IncType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncType",
                table: "HR_Emp_Increment");

            migrationBuilder.AddColumn<int>(
                name: "IncTypeId",
                table: "HR_Emp_Increment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HR_IncType",
                columns: table => new
                {
                    IncTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    IncType = table.Column<string>(maxLength: 40, nullable: true),
                    PcName = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DtTran = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_IncType", x => x.IncTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Increment_IncTypeId",
                table: "HR_Emp_Increment",
                column: "IncTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Increment_HR_IncType_IncTypeId",
                table: "HR_Emp_Increment",
                column: "IncTypeId",
                principalTable: "HR_IncType",
                principalColumn: "IncTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Increment_HR_IncType_IncTypeId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropTable(
                name: "HR_IncType");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Increment_IncTypeId",
                table: "HR_Emp_Increment");

            migrationBuilder.DropColumn(
                name: "IncTypeId",
                table: "HR_Emp_Increment");

            migrationBuilder.AddColumn<string>(
                name: "IncType",
                table: "HR_Emp_Increment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
