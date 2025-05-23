using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OracleJwtApiFull.Migrations
{
    /// <inheritdoc />
    public partial class AddAirportModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AIRPLANES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MODEL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ECONOMY_CAPACITY = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BUSINESS_CAPACITY = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FIRST_CLASS_CAPACITY = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIRPLANES", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AIRPLANES");
        }
    }
}
