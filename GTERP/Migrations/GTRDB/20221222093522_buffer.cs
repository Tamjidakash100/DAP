using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTERP.Migrations.GTRDB
{
    public partial class buffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuferRepresentative",
                columns: table => new
                {
                    BufferRepresentativeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepresentativeCode = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    RepresentativeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RepresentativeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresentativeMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    userid = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuferRepresentative", x => x.BufferRepresentativeId);
                });

            migrationBuilder.CreateTable(
                name: "BufferGatePass",
                columns: table => new
                {
                    BufferGatePassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GatePassNo = table.Column<int>(type: "int", nullable: false),
                    GatePassFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GatePassDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TruckNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    FiscalMonthId = table.Column<int>(type: "int", nullable: false),
                    BufferId = table.Column<int>(type: "int", nullable: true),
                    TotalQty = table.Column<float>(type: "real", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BufferGatePass", x => x.BufferGatePassId);
                });

            migrationBuilder.CreateTable(
                name: "Buffers",
                columns: table => new
                {
                    BufferListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    BufferCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BufferName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BufferNameBangla = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buffers", x => x.BufferListId);
                });

            migrationBuilder.CreateTable(
                name: "BufferDisticts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BufferListId = table.Column<int>(type: "int", nullable: false),
                    DistId = table.Column<int>(type: "int", nullable: false),
                    Cat_DistrictDistId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BufferDisticts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BufferDisticts_Buffers_BufferListId",
                        column: x => x.BufferListId,
                        principalTable: "Buffers",
                        principalColumn: "BufferListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BufferDisticts_Cat_District_Cat_DistrictDistId",
                        column: x => x.Cat_DistrictDistId,
                        principalTable: "Cat_District",
                        principalColumn: "DistId");
                });

            migrationBuilder.CreateTable(
                name: "BuffertWiseBookings",
                columns: table => new
                {
                    BufferBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    FiscalMonthId = table.Column<int>(type: "int", nullable: false),
                    BufferID = table.Column<int>(type: "int", nullable: false),
                    DtInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qty = table.Column<float>(type: "real", nullable: false),
                    AllotmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuffertWiseBookings", x => x.BufferBookingId);
                    table.ForeignKey(
                        name: "FK_BuffertWiseBookings_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuffertWiseBookings_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuffertWiseBookings_Buffers_BufferID",
                        column: x => x.BufferID,
                        principalTable: "Buffers",
                        principalColumn: "BufferListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepresentativeBuffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BufferListId = table.Column<int>(type: "int", nullable: false),
                    BufferRepresentativeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepresentativeBuffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepresentativeBuffers_BuferRepresentative_BufferRepresentativeId",
                        column: x => x.BufferRepresentativeId,
                        principalTable: "BuferRepresentative",
                        principalColumn: "BufferRepresentativeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepresentativeBuffers_Buffers_BufferListId",
                        column: x => x.BufferListId,
                        principalTable: "Buffers",
                        principalColumn: "BufferListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepresentativeBooking",
                columns: table => new
                {
                    RepresentativeBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    FiscalMonthId = table.Column<int>(type: "int", nullable: false),
                    BufferRepresentativeId = table.Column<int>(type: "int", nullable: false),
                    BufferListId = table.Column<int>(type: "int", nullable: false),
                    AllotmentQty = table.Column<float>(type: "real", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BufferBookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepresentativeBooking", x => x.RepresentativeBookingId);
                    table.ForeignKey(
                        name: "FK_RepresentativeBooking_Acc_FiscalMonths_FiscalMonthId",
                        column: x => x.FiscalMonthId,
                        principalTable: "Acc_FiscalMonths",
                        principalColumn: "FiscalMonthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepresentativeBooking_Acc_FiscalYears_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "Acc_FiscalYears",
                        principalColumn: "FiscalYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepresentativeBooking_BuferRepresentative_BufferRepresentativeId",
                        column: x => x.BufferRepresentativeId,
                        principalTable: "BuferRepresentative",
                        principalColumn: "BufferRepresentativeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepresentativeBooking_Buffers_BufferListId",
                        column: x => x.BufferListId,
                        principalTable: "Buffers",
                        principalColumn: "BufferListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepresentativeBooking_BuffertWiseBookings_BufferBookingId",
                        column: x => x.BufferBookingId,
                        principalTable: "BuffertWiseBookings",
                        principalColumn: "BufferBookingId");
                });

            migrationBuilder.CreateTable(
                name: "BufferDelOrder",
                columns: table => new
                {
                    BufferDelOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DONo = table.Column<int>(type: "int", nullable: false),
                    DODate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepresentativeBookingId = table.Column<int>(type: "int", nullable: false),
                    BufferRepresentativeId = table.Column<int>(type: "int", nullable: true),
                    PayInSlipNo = table.Column<int>(type: "int", nullable: false),
                    PayInSlipDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qty = table.Column<float>(type: "real", nullable: false),
                    RemainingQty = table.Column<float>(type: "real", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtyInWordsEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtyInWordsBng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPriceInWordsEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPriceInWordsBng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    PcName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BufferDelOrder", x => x.BufferDelOrderId);
                    table.ForeignKey(
                        name: "FK_BufferDelOrder_BuferRepresentative_BufferRepresentativeId",
                        column: x => x.BufferRepresentativeId,
                        principalTable: "BuferRepresentative",
                        principalColumn: "BufferRepresentativeId");
                    table.ForeignKey(
                        name: "FK_BufferDelOrder_RepresentativeBooking_RepresentativeBookingId",
                        column: x => x.RepresentativeBookingId,
                        principalTable: "RepresentativeBooking",
                        principalColumn: "RepresentativeBookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BufferDelChallan",
                columns: table => new
                {
                    BufferDelChallanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallanNo = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryQty = table.Column<float>(type: "real", nullable: false),
                    BufferDelOrderId = table.Column<int>(type: "int", nullable: false),
                    ComId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateByUserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BufferDelChallan", x => x.BufferDelChallanId);
                    table.ForeignKey(
                        name: "FK_BufferDelChallan_BufferDelOrder_BufferDelOrderId",
                        column: x => x.BufferDelOrderId,
                        principalTable: "BufferDelOrder",
                        principalColumn: "BufferDelOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BufferGatePassSub",
                columns: table => new
                {
                    BufferGatePassSubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BufferGatePassId = table.Column<int>(type: "int", nullable: false),
                    BufferDelChallanId = table.Column<int>(type: "int", nullable: false),
                    TruckLoadQty = table.Column<float>(type: "real", nullable: false),
                    BalanceQty = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BufferGatePassSub", x => x.BufferGatePassSubId);
                    table.ForeignKey(
                        name: "FK_BufferGatePassSub_BufferDelChallan_BufferDelChallanId",
                        column: x => x.BufferDelChallanId,
                        principalTable: "BufferDelChallan",
                        principalColumn: "BufferDelChallanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BufferGatePassSub_BufferGatePass_BufferGatePassId",
                        column: x => x.BufferGatePassId,
                        principalTable: "BufferGatePass",
                        principalColumn: "BufferGatePassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BufferDelChallan_BufferDelOrderId",
                table: "BufferDelChallan",
                column: "BufferDelOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BufferDelOrder_BufferRepresentativeId",
                table: "BufferDelOrder",
                column: "BufferRepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_BufferDelOrder_RepresentativeBookingId",
                table: "BufferDelOrder",
                column: "RepresentativeBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BufferDisticts_BufferListId",
                table: "BufferDisticts",
                column: "BufferListId");

            migrationBuilder.CreateIndex(
                name: "IX_BufferDisticts_Cat_DistrictDistId",
                table: "BufferDisticts",
                column: "Cat_DistrictDistId");

            migrationBuilder.CreateIndex(
                name: "IX_BufferGatePassSub_BufferDelChallanId",
                table: "BufferGatePassSub",
                column: "BufferDelChallanId");

            migrationBuilder.CreateIndex(
                name: "IX_BufferGatePassSub_BufferGatePassId",
                table: "BufferGatePassSub",
                column: "BufferGatePassId");

            migrationBuilder.CreateIndex(
                name: "IX_BuffertWiseBookings_BufferID",
                table: "BuffertWiseBookings",
                column: "BufferID");

            migrationBuilder.CreateIndex(
                name: "IX_BuffertWiseBookings_FiscalMonthId",
                table: "BuffertWiseBookings",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_BuffertWiseBookings_FiscalYearId",
                table: "BuffertWiseBookings",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativeBooking_BufferBookingId",
                table: "RepresentativeBooking",
                column: "BufferBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativeBooking_BufferListId",
                table: "RepresentativeBooking",
                column: "BufferListId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativeBooking_BufferRepresentativeId",
                table: "RepresentativeBooking",
                column: "BufferRepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativeBooking_FiscalMonthId",
                table: "RepresentativeBooking",
                column: "FiscalMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativeBooking_FiscalYearId",
                table: "RepresentativeBooking",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativeBuffers_BufferListId",
                table: "RepresentativeBuffers",
                column: "BufferListId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativeBuffers_BufferRepresentativeId",
                table: "RepresentativeBuffers",
                column: "BufferRepresentativeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BufferDisticts");

            migrationBuilder.DropTable(
                name: "BufferGatePassSub");

            migrationBuilder.DropTable(
                name: "RepresentativeBuffers");

            migrationBuilder.DropTable(
                name: "BufferDelChallan");

            migrationBuilder.DropTable(
                name: "BufferGatePass");

            migrationBuilder.DropTable(
                name: "BufferDelOrder");

            migrationBuilder.DropTable(
                name: "RepresentativeBooking");

            migrationBuilder.DropTable(
                name: "BuferRepresentative");

            migrationBuilder.DropTable(
                name: "BuffertWiseBookings");

            migrationBuilder.DropTable(
                name: "Buffers");
        }
    }
}
