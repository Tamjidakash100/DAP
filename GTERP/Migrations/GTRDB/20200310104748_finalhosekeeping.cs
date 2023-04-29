using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class finalhosekeeping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_SubSection_Cat_SubSectionSubSectionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherSubSections_Cat_SubSection_SubSectionId",
                table: "VoucherSubSections");

            migrationBuilder.DropIndex(
                name: "IX_VoucherSubSections_SubSectionId",
                table: "VoucherSubSections");

            migrationBuilder.DropIndex(
                name: "IX_Employee_Cat_SubSectionSubSectionId",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cat_SubSection",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "SubSectionId",
                table: "VoucherSubSections");

            migrationBuilder.DropColumn(
                name: "Cat_SubSectionSubSectionId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SubSectionId",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "Cat_SubSectionName",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "IsStrDpt",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "Pcname",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "SectName",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "SrtName",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Cat_Section");

            migrationBuilder.DropColumn(
                name: "Dslno",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "MngSalary",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "OffGrade",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "ShiftAllow",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "Buid",
                table: "Cat_Department");

            migrationBuilder.DropColumn(
                name: "Buname",
                table: "Cat_Department");

            migrationBuilder.DropColumn(
                name: "DptSrtName",
                table: "Cat_Department");

            migrationBuilder.DropColumn(
                name: "IsStrDpt",
                table: "Cat_Department");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Cat_Department");

            migrationBuilder.RenameColumn(
                name: "Pcname",
                table: "Cat_Section",
                newName: "PcName");

            migrationBuilder.RenameColumn(
                name: "Pcname",
                table: "Cat_Designation",
                newName: "PcName");

            migrationBuilder.RenameColumn(
                name: "Pcname",
                table: "Cat_Department",
                newName: "PcName");

            migrationBuilder.AddColumn<int>(
                name: "SubSectionSubSectId",
                table: "VoucherSubSections",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cat_SubSectionSubSectId",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubSectId",
                table: "Cat_SubSection",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ComId",
                table: "Cat_SubSection",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubSectName",
                table: "Cat_SubSection",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Cat_Section",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Slno",
                table: "Cat_Section",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "SectNameB",
                table: "Cat_Section",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SectName",
                table: "Cat_Section",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Cat_Section",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Cat_Section",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Cat_Section",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "Cat_Section",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Cat_Section",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MinGS",
                table: "Cat_Grade",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "GradeNameB",
                table: "Cat_Grade",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GradeName",
                table: "Cat_Grade",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "ComId",
                table: "Cat_Grade",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Cat_Grade",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Cat_Grade",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "Cat_Grade",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "Cat_Grade",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Cat_Grade",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cat_Grade",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DesigNameB",
                table: "Cat_Designation",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DesigName",
                table: "Cat_Designation",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Cat_Designation",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddByUserId",
                table: "Cat_Designation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Cat_Designation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Cat_Designation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "Cat_Designation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Cat_Designation",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SlNo",
                table: "Cat_Designation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Cat_Designation",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Cat_Department",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeptName",
                table: "Cat_Department",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeptBangla",
                table: "Cat_Department",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComId",
                table: "Cat_Department",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Cat_Department",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Cat_Department",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInput",
                table: "Cat_Department",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateByUserId",
                table: "Cat_Department",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cat_SubSection",
                table: "Cat_SubSection",
                column: "SubSectId");

            migrationBuilder.CreateTable(
                name: "Cat_BloodGroup",
                columns: table => new
                {
                    BloodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodName = table.Column<string>(maxLength: 30, nullable: false),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_BloodGroup", x => x.BloodId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_District",
                columns: table => new
                {
                    DistId = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistName = table.Column<string>(maxLength: 25, nullable: false),
                    DistNameShort = table.Column<string>(maxLength: 15, nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_District", x => x.DistId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Floor",
                columns: table => new
                {
                    LineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorName = table.Column<string>(maxLength: 30, nullable: false),
                    FloorNameB = table.Column<string>(maxLength: 30, nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Floor", x => x.LineId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Line",
                columns: table => new
                {
                    LineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineName = table.Column<string>(maxLength: 30, nullable: false),
                    LineNameB = table.Column<string>(maxLength: 30, nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Line", x => x.LineId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Religion",
                columns: table => new
                {
                    RelgionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReligionName = table.Column<string>(maxLength: 20, nullable: false),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Religion", x => x.RelgionId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Shift",
                columns: table => new
                {
                    ShiftId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(nullable: true),
                    ShiftName = table.Column<string>(maxLength: 25, nullable: false),
                    ShiftCode = table.Column<string>(maxLength: 25, nullable: true),
                    ShiftDesc = table.Column<string>(maxLength: 200, nullable: true),
                    ShiftIn = table.Column<DateTime>(nullable: false),
                    ShiftOut = table.Column<DateTime>(nullable: false),
                    ShiftLate = table.Column<DateTime>(nullable: false),
                    LunchTime = table.Column<DateTime>(nullable: false),
                    LunchIn = table.Column<DateTime>(nullable: false),
                    LunchOut = table.Column<DateTime>(nullable: false),
                    TiffinTime = table.Column<DateTime>(nullable: false),
                    TiffinIn = table.Column<DateTime>(nullable: false),
                    TiffinOut = table.Column<DateTime>(nullable: false),
                    RegHour = table.Column<DateTime>(nullable: false),
                    ShiftType = table.Column<string>(nullable: true),
                    ShiftCat = table.Column<string>(nullable: true),
                    IsInactive = table.Column<bool>(nullable: false),
                    TiffinTime1 = table.Column<DateTime>(nullable: true),
                    TiffinTimeIn1 = table.Column<DateTime>(nullable: true),
                    TiffinTime2 = table.Column<DateTime>(nullable: true),
                    TiffinTimeIn2 = table.Column<DateTime>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Shift", x => x.ShiftId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Unit",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(maxLength: 30, nullable: false),
                    UnitShortName = table.Column<string>(maxLength: 30, nullable: true),
                    UnitNameB = table.Column<string>(maxLength: 30, nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Unit", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Cat_PoliceStation",
                columns: table => new
                {
                    PStationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PStationName = table.Column<string>(maxLength: 30, nullable: false),
                    PStationNameB = table.Column<string>(maxLength: 30, nullable: true),
                    DistId = table.Column<int>(nullable: false),
                    Cat_DistrictDistId = table.Column<short>(nullable: true),
                    ComId = table.Column<string>(nullable: true),
                    PcName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DtInput = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_PoliceStation", x => x.PStationId);
                    table.ForeignKey(
                        name: "FK_Cat_PoliceStation_Cat_District_Cat_DistrictDistId",
                        column: x => x.Cat_DistrictDistId,
                        principalTable: "Cat_District",
                        principalColumn: "DistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoucherSubSections_SubSectionSubSectId",
                table: "VoucherSubSections",
                column: "SubSectionSubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Cat_SubSectionSubSectId",
                table: "Employee",
                column: "Cat_SubSectionSubSectId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Designation_GradeId",
                table: "Cat_Designation",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_PoliceStation_Cat_DistrictDistId",
                table: "Cat_PoliceStation",
                column: "Cat_DistrictDistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_Designation_Cat_Grade_GradeId",
                table: "Cat_Designation",
                column: "GradeId",
                principalTable: "Cat_Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_SubSection_Cat_SubSectionSubSectId",
                table: "Employee",
                column: "Cat_SubSectionSubSectId",
                principalTable: "Cat_SubSection",
                principalColumn: "SubSectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherSubSections_Cat_SubSection_SubSectionSubSectId",
                table: "VoucherSubSections",
                column: "SubSectionSubSectId",
                principalTable: "Cat_SubSection",
                principalColumn: "SubSectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_Designation_Cat_Grade_GradeId",
                table: "Cat_Designation");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_SubSection_Cat_SubSectionSubSectId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_VoucherSubSections_Cat_SubSection_SubSectionSubSectId",
                table: "VoucherSubSections");

            migrationBuilder.DropTable(
                name: "Cat_BloodGroup");

            migrationBuilder.DropTable(
                name: "Cat_Floor");

            migrationBuilder.DropTable(
                name: "Cat_Line");

            migrationBuilder.DropTable(
                name: "Cat_PoliceStation");

            migrationBuilder.DropTable(
                name: "Cat_Religion");

            migrationBuilder.DropTable(
                name: "Cat_Shift");

            migrationBuilder.DropTable(
                name: "Cat_Unit");

            migrationBuilder.DropTable(
                name: "Cat_District");

            migrationBuilder.DropIndex(
                name: "IX_VoucherSubSections_SubSectionSubSectId",
                table: "VoucherSubSections");

            migrationBuilder.DropIndex(
                name: "IX_Employee_Cat_SubSectionSubSectId",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cat_SubSection",
                table: "Cat_SubSection");

            migrationBuilder.DropIndex(
                name: "IX_Cat_Designation_GradeId",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "SubSectionSubSectId",
                table: "VoucherSubSections");

            migrationBuilder.DropColumn(
                name: "Cat_SubSectionSubSectId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SubSectId",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "SubSectName",
                table: "Cat_SubSection");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Cat_Section");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Cat_Section");

            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "Cat_Section");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Cat_Section");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Cat_Grade");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Cat_Grade");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Cat_Grade");

            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "Cat_Grade");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "Cat_Grade");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Cat_Grade");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cat_Grade");

            migrationBuilder.DropColumn(
                name: "AddByUserId",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "SlNo",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Cat_Designation");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Cat_Department");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Cat_Department");

            migrationBuilder.DropColumn(
                name: "DtInput",
                table: "Cat_Department");

            migrationBuilder.DropColumn(
                name: "UpdateByUserId",
                table: "Cat_Department");

            migrationBuilder.RenameColumn(
                name: "PcName",
                table: "Cat_Section",
                newName: "Pcname");

            migrationBuilder.RenameColumn(
                name: "PcName",
                table: "Cat_Designation",
                newName: "Pcname");

            migrationBuilder.RenameColumn(
                name: "PcName",
                table: "Cat_Department",
                newName: "Pcname");

            migrationBuilder.AddColumn<int>(
                name: "SubSectionId",
                table: "VoucherSubSections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cat_SubSectionSubSectionId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubSectionId",
                table: "Cat_SubSection",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Cat_SubSectionName",
                table: "Cat_SubSection",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "IsStrDpt",
                table: "Cat_SubSection",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Pcname",
                table: "Cat_SubSection",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SectName",
                table: "Cat_SubSection",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SrtName",
                table: "Cat_SubSection",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cat_SubSection",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Cat_Section",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Slno",
                table: "Cat_Section",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "SectNameB",
                table: "Cat_Section",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SectName",
                table: "Cat_Section",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<byte>(
                name: "ComId",
                table: "Cat_Section",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Cat_Section",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MinGS",
                table: "Cat_Grade",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GradeNameB",
                table: "Cat_Grade",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GradeName",
                table: "Cat_Grade",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "DesigNameB",
                table: "Cat_Designation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DesigName",
                table: "Cat_Designation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<int>(
                name: "ComId",
                table: "Cat_Designation",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dslno",
                table: "Cat_Designation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Cat_Designation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "MngSalary",
                table: "Cat_Designation",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "OffGrade",
                table: "Cat_Designation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ShiftAllow",
                table: "Cat_Designation",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Cat_Department",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeptName",
                table: "Cat_Department",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "DeptBangla",
                table: "Cat_Department",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComId",
                table: "Cat_Department",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Buid",
                table: "Cat_Department",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buname",
                table: "Cat_Department",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DptSrtName",
                table: "Cat_Department",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "IsStrDpt",
                table: "Cat_Department",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Cat_Department",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cat_SubSection",
                table: "Cat_SubSection",
                column: "SubSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherSubSections_SubSectionId",
                table: "VoucherSubSections",
                column: "SubSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Cat_SubSectionSubSectionId",
                table: "Employee",
                column: "Cat_SubSectionSubSectionId");

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
    }
}
