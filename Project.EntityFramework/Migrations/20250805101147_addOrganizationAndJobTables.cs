using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnTime.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class addOrganizationAndJobTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31a5aea3-c258-4fa4-87a9-d44f631b6520");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a497a272-564a-4e67-ac64-1073cdedd889");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c504b5a-029a-45ad-a7ca-ba5631ce791a", null, "User", "USER" },
                    { "a47550d4-a0c3-41be-85b6-733a2cf1e6e1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c504b5a-029a-45ad-a7ca-ba5631ce791a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a47550d4-a0c3-41be-85b6-733a2cf1e6e1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31a5aea3-c258-4fa4-87a9-d44f631b6520", null, "User", "USER" },
                    { "a497a272-564a-4e67-ac64-1073cdedd889", null, "Admin", "ADMIN" }
                });
        }
    }
}
