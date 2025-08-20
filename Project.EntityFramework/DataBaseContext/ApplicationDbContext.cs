using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnTime.Data.Entities;
using OnTime.Comman.Idenitity;
using StackExchange.Redis;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using OnTime.Comman.Enums;
using ProjectPulse.Data.Entities;
using OnTime.CrossCutting.Comman.Idenitity;

namespace OnTime.EntityFramework.DataBaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
       public DbSet<Organization> Organizations { get; set; }
       public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<DepartmentType> DepartmentTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);
            SeedCompanyTypes(modelBuilder);
            SeedDepartmentTypes(modelBuilder);
           // SeedDefaultUserAsync();
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
        };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

        private void SeedCompanyTypes(ModelBuilder modelBuilder)
        {
            var companyTypes = new List<CompanyType>
            {
                new CompanyType
                {
                    Id = 1,
                    Name = "Main Company",
                    IsDeleted = false,
                    CreationDate = DateTime.UtcNow,
                    // CreatedBy = ""
                },
                new CompanyType
                {
                    Id = 2,
                    Name = "Sub Company",
                    IsDeleted = false,
                    CreationDate = DateTime.UtcNow,
                    // CreatedBy = ""
                }
            };

            modelBuilder.Entity<CompanyType>().HasData(companyTypes);
        }

        private void SeedDepartmentTypes(ModelBuilder modelBuilder)
        {
            var departmentTypes = new List<DepartmentType>
            {
                new DepartmentType
                {
                    Id = 1,
                    Name = "Main Department",
                    IsDeleted = false,
                    CreationDate = DateTime.UtcNow,
                    // CreatedBy = ""
                },
                new DepartmentType
                {
                    Id = 2,
                    Name = "Sub Department",
                    IsDeleted = false,
                    CreationDate = DateTime.UtcNow,
                    // CreatedBy = ""
                }
            };

            modelBuilder.Entity<DepartmentType>().HasData(departmentTypes);
        }

        public async Task<bool> TableExistsAsync(string tableName)
        {
            var connection = Database.GetDbConnection();
            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
            }
            var tables = await connection.GetSchemaAsync("Tables");
            return tables.Rows
                .OfType<System.Data.DataRow>()
                .Any(row => row["TABLE_NAME"].ToString().ToLower() == tableName.ToLower());
        }



    }
}

