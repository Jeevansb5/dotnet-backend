using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleJwtApiFull.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingAndPassengerTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BOOKINGS",
                columns: table => new
                {
                    BOOKING_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USER_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FLIGHT_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NUMBER_OF_SEATS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TOTAL_PRICE = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    SEAT_CLASS = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    BOOKING_DATE = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    CANCELLED_AT = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOKINGS", x => x.BOOKING_ID);
                    table.ForeignKey(
                        name: "FK_BOOKINGS_FLIGHTS_FLIGHT_ID",
                        column: x => x.FLIGHT_ID,
                        principalTable: "FLIGHTS",
                        principalColumn: "FLIGHT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOOKINGS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PASSENGERS",
                columns: table => new
                {
                    PASSENGER_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    BOOKING_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FULL_NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    GENDER = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    DATE_OF_BIRTH = table.Column<DateTime>(type: "DATE", nullable: false),
                    PASSPORT_NUMBER = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PASSENGERS", x => x.PASSENGER_ID);
                    table.ForeignKey(
                        name: "FK_PASSENGERS_BOOKINGS_BOOKING_ID",
                        column: x => x.BOOKING_ID,
                        principalTable: "BOOKINGS",
                        principalColumn: "BOOKING_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOOKINGS_FLIGHT_ID",
                table: "BOOKINGS",
                column: "FLIGHT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BOOKINGS_USER_ID",
                table: "BOOKINGS",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PASSENGERS_BOOKING_ID",
                table: "PASSENGERS",
                column: "BOOKING_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PASSENGERS");

            migrationBuilder.DropTable(
                name: "BOOKINGS");
        }
    }
}
