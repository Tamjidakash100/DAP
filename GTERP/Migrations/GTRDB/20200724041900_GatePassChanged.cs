using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class GatePassChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PoliceStationId",
                table: "GatePass",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "GatePass",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverAddress",
                table: "GatePass",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverMobile",
                table: "GatePass",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "GatePass",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverAddress",
                table: "GatePass");

            migrationBuilder.DropColumn(
                name: "ReceiverMobile",
                table: "GatePass");

            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "GatePass");

            migrationBuilder.AlterColumn<int>(
                name: "PoliceStationId",
                table: "GatePass",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "GatePass",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
