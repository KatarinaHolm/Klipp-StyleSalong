using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Klipp_StyleSalong.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Hairdresser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CustomerName", "Date", "Hairdresser", "PhoneNr", "Time" },
                values: new object[,]
                {
                    { 1, "Sofia Larsson", new DateOnly(2026, 2, 10), "Anna", "0701234567", new TimeOnly(9, 0, 0) },
                    { 2, "Johan Svensson", new DateOnly(2026, 2, 10), "Erik", "0739876543", new TimeOnly(10, 0, 0) },
                    { 3, "Elin Andersson", new DateOnly(2026, 2, 10), "Anna", "0725551234", new TimeOnly(11, 0, 0) },
                    { 4, "Mikael Johansson", new DateOnly(2026, 2, 11), "Erik", "0761122334", new TimeOnly(9, 30, 0) },
                    { 5, "Lisa Karlsson", new DateOnly(2026, 2, 11), "Anna", "0709988776", new TimeOnly(10, 30, 0) },
                    { 6, "Fredrik Nilsson", new DateOnly(2026, 2, 12), "Erik", "0736655443", new TimeOnly(13, 0, 0) },
                    { 7, "Emma Olsson", new DateOnly(2026, 2, 12), "Anna", "0723344556", new TimeOnly(14, 0, 0) },
                    { 8, "Patrik Lindberg", new DateOnly(2026, 2, 13), "Erik", "0707766554", new TimeOnly(10, 0, 0) },
                    { 9, "Johanna Berg", new DateOnly(2026, 2, 13), "Anna", "0732233445", new TimeOnly(11, 0, 0) },
                    { 10, "David Svensson", new DateOnly(2026, 2, 14), "Erik", "0728899001", new TimeOnly(12, 0, 0) },
                    { 11, "Hanna Svensson", new DateOnly(2026, 2, 15), "Erik", "0768990565", new TimeOnly(13, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
