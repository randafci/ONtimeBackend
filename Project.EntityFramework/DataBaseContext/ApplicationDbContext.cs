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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);
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

