using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class processlockcoladd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiscalMonthId",
                table: "HR_ProcessLock",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FiscalYearId",
                table: "HR_ProcessLock",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isLockedAccounts",
                table: "Acc_FiscalMonths",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isLockedAttendance",
                table: "Acc_FiscalMonths",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isLockedSalary",
                table: "Acc_FiscalMonths",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isLockedStore",
                table: "Acc_FiscalMonths",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_HR_ProcessLock_FiscalMonthId",
                table: "HR_ProcessLock",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_ProcessLock_FiscalYearId",
                table: "HR_ProcessLock",
                column: "FiscalYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_ProcessLock_Acc_FiscalMonths_FiscalMonthId",
                table: "HR_ProcessLock",
                column: "FiscalMonthId",
                principalTable: "Acc_FiscalMonths",
                principalColumn: "FiscalMonthId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HR_ProcessLock_Acc_FiscalYears_FiscalYearId",
                table: "HR_ProcessLock",
                column: "FiscalYearId",
                principalTable: "Acc_FiscalYears",
                principalColumn: "FiscalYearId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_ProcessLock_Acc_FiscalMonths_FiscalMonthId",
                table: "HR_ProcessLock");

            migrationBuilder.DropForeignKey(
                name: "FK_HR_ProcessLock_Acc_FiscalYears_FiscalYearId",
                table: "HR_ProcessLock");

            migrationBuilder.DropIndex(
                name: "IX_HR_ProcessLock_FiscalMonthId",
                table: "HR_ProcessLock");

            migrationBuilder.DropIndex(
                name: "IX_HR_ProcessLock_FiscalYearId",
                table: "HR_ProcessLock");

            migrationBuilder.DropColumn(
                name: "FiscalMonthId",
                table: "HR_ProcessLock");

            migrationBuilder.DropColumn(
                name: "FiscalYearId",
                table: "HR_ProcessLock");

            migrationBuilder.DropColumn(
                name: "isLockedAccounts",
                table: "Acc_FiscalMonths");

            migrationBuilder.DropColumn(
                name: "isLockedAttendance",
                table: "Acc_FiscalMonths");

            migrationBuilder.DropColumn(
                name: "isLockedSalary",
                table: "Acc_FiscalMonths");

            migrationBuilder.DropColumn(
                name: "isLockedStore",
                table: "Acc_FiscalMonths");
        }
    }
}
