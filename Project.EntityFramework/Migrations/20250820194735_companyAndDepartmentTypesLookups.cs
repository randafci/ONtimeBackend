using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnTime.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class companyAndDepartmentTypesLookups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "945b3e8b-25db-4c50-9077-48dfb7b25c33");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "bf8d68fc-f62b-4ed4-8562-11b99be80d9e");

            migrationBuilder.RenameColumn(
                name: "DepartmentType",
                table: "Departments",
                newName: "DepartmentTypeId");

            migrationBuilder.AddColumn<long>(
                name: "DepartmentTypeId1",
                table: "Departments",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyTypeId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyTypeId1",
                table: "Companies",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompanyTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NameSE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NameSE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CompanyTypes",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "IsDeleted", "ModificationDate", "ModifiedBy", "Name", "NameSE" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2025, 8, 20, 19, 47, 34, 800, DateTimeKind.Utc).AddTicks(451), false, null, null, "Main Company", "" },
                    { 2L, null, new DateTime(2025, 8, 20, 19, 47, 34, 800, DateTimeKind.Utc).AddTicks(456), false, null, null, "Sub Company", "" }
                });

            migrationBuilder.InsertData(
                table: "DepartmentTypes",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "IsDeleted", "ModificationDate", "ModifiedBy", "Name", "NameSE" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2025, 8, 20, 19, 47, 34, 800, DateTimeKind.Utc).AddTicks(514), false, null, null, "Main Department", "" },
                    { 2L, null, new DateTime(2025, 8, 20, 19, 47, 34, 800, DateTimeKind.Utc).AddTicks(518), false, null, null, "Sub Department", "" }
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "87bb18fe-a0e3-47f0-aea7-bcc833e2ba05", null, "Admin", "ADMIN" },
                    { "dde66b11-494f-40ae-b26d-2f287c7dbd61", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentTypeId1",
                table: "Departments",
                column: "DepartmentTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyTypeId1",
                table: "Companies",
                column: "CompanyTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyTypes_CompanyTypeId1",
                table: "Companies",
                column: "CompanyTypeId1",
                principalTable: "CompanyTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_DepartmentTypes_DepartmentTypeId1",
                table: "Departments",
                column: "DepartmentTypeId1",
                principalTable: "DepartmentTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyTypes_CompanyTypeId1",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_DepartmentTypes_DepartmentTypeId1",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "CompanyTypes");

            migrationBuilder.DropTable(
                name: "DepartmentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentTypeId1",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CompanyTypeId1",
                table: "Companies");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "87bb18fe-a0e3-47f0-aea7-bcc833e2ba05");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "dde66b11-494f-40ae-b26d-2f287c7dbd61");

            migrationBuilder.DropColumn(
                name: "DepartmentTypeId1",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CompanyTypeId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyTypeId1",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "DepartmentTypeId",
                table: "Departments",
                newName: "DepartmentType");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "945b3e8b-25db-4c50-9077-48dfb7b25c33", null, "Admin", "ADMIN" },
                    { "bf8d68fc-f62b-4ed4-8562-11b99be80d9e", null, "User", "USER" }
                });
        }
    }
}
