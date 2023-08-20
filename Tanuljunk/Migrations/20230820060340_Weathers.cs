using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tanuljunk.Migrations
{
    /// <inheritdoc />
    public partial class Weathers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemperatureC = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Key", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("311f3e98-f8a5-4675-9039-a7f76f369fb6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddTicks(5678), "Hideg van", 3 },
                    { new Guid("9347081e-416a-4267-a1f3-9a54bfd8c557"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddTicks(1234), "Meleg van", 32 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");
        }
    }
}
