using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnTime.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class employeesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employee_EmployeeId1",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "170bbd3b-fc58-4f4b-adec-88f7bc9be1b4");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "3e1b5697-2913-46e0-96e9-aa8d27d36d62");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EmployeeContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OfficialEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PersonalPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PersonalMobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OfficialPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OfficialMobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeContacts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassportNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PassportExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VisaNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VisaExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDocuments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_EmployeeContacts_EmployeeId",
                table: "EmployeeContacts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocuments_EmployeeId",
                table: "EmployeeDocuments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employees_EmployeeId1",
                table: "AspNetUsers",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employees_EmployeeId1",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EmployeeContacts");

            migrationBuilder.DropTable(
                name: "EmployeeDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "74784050-22e2-4721-9980-7f9578d0fd91");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "eb8f68f2-60fd-4827-b0a8-11a613bc842e");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "CompanyTypeLookup",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 8, 21, 20, 31, 19, 305, DateTimeKind.Utc).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "CompanyTypeLookup",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 8, 21, 20, 31, 19, 305, DateTimeKind.Utc).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "DepartmentTypeLookup",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 8, 21, 20, 31, 19, 305, DateTimeKind.Utc).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "DepartmentTypeLookup",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 8, 21, 20, 31, 19, 305, DateTimeKind.Utc).AddTicks(9412));

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "170bbd3b-fc58-4f4b-adec-88f7bc9be1b4", null, "Admin", "ADMIN" },
                    { "3e1b5697-2913-46e0-96e9-aa8d27d36d62", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employee_EmployeeId1",
                table: "AspNetUsers",
                column: "EmployeeId1",
                principalTable: "Employee",
                principalColumn: "Id");
        }
    }
}
