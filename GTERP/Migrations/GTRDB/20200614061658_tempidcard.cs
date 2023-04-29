using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class tempidcard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Cat_District_Cat_DistrictDistId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Cat_PoliceStation_Cat_PoliceStationPStationId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_Cat_DistrictDistId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_Cat_PoliceStationPStationId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Cat_DistrictDistId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Cat_PoliceStationPStationId",
                table: "Booking");

            migrationBuilder.AlterColumn<string>(
                name: "RefCode",
                table: "HR_Emp_Document",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HR_Emp_TempIdCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(nullable: false),
                    ComId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Emp_TempIdCard", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_DistId",
                table: "Booking",
                column: "DistId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PStationId",
                table: "Booking",
                column: "PStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Cat_District_DistId",
                table: "Booking",
                column: "DistId",
                principalTable: "Cat_District",
                principalColumn: "DistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Cat_PoliceStation_PStationId",
                table: "Booking",
                column: "PStationId",
                principalTable: "Cat_PoliceStation",
                principalColumn: "PStationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Cat_District_DistId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Cat_PoliceStation_PStationId",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "HR_Emp_TempIdCard");

            migrationBuilder.DropIndex(
                name: "IX_Booking_DistId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_PStationId",
                table: "Booking");

            migrationBuilder.AlterColumn<string>(
                name: "RefCode",
                table: "HR_Emp_Document",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "Cat_DistrictDistId",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cat_PoliceStationPStationId",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Cat_DistrictDistId",
                table: "Booking",
                column: "Cat_DistrictDistId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Cat_PoliceStationPStationId",
                table: "Booking",
                column: "Cat_PoliceStationPStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Cat_District_Cat_DistrictDistId",
                table: "Booking",
                column: "Cat_DistrictDistId",
                principalTable: "Cat_District",
                principalColumn: "DistId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Cat_PoliceStation_Cat_PoliceStationPStationId",
                table: "Booking",
                column: "Cat_PoliceStationPStationId",
                principalTable: "Cat_PoliceStation",
                principalColumn: "PStationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
