//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

//namespace Tanuljunk.Migrations
//{
//    /// <inheritdoc />
//    public partial class WeatherForecastsPostgres : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "WeatherForecasts",
//                columns: table => new
//                {
//                    Key = table.Column<Guid>(type: "uuid", nullable: false),
//                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
//                    TemperatureC = table.Column<int>(type: "integer", nullable: false),
//                    Summary = table.Column<string>(type: "text", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_WeatherForecasts", x => x.Key);
//                });

//            migrationBuilder.InsertData(
//                table: "WeatherForecasts",
//                columns: new[] { "Key", "Date", "Summary", "TemperatureC" },
//                values: new object[,]
//                {
//                    { new Guid("0b9dec5b-e60d-4737-93b6-e5540d6899ec"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddTicks(1234), "Meleg van", 32 },
//                    { new Guid("d70cddcb-c587-43ce-aaba-cd57aa894a17"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddTicks(5678), "Hideg van", 3 }
//                });
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "WeatherForecasts");
//        }
//    }
//}
