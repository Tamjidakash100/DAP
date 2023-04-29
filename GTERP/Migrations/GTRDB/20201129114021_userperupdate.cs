using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class userperupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPermission_HR_Emp_Info_EmpId",
                table: "UserPermission");

            migrationBuilder.DropIndex(
                name: "IX_UserPermission_ComId_EmpId_AppUserId",
                table: "UserPermission");

            migrationBuilder.AlterColumn<int>(
                name: "EmpId",
                table: "UserPermission",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserPermission",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_ComId_EmpId_AppUserId",
                table: "UserPermission",
                columns: new[] { "ComId", "EmpId", "AppUserId" },
                unique: true,
                filter: "[ComId] IS NOT NULL AND [EmpId] IS NOT NULL AND [AppUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermission_HR_Emp_Info_EmpId",
                table: "UserPermission",
                column: "EmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPermission_HR_Emp_Info_EmpId",
                table: "UserPermission");

            migrationBuilder.DropIndex(
                name: "IX_UserPermission_ComId_EmpId_AppUserId",
                table: "UserPermission");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserPermission");

            migrationBuilder.AlterColumn<int>(
                name: "EmpId",
                table: "UserPermission",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_ComId_EmpId_AppUserId",
                table: "UserPermission",
                columns: new[] { "ComId", "EmpId", "AppUserId" },
                unique: true,
                filter: "[ComId] IS NOT NULL AND [AppUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermission_HR_Emp_Info_EmpId",
                table: "UserPermission",
                column: "EmpId",
                principalTable: "HR_Emp_Info",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
