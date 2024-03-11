using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManagePeople.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Seeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("1818333e-e018-4937-820b-837ab193a5ac"), "Samuel", "Donet" },
                    { new Guid("53194997-f61f-4f35-8e89-57a5b4935313"), "Josephine", "Smith" },
                    { new Guid("84394d0f-bd4a-4c72-ae63-54b737d752c9"), "Daniel", "Williams" },
                    { new Guid("e1febb04-11c6-466b-8ff8-6d224dc512a2"), "Charles", "Wilson" },
                    { new Guid("e6e5ca24-4885-4c0c-937f-33ca348ab87d"), "Michael", "Johnson" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("1818333e-e018-4937-820b-837ab193a5ac"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("53194997-f61f-4f35-8e89-57a5b4935313"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("84394d0f-bd4a-4c72-ae63-54b737d752c9"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("e1febb04-11c6-466b-8ff8-6d224dc512a2"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("e6e5ca24-4885-4c0c-937f-33ca348ab87d"));
        }
    }
}
