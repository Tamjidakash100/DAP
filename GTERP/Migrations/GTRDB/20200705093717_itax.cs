using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class itax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PFIndDtFrom",
                table: "SalaryProcess",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PFIndDtTo",
                table: "SalaryProcess",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PFIndPercentage",
                table: "SalaryProcess",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cat_ITaxBank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    MonthDate = table.Column<DateTime>(nullable: false),
                    ChqDate = table.Column<DateTime>(nullable: false),
                    ChqNo = table.Column<string>(maxLength: 50, nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_ITaxBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat_ITaxBank_Cat_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Cat_Bank",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_ITaxBank_Cat_BankBranch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Cat_BankBranch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_ITaxBank_BankId",
                table: "Cat_ITaxBank",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_ITaxBank_BranchId",
                table: "Cat_ITaxBank",
                column: "BranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_ITaxBank");

            migrationBuilder.DropColumn(
                name: "PFIndDtFrom",
                table: "SalaryProcess");

            migrationBuilder.DropColumn(
                name: "PFIndDtTo",
                table: "SalaryProcess");

            migrationBuilder.DropColumn(
                name: "PFIndPercentage",
                table: "SalaryProcess");
        }
    }
}
