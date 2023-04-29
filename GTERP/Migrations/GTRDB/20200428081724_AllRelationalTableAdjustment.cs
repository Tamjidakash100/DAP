using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class AllRelationalTableAdjustment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPaymentSubs_Acc_ChartOfAccounts_AccId",
                table: "SalesPaymentSubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesTermsSubs",
                table: "SalesTermsSubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesPaymentSubs",
                table: "SalesPaymentSubs");

            migrationBuilder.AlterColumn<string>(
                name: "Terms",
                table: "SalesTermsSubs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SalesTermsSubs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccId",
                table: "SalesPaymentSubs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesTermsSubs",
                table: "SalesTermsSubs",
                columns: new[] { "SalesId", "Terms", "Description" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesPaymentSubs",
                table: "SalesPaymentSubs",
                columns: new[] { "SalesId", "PaymentTypeId", "AccId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPaymentSubs_Acc_ChartOfAccounts_AccId",
                table: "SalesPaymentSubs",
                column: "AccId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPaymentSubs_Acc_ChartOfAccounts_AccId",
                table: "SalesPaymentSubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesTermsSubs",
                table: "SalesTermsSubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesPaymentSubs",
                table: "SalesPaymentSubs");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SalesTermsSubs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Terms",
                table: "SalesTermsSubs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "AccId",
                table: "SalesPaymentSubs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesTermsSubs",
                table: "SalesTermsSubs",
                column: "SalesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesPaymentSubs",
                table: "SalesPaymentSubs",
                column: "SalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPaymentSubs_Acc_ChartOfAccounts_AccId",
                table: "SalesPaymentSubs",
                column: "AccId",
                principalTable: "Acc_ChartOfAccounts",
                principalColumn: "AccId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
