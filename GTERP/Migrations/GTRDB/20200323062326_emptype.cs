using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class emptype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpType",
                table: "HR_Emp_Info");

            migrationBuilder.AddColumn<int>(
                name: "EmpTypeId",
                table: "HR_Emp_Info",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cat_Emp_Type",
                columns: table => new
                {
                    EmpTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpTypeName = table.Column<string>(maxLength: 30, nullable: true),
                    EmpTypeNameB = table.Column<string>(maxLength: 30, nullable: true),
                    ComId = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Emp_Type", x => x.EmpTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Emp_Info_EmpTypeId",
                table: "HR_Emp_Info",
                column: "EmpTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HR_Emp_Info_Cat_Emp_Type_EmpTypeId",
                table: "HR_Emp_Info",
                column: "EmpTypeId",
                principalTable: "Cat_Emp_Type",
                principalColumn: "EmpTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HR_Emp_Info_Cat_Emp_Type_EmpTypeId",
                table: "HR_Emp_Info");

            migrationBuilder.DropTable(
                name: "Cat_Emp_Type");

            migrationBuilder.DropIndex(
                name: "IX_HR_Emp_Info_EmpTypeId",
                table: "HR_Emp_Info");

            migrationBuilder.DropColumn(
                name: "EmpTypeId",
                table: "HR_Emp_Info");

            migrationBuilder.AddColumn<string>(
                name: "EmpType",
                table: "HR_Emp_Info",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
