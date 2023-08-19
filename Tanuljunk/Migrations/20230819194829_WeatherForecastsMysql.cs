using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tanuljunk.Migrations
{
    /// <inheritdoc />
    public partial class WeatherForecastsMysql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "char(36)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TemperatureC = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Key);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Key", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("1da85155-dd55-410d-b036-295f27320315"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddTicks(1234), "Meleg van", 32 },
                    { new Guid("f2d23a88-5e5a-4144-9ffb-7ad7a10f1860"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddTicks(5678), "Hideg van", 3 }
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
