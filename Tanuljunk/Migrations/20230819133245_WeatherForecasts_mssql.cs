//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

//namespace Tanuljunk.Migrations
//{
//    /// <inheritdoc />
//    public partial class WeatherForecasts : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "WeatherForecasts",
//                columns: table => new
//                {
//                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    TemperatureC = table.Column<int>(type: "int", nullable: false),
//                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
//                    { new Guid("452288c4-a7c5-49f8-8068-5e7092339cff"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Local), "Meleg van", 32 },
//                    { new Guid("5e35f3cf-b27c-4a84-977c-6807af450939"), new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Local), "Hideg van", 3 }
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
