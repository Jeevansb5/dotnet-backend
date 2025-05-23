using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleJwtApiFull.Migrations
{
    /// <inheritdoc />
    public partial class AddFlightAndAirportTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED_AT",
                table: "AIRPLANES",
                type: "TIMESTAMP",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP");

            migrationBuilder.CreateTable(
                name: "AIRPORTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    CODE = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    CITY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    COUNTRY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIRPORTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FLIGHTS",
                columns: table => new
                {
                    FLIGHT_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FLIGHT_NUMBER = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    AIRPLANE_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ORIGIN_AIRPORT_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DESTINATION_AIRPORT_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DEPARTURE_TIME = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    ARRIVAL_TIME = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    DURATION = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    AVAILABLE_ECONOMY_SEATS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AVAILABLE_BUSINESS_SEATS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AVAILABLE_FIRST_CLASS_SEATS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLIGHTS", x => x.FLIGHT_ID);
                    table.ForeignKey(
                        name: "FK_FLIGHTS_AIRPLANES_AIRPLANE_ID",
                        column: x => x.AIRPLANE_ID,
                        principalTable: "AIRPLANES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FLIGHTS_AIRPORTS_DESTINATION_AIRPORT_ID",
                        column: x => x.DESTINATION_AIRPORT_ID,
                        principalTable: "AIRPORTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FLIGHTS_AIRPORTS_ORIGIN_AIRPORT_ID",
                        column: x => x.ORIGIN_AIRPORT_ID,
                        principalTable: "AIRPORTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FLIGHTS_AIRPLANE_ID",
                table: "FLIGHTS",
                column: "AIRPLANE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLIGHTS_DESTINATION_AIRPORT_ID",
                table: "FLIGHTS",
                column: "DESTINATION_AIRPORT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLIGHTS_ORIGIN_AIRPORT_ID",
                table: "FLIGHTS",
                column: "ORIGIN_AIRPORT_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FLIGHTS");

            migrationBuilder.DropTable(
                name: "AIRPORTS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED_AT",
                table: "AIRPLANES",
                type: "TIMESTAMP",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP",
                oldNullable: true);
        }
    }
}
