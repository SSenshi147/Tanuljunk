using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dogs.Migrations
{
    /// <inheritdoc />
    public partial class knowncats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Key",
                keyValue: new Guid("97ef0ae2-5cad-47ab-b459-e834d5564e69"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Key",
                keyValue: new Guid("ce831456-b1ae-460a-beb8-5e8b95d72ba2"));

            migrationBuilder.CreateTable(
                name: "KnownCats",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "uuid", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownCats", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Key", "CanDoTricks", "Name" },
                values: new object[,]
                {
                    { new Guid("506bcdaa-6868-4eff-a54a-0877b74b095d"), false, "buta kutya" },
                    { new Guid("dc85ed44-3add-42b5-955b-41275ffcd51b"), true, "okos kutya" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KnownCats");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Key",
                keyValue: new Guid("506bcdaa-6868-4eff-a54a-0877b74b095d"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Key",
                keyValue: new Guid("dc85ed44-3add-42b5-955b-41275ffcd51b"));

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Key", "CanDoTricks", "Name" },
                values: new object[,]
                {
                    { new Guid("97ef0ae2-5cad-47ab-b459-e834d5564e69"), true, "okos kutya" },
                    { new Guid("ce831456-b1ae-460a-beb8-5e8b95d72ba2"), false, "buta kutya" }
                });
        }
    }
}
