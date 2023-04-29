using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class BankandBranchInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_Bank",
                columns: table => new
                {
                    BankId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(maxLength: 60, nullable: false),
                    BankShortName = table.Column<string>(maxLength: 40, nullable: true),
                    BankAddress = table.Column<string>(maxLength: 250, nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Bank", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_BankBranch",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(maxLength: 70, nullable: false),
                    BranchAddress = table.Column<string>(maxLength: 250, nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_BankBranch", x => x.BranchId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat_Bank");

            migrationBuilder.DropTable(
                name: "Cat_BankBranch");
        }
    }
}
