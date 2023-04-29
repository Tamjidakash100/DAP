using Microsoft.EntityFrameworkCore.Migrations;


namespace GTERP.Migrations.GTRDB
{
    public partial class approvalpanelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalPanels_ApprovalRoles_ApprovalRoleId",
                table: "ApprovalPanels");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalPanels_ReportTypes_ReportTypeId",
                table: "ApprovalPanels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ApprovalPanels");

            migrationBuilder.AlterColumn<int>(
                name: "ReportTypeId",
                table: "ApprovalPanels",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApprovalRoleId",
                table: "ApprovalPanels",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedUserId",
                table: "ApprovalPanels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserId",
                table: "ApprovalPanels",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalPanels_ApprovalRoles_ApprovalRoleId",
                table: "ApprovalPanels",
                column: "ApprovalRoleId",
                principalTable: "ApprovalRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalPanels_ReportTypes_ReportTypeId",
                table: "ApprovalPanels",
                column: "ReportTypeId",
                principalTable: "ReportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalPanels_ApprovalRoles_ApprovalRoleId",
                table: "ApprovalPanels");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalPanels_ReportTypes_ReportTypeId",
                table: "ApprovalPanels");

            migrationBuilder.DropColumn(
                name: "ApprovedUserId",
                table: "ApprovalPanels");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "ApprovalPanels");

            migrationBuilder.AlterColumn<int>(
                name: "ReportTypeId",
                table: "ApprovalPanels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ApprovalRoleId",
                table: "ApprovalPanels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ApprovalPanels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalPanels_ApprovalRoles_ApprovalRoleId",
                table: "ApprovalPanels",
                column: "ApprovalRoleId",
                principalTable: "ApprovalRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalPanels_ReportTypes_ReportTypeId",
                table: "ApprovalPanels",
                column: "ReportTypeId",
                principalTable: "ReportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
