using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class nullCarrierMemeber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BufferDelChallan_BufferRepresentativeMember_RepresentativeMemberId",
                table: "BufferDelChallan");

            migrationBuilder.AlterColumn<int>(
                name: "RepresentativeMemberId",
                table: "BufferDelChallan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BufferDelChallan_BufferRepresentativeMember_RepresentativeMemberId",
                table: "BufferDelChallan",
                column: "RepresentativeMemberId",
                principalTable: "BufferRepresentativeMember",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BufferDelChallan_BufferRepresentativeMember_RepresentativeMemberId",
                table: "BufferDelChallan");

            migrationBuilder.AlterColumn<int>(
                name: "RepresentativeMemberId",
                table: "BufferDelChallan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BufferDelChallan_BufferRepresentativeMember_RepresentativeMemberId",
                table: "BufferDelChallan",
                column: "RepresentativeMemberId",
                principalTable: "BufferRepresentativeMember",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
