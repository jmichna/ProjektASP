using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublishingHouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    PublishingHouseName = table.Column<string>(type: "TEXT", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Region = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishingHouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "library",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Autor = table.Column<string>(type: "TEXT", nullable: false),
                    page_number = table.Column<int>(type: "INTEGER", nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", maxLength: 17, nullable: false),
                    date_of_release = table.Column<DateTime>(type: "TEXT", nullable: false),
                    publishing_house_id = table.Column<int>(type: "INTEGER", nullable: false),
                    rating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_library", x => x.Id);
                    table.ForeignKey(
                        name: "FK_library_PublishingHouse_publishing_house_id",
                        column: x => x.publishing_house_id,
                        principalTable: "PublishingHouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PublishingHouse",
                columns: new[] { "Id", "Address_City", "Address_PostalCode", "Address_Region", "Address_Street", "PublishingHouseName", "Region" },
                values: new object[,]
                {
                    { 1, "Gsbagga", "736252", "wygwizdowo", "tsdsv", "PenguinRandomHouse", "12343221224" },
                    { 2, "Oxford", "7326251", "fgegrbg", "qwweeefqw", "OxfordUniversityPress", "84730192837" }
                });

            migrationBuilder.InsertData(
                table: "PublishingHouse",
                columns: new[] { "Id", "PublishingHouseName", "Region" },
                values: new object[] { 3, "CambridgeUniversityPress", "912872162237" });

            migrationBuilder.InsertData(
                table: "library",
                columns: new[] { "Id", "Autor", "date_of_release", "ISBN", "page_number", "publishing_house_id", "rating", "Title" },
                values: new object[,]
                {
                    { 1, "Adam Abc", new DateTime(2000, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345678987654321", 69, 1, 1, "Title" },
                    { 2, "Dawid GBC", new DateTime(1999, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "98765432123456789", 213, 2, 3, "Titleeeeee" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_library_publishing_house_id",
                table: "library",
                column: "publishing_house_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "library");

            migrationBuilder.DropTable(
                name: "PublishingHouse");
        }
    }
}
