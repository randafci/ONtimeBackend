using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnTime.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class employeeNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeDocuments_EmployeeId",
                table: "EmployeeDocuments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeContacts_EmployeeId",
                table: "EmployeeContacts");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "74784050-22e2-4721-9980-7f9578d0fd91");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "eb8f68f2-60fd-4827-b0a8-11a613bc842e");

            migrationBuilder.UpdateData(
                table: "CompanyTypeLookup",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 8, 23, 22, 33, 12, 777, DateTimeKind.Utc).AddTicks(2607));

            migrationBuilder.UpdateData(
                table: "CompanyTypeLookup",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 8, 23, 22, 33, 12, 777, DateTimeKind.Utc).AddTicks(2615));

            migrationBuilder.UpdateData(
                table: "DepartmentTypeLookup",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 8, 23, 22, 33, 12, 777, DateTimeKind.Utc).AddTicks(2672));

            migrationBuilder.UpdateData(
                table: "DepartmentTypeLookup",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 8, 23, 22, 33, 12, 777, DateTimeKind.Utc).AddTicks(2676));

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b4b5b588-6c43-443c-bb82-92a88a3276c0", null, "Admin", "ADMIN" },
                    { "b52d32fe-1b79-49f8-a667-024d80a6a0ab", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocuments_EmployeeId",
                table: "EmployeeDocuments",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContacts_EmployeeId",
                table: "EmployeeContacts",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeDocuments_EmployeeId",
                table: "EmployeeDocuments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeContacts_EmployeeId",
                table: "EmployeeContacts");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "b4b5b588-6c43-443c-bb82-92a88a3276c0");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "b52d32fe-1b79-49f8-a667-024d80a6a0ab");

            migrationBuilder.UpdateData(
                table: "CompanyTypeLookup",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 8, 21, 22, 1, 56, 896, DateTimeKind.Utc).AddTicks(741));

            migrationBuilder.UpdateData(
                table: "CompanyTypeLookup",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 8, 21, 22, 1, 56, 896, DateTimeKind.Utc).AddTicks(745));

            migrationBuilder.UpdateData(
                table: "DepartmentTypeLookup",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 8, 21, 22, 1, 56, 896, DateTimeKind.Utc).AddTicks(839));

            migrationBuilder.UpdateData(
                table: "DepartmentTypeLookup",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 8, 21, 22, 1, 56, 896, DateTimeKind.Utc).AddTicks(843));

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "74784050-22e2-4721-9980-7f9578d0fd91", null, "User", "USER" },
                    { "eb8f68f2-60fd-4827-b0a8-11a613bc842e", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocuments_EmployeeId",
                table: "EmployeeDocuments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContacts_EmployeeId",
                table: "EmployeeContacts",
                column: "EmployeeId");
        }
    }
}
