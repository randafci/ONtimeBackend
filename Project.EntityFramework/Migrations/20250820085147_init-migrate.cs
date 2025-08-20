using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnTime.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class initmigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "dabe5740-9fb4-4840-a7f5-22644dffc1f3");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "dff0d403-ffcf-41b1-8903-f11ff14eb8e2");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1df5469d-8892-405b-b727-9e85dfd133fb", null, "Admin", "ADMIN" },
                    { "9899b328-640a-4fb9-9a76-d05bd5b9ecf3", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "1df5469d-8892-405b-b727-9e85dfd133fb");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9899b328-640a-4fb9-9a76-d05bd5b9ecf3");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dabe5740-9fb4-4840-a7f5-22644dffc1f3", null, "User", "USER" },
                    { "dff0d403-ffcf-41b1-8903-f11ff14eb8e2", null, "Admin", "ADMIN" }
                });
        }
    }
}
