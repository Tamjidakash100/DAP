using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class vouchernotypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companys_VoucherNoCreatedType_VoucherNoCreatedTypeId",
                table: "Companys");

            migrationBuilder.DropTable(
                name: "VoucherNoCreatedType");

            migrationBuilder.DropIndex(
                name: "IX_Companys_VoucherNoCreatedTypeId",
                table: "Companys");

            migrationBuilder.AddColumn<int>(
                name: "vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId",
                table: "Companys",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Acc_VoucherNoCreatedTypes",
                columns: table => new
                {
                    VoucherNoCreatedTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherNoCreatedTypeCode = table.Column<string>(nullable: false),
                    VoucherNoCreatedTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_VoucherNoCreatedTypes", x => x.VoucherNoCreatedTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companys_vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId",
                table: "Companys",
                column: "vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companys_Acc_VoucherNoCreatedTypes_vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId",
                table: "Companys",
                column: "vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId",
                principalTable: "Acc_VoucherNoCreatedTypes",
                principalColumn: "VoucherNoCreatedTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companys_Acc_VoucherNoCreatedTypes_vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId",
                table: "Companys");

            migrationBuilder.DropTable(
                name: "Acc_VoucherNoCreatedTypes");

            migrationBuilder.DropIndex(
                name: "IX_Companys_vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "vAcc_VoucherNoCreatedTypesVoucherNoCreatedTypeId",
                table: "Companys");

            migrationBuilder.CreateTable(
                name: "VoucherNoCreatedType",
                columns: table => new
                {
                    VoucherNoCreatedTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherNoCreatedTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoucherNoCreatedTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherNoCreatedType", x => x.VoucherNoCreatedTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companys_VoucherNoCreatedTypeId",
                table: "Companys",
                column: "VoucherNoCreatedTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companys_VoucherNoCreatedType_VoucherNoCreatedTypeId",
                table: "Companys",
                column: "VoucherNoCreatedTypeId",
                principalTable: "VoucherNoCreatedType",
                principalColumn: "VoucherNoCreatedTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
