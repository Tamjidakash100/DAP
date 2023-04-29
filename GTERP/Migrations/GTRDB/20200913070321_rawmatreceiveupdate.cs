using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class rawmatreceiveupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SulfuricReceive",
                table: "Production",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "SandReceive",
                table: "Production",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "AmmoniaReceive",
                table: "Production",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 300);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "SulfuricReceive",
                table: "Production",
                type: "real",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "SandReceive",
                table: "Production",
                type: "real",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "AmmoniaReceive",
                table: "Production",
                type: "real",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);
        }
    }
}
