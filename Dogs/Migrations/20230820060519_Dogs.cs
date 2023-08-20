using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dogs.Migrations
{
    /// <inheritdoc />
    public partial class Dogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CanDoTricks = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Key", "CanDoTricks", "Name" },
                values: new object[,]
                {
                    { new Guid("97ef0ae2-5cad-47ab-b459-e834d5564e69"), true, "okos kutya" },
                    { new Guid("ce831456-b1ae-460a-beb8-5e8b95d72ba2"), false, "buta kutya" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");
        }
    }
}
