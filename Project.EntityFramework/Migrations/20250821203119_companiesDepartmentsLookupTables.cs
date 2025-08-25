using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnTime.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class companiesDepartmentsLookupTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "2f623643-f692-4501-ab6b-04d43517a329");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "aca46ca4-f7d1-47a2-9c1b-21cdfe30f181");

            migrationBuilder.RenameColumn(
                name: "DepartmentType",
                table: "Departments",
                newName: "DepartmentTypeLookupId");

            migrationBuilder.AddColumn<int>(
                name: "CompanyTypeLookupId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompanyTypeLookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_CompanyTypeLookup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentTypeLookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_DepartmentTypeLookup", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CompanyTypeLookup",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "IsDeleted", "ModificationDate", "ModifiedBy", "Name", "NameSE" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 8, 21, 20, 31, 19, 305, DateTimeKind.Utc).AddTicks(9348), false, null, null, "Main Company", "" },
                    { 2, null, new DateTime(2025, 8, 21, 20, 31, 19, 305, DateTimeKind.Utc).AddTicks(9353), false, null, null, "Sub Company", "" }
                });

            migrationBuilder.InsertData(
                table: "DepartmentTypeLookup",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "IsDeleted", "ModificationDate", "ModifiedBy", "Name", "NameSE" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 8, 21, 20, 31, 19, 305, DateTimeKind.Utc).AddTicks(9408), false, null, null, "Main Department", "" },
                    { 2, null, new DateTime(2025, 8, 21, 20, 31, 19, 305, DateTimeKind.Utc).AddTicks(9412), false, null, null, "Sub Department", "" }
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "170bbd3b-fc58-4f4b-adec-88f7bc9be1b4", null, "Admin", "ADMIN" },
                    { "3e1b5697-2913-46e0-96e9-aa8d27d36d62", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentTypeLookupId",
                table: "Departments",
                column: "DepartmentTypeLookupId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyTypeLookupId",
                table: "Companies",
                column: "CompanyTypeLookupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyTypeLookup_CompanyTypeLookupId",
                table: "Companies",
                column: "CompanyTypeLookupId",
                principalTable: "CompanyTypeLookup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_DepartmentTypeLookup_DepartmentTypeLookupId",
                table: "Departments",
                column: "DepartmentTypeLookupId",
                principalTable: "DepartmentTypeLookup",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyTypeLookup_CompanyTypeLookupId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_DepartmentTypeLookup_DepartmentTypeLookupId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "CompanyTypeLookup");

            migrationBuilder.DropTable(
                name: "DepartmentTypeLookup");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentTypeLookupId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CompanyTypeLookupId",
                table: "Companies");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "170bbd3b-fc58-4f4b-adec-88f7bc9be1b4");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "3e1b5697-2913-46e0-96e9-aa8d27d36d62");

            migrationBuilder.DropColumn(
                name: "CompanyTypeLookupId",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "DepartmentTypeLookupId",
                table: "Departments",
                newName: "DepartmentType");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f623643-f692-4501-ab6b-04d43517a329", null, "Admin", "ADMIN" },
                    { "aca46ca4-f7d1-47a2-9c1b-21cdfe30f181", null, "User", "USER" }
                });
        }
    }
}
