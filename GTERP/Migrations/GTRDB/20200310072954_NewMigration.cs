using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_SubSections_SubSectionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherSubSections_SubSections_SubSectionId",
                table: "VoucherSubSections");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "SubSections");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Employee_SubSectionId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SubSectionId",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "Cat_SubSectionSubSectionId",
                table: "Employee",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cat_Department",
                columns: table => new
                {
                    DeptId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<int>(nullable: false),
                    DeptCode = table.Column<string>(nullable: true),
                    DeptName = table.Column<string>(nullable: false),
                    Pcname = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Cat_Department", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Designation",
                columns: table => new
                {
                    DesigId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<int>(nullable: true),
                    DesigName = table.Column<string>(nullable: true),
                    DesigNameB = table.Column<string>(nullable: true),
                    Pcname = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Cat_Designation", x => x.DesigId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Section",
                columns: table => new
                {
                    SectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slno = table.Column<short>(nullable: false),
                    ComId = table.Column<byte>(nullable: false),
                    SectName = table.Column<string>(nullable: true),
                    SectNameB = table.Column<string>(nullable: true),
                    DeptId = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Pcname = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Section", x => x.SectId);
                    table.ForeignKey(
                        name: "FK_Cat_Section_Cat_Department_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cat_SubSection",
                columns: table => new
                {
                    SubSectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slno = table.Column<short>(nullable: false),
                    Cat_SubSectionName = table.Column<string>(nullable: true),
                    SubSectNameB = table.Column<string>(nullable: true),
                    Pcname = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    SectId = table.Column<int>(nullable: false),
                    DeptId = table.Column<int>(nullable: false),
                    SectName = table.Column<string>(nullable: true),
                    SrtName = table.Column<string>(nullable: true),
                    IsStrDpt = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_SubSection", x => x.SubSectionId);
                    table.ForeignKey(
                        name: "FK_Cat_SubSection_Cat_Department_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Cat_Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cat_SubSection_Cat_Section_SectId",
                        column: x => x.SectId,
                        principalTable: "Cat_Section",
                        principalColumn: "SectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Cat_SubSectionSubSectionId",
                table: "Employee",
                column: "Cat_SubSectionSubSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Section_DeptId",
                table: "Cat_Section",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_SubSection_DeptId",
                table: "Cat_SubSection",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_SubSection_SectId",
                table: "Cat_SubSection",
                column: "SectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_SubSection_Cat_SubSectionSubSectionId",
                table: "Employee",
                column: "Cat_SubSectionSubSectionId",
                principalTable: "Cat_SubSection",
                principalColumn: "SubSectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherSubSections_Cat_SubSection_SubSectionId",
                table: "VoucherSubSections",
                column: "SubSectionId",
                principalTable: "Cat_SubSection",
                principalColumn: "SubSectionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_SubSection_Cat_SubSectionSubSectionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherSubSections_Cat_SubSection_SubSectionId",
                table: "VoucherSubSections");

            migrationBuilder.DropTable(
                name: "Cat_Designation");

            migrationBuilder.DropTable(
                name: "Cat_SubSection");

            migrationBuilder.DropTable(
                name: "Cat_Section");

            migrationBuilder.DropTable(
                name: "Cat_Department");

            migrationBuilder.DropIndex(
                name: "IX_Employee_Cat_SubSectionSubSectionId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Cat_SubSectionSubSectionId",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "SubSectionId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buid = table.Column<short>(type: "smallint", nullable: true),
                    Buname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComId = table.Column<int>(type: "int", nullable: false),
                    DeptBangla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeptCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DptSrtName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsStrDpt = table.Column<byte>(type: "tinyint", nullable: true),
                    LuserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Pcname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slno = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    DesigId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttBonus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComId = table.Column<int>(type: "int", nullable: true),
                    DesigName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesigNameB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dslno = table.Column<int>(type: "int", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gsmin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LuserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MngSalary = table.Column<byte>(type: "tinyint", nullable: false),
                    OffGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pcname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftAllow = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.DesigId);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<byte>(type: "tinyint", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: true),
                    LuserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pcname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectNameB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slno = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectId);
                    table.ForeignKey(
                        name: "FK_Sections_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubSections",
                columns: table => new
                {
                    SubSectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    IsStrDpt = table.Column<byte>(type: "tinyint", nullable: false),
                    LuserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pcname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectId = table.Column<int>(type: "int", nullable: false),
                    SectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slno = table.Column<short>(type: "smallint", nullable: false),
                    SrtName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubSectNameB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubSectionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSections", x => x.SubSectionId);
                    table.ForeignKey(
                        name: "FK_SubSections_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubSections_Sections_SectId",
                        column: x => x.SectId,
                        principalTable: "Sections",
                        principalColumn: "SectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SubSectionId",
                table: "Employee",
                column: "SubSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_DeptId",
                table: "Sections",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSections_DeptId",
                table: "SubSections",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSections_SectId",
                table: "SubSections",
                column: "SectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_SubSections_SubSectionId",
                table: "Employee",
                column: "SubSectionId",
                principalTable: "SubSections",
                principalColumn: "SubSectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherSubSections_SubSections_SubSectionId",
                table: "VoucherSubSections",
                column: "SubSectionId",
                principalTable: "SubSections",
                principalColumn: "SubSectionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
