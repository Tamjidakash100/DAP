using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class addBI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_AccountType",
                columns: table => new
                {
                    AccTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccTypeName = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_AccountType", x => x.AccTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_PayMode",
                columns: table => new
                {
                    PayModeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayModeName = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_PayMode", x => x.PayModeId);
                });

            migrationBuilder.CreateTable(
                name: "HR_Emp_BankInfo",
                columns: table => new
                {
                    BankInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    PayModeId = table.Column<int>(nullable: false),
                    AccTypeId = table.Column<int>(nullable: false),
                    BankId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    RoutingNumber = table.Column<string>(maxLength: 15, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 25, nullable: true),
                    AccountName = table.Column<string>(maxLength: 60, nullable: true),
                    IsApproved = table.Column<bool>(maxLength: 30, nullable: false),
                    ComId = table.Column<string>(maxLength: 80, nullable: true),
                    PcName = table.Column<string>(maxLength: 60, nullable: true),
                    UserId = table.Column<string>(maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_BankInfo", x => x.BankInfoId);
                    table.ForeignKey(
                        name: "FK_HR_Emp_BankInfo_Cat_AccountType_AccTypeId",
                        column: x => x.AccTypeId,
                        principalTable: "Cat_AccountType",
                        principalColumn: "AccTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_BankInfo_Cat_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Cat_Bank",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_BankInfo_Cat_BankBranch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Cat_BankBranch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_BankInfo_HR_Emp_Info_EmpId",
                        column: x => x.EmpId,
                        principalTable: "HR_Emp_Info",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_Emp_BankInfo_Cat_PayMode_PayModeId",
                        column: x => x.PayModeId,
                        principalTable: "Cat_PayMode",
                        principalColumn: "PayModeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_BankInfo_AccTypeId",
                table: "HR_Emp_BankInfo",
                column: "AccTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_BankInfo_BankId",
                table: "HR_Emp_BankInfo",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_BankInfo_BranchId",
                table: "HR_Emp_BankInfo",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_BankInfo_EmpId",
                table: "HR_Emp_BankInfo",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_BankInfo_PayModeId",
                table: "HR_Emp_BankInfo",
                column: "PayModeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Emp_BankInfo");

            migrationBuilder.DropTable(
                name: "Cat_AccountType");

            migrationBuilder.DropTable(
                name: "Cat_PayMode");
        }
    }
}
