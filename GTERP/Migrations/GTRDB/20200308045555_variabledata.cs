using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class variabledata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_SubSections_SubSectionSubSectId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherSubSections_SubSections_SubSectionSubSectId",
                table: "VoucherSubSections");

            migrationBuilder.DropTable(
                name: "TblCatArea");

            migrationBuilder.DropIndex(
                name: "IX_VoucherSubSections_SubSectionSubSectId",
                table: "VoucherSubSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubSections",
                table: "SubSections");

            migrationBuilder.DropIndex(
                name: "IX_Employee_SubSectionSubSectId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SubSectionSubSectId",
                table: "VoucherSubSections");

            migrationBuilder.DropColumn(
                name: "SubSectId",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "SubSectName",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "SubSectionSubSectId",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "SLNo",
                table: "SubSections",
                newName: "Slno");

            migrationBuilder.AddColumn<int>(
                name: "SubSectionId",
                table: "VoucherSubSections",
                nullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Slno",
                table: "SubSections",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SubSectionId",
                table: "SubSections",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "SubSections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "IsStrDpt",
                table: "SubSections",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "LuserId",
                table: "SubSections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pcname",
                table: "SubSections",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectId",
                table: "SubSections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SectName",
                table: "SubSections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SrtName",
                table: "SubSections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubSectNameB",
                table: "SubSections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubSectionName",
                table: "SubSections",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubSectionId",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubSections",
                table: "SubSections",
                column: "SubSectionId");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<int>(nullable: false),
                    DeptCode = table.Column<string>(nullable: true),
                    DeptName = table.Column<string>(nullable: true),
                    Pcname = table.Column<string>(nullable: true),
                    LuserId = table.Column<int>(nullable: true),
                    DeptBangla = table.Column<string>(nullable: true),
                    Slno = table.Column<short>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Buid = table.Column<short>(nullable: true),
                    Buname = table.Column<string>(nullable: true),
                    DptSrtName = table.Column<string>(nullable: true),
                    IsStrDpt = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    DesigId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<int>(nullable: true),
                    DesigName = table.Column<string>(nullable: true),
                    DesigNameB = table.Column<string>(nullable: true),
                    Pcname = table.Column<string>(nullable: true),
                    LuserId = table.Column<int>(nullable: true),
                    Dslno = table.Column<int>(nullable: true),
                    Gsmin = table.Column<decimal>(nullable: true),
                    Grade = table.Column<string>(nullable: true),
                    OffGrade = table.Column<string>(nullable: true),
                    MngSalary = table.Column<byte>(nullable: false),
                    AttBonus = table.Column<decimal>(nullable: false),
                    ShiftAllow = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.DesigId);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slno = table.Column<short>(nullable: false),
                    ComId = table.Column<byte>(nullable: false),
                    SectName = table.Column<string>(nullable: true),
                    SectNameB = table.Column<string>(nullable: true),
                    DeptId = table.Column<int>(nullable: false),
                    CostSect = table.Column<short>(nullable: true),
                    CostSubSect = table.Column<short>(nullable: true),
                    CostSectTotal = table.Column<decimal>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Pcname = table.Column<string>(nullable: true),
                    LuserId = table.Column<int>(nullable: true),
                    DeptName = table.Column<string>(nullable: true),
                    EmpIdSrtName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectId);
                    table.ForeignKey(
                        name: "FK_Sections_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoucherSubSections_SubSectionId",
                table: "VoucherSubSections",
                column: "SubSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSections_DeptId",
                table: "SubSections",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSections_SectId",
                table: "SubSections",
                column: "SectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SubSectionId",
                table: "Employee",
                column: "SubSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_DeptId",
                table: "Sections",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_SubSections_SubSectionId",
                table: "Employee",
                column: "SubSectionId",
                principalTable: "SubSections",
                principalColumn: "SubSectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubSections_Departments_DeptId",
                table: "SubSections",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubSections_Sections_SectId",
                table: "SubSections",
                column: "SectId",
                principalTable: "Sections",
                principalColumn: "SectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherSubSections_SubSections_SubSectionId",
                table: "VoucherSubSections",
                column: "SubSectionId",
                principalTable: "SubSections",
                principalColumn: "SubSectionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_SubSections_SubSectionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_SubSections_Departments_DeptId",
                table: "SubSections");

            migrationBuilder.DropForeignKey(
                name: "FK_SubSections_Sections_SectId",
                table: "SubSections");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherSubSections_SubSections_SubSectionId",
                table: "VoucherSubSections");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_VoucherSubSections_SubSectionId",
                table: "VoucherSubSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubSections",
                table: "SubSections");

            migrationBuilder.DropIndex(
                name: "IX_SubSections_DeptId",
                table: "SubSections");

            migrationBuilder.DropIndex(
                name: "IX_SubSections_SectId",
                table: "SubSections");

            migrationBuilder.DropIndex(
                name: "IX_Employee_SubSectionId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SubSectionId",
                table: "VoucherSubSections");

            migrationBuilder.DropColumn(
                name: "SubSectionId",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "IsStrDpt",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "LuserId",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "Pcname",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "SectId",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "SectName",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "SrtName",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "SubSectNameB",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "SubSectionName",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "SubSectionId",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "Slno",
                table: "SubSections",
                newName: "SLNo");

            migrationBuilder.AddColumn<int>(
                name: "SubSectionSubSectId",
                table: "VoucherSubSections",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SLNo",
                table: "SubSections",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AddColumn<int>(
                name: "SubSectId",
                table: "SubSections",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "SubSections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubSectName",
                table: "SubSections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubSectionSubSectId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubSections",
                table: "SubSections",
                column: "SubSectId");

            migrationBuilder.CreateTable(
                name: "TblCatArea",
                columns: table => new
                {
                    AreaId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaNameShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comid = table.Column<int>(type: "int", nullable: true),
                    LuserId = table.Column<int>(type: "int", nullable: true),
                    Pcname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCatArea", x => x.AreaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoucherSubSections_SubSectionSubSectId",
                table: "VoucherSubSections",
                column: "SubSectionSubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SubSectionSubSectId",
                table: "Employee",
                column: "SubSectionSubSectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_SubSections_SubSectionSubSectId",
                table: "Employee",
                column: "SubSectionSubSectId",
                principalTable: "SubSections",
                principalColumn: "SubSectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherSubSections_SubSections_SubSectionSubSectId",
                table: "VoucherSubSections",
                column: "SubSectionSubSectId",
                principalTable: "SubSections",
                principalColumn: "SubSectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
