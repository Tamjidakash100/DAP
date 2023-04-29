using Microsoft.EntityFrameworkCore.Migrations;

namespace GTERP.Migrations.GTRDB
{
    public partial class EmployeeTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_SubSection_Cat_SubSectionSubSectId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_Cat_SubSectionSubSectId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Cat_SubSectionSubSectId",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "LinkUserId",
                table: "Employee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SubSectId",
                table: "Employee",
                column: "SubSectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_SubSection_SubSectId",
                table: "Employee",
                column: "SubSectId",
                principalTable: "Cat_SubSection",
                principalColumn: "SubSectId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Cat_SubSection_SubSectId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_SubSectId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LinkUserId",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "Cat_SubSectionSubSectId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Cat_SubSectionSubSectId",
                table: "Employee",
                column: "Cat_SubSectionSubSectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Cat_SubSection_Cat_SubSectionSubSectId",
                table: "Employee",
                column: "Cat_SubSectionSubSectId",
                principalTable: "Cat_SubSection",
                principalColumn: "SubSectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
