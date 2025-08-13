using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnTime.Data.Entities;
using OnTime.Comman.Idenitity;
using StackExchange.Redis;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using OnTime.Comman.Enums;

namespace OnTime.EntityFramework.DataBaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }


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

        //public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        //{

        //    var adminEmail = "admin@project.com";
        //    var defaultPassword = "12345";
        //    var userName = "superadmin";
        //    if (!userManager.Users.Any(u => u.UserName == userName))
        //    {
        //        try
        //        {
        //            var adminUser = new ApplicationUser { PhoneNumber="01011111110",UserType=UserType.Admin,FullName=userName,UserName = userName, Email = adminEmail, EmailConfirmed = true };
        //            var result = await userManager.CreateAsync(adminUser, defaultPassword);
        //            if (result.Succeeded)
        //            {

        //                context.Users.Update(adminUser);
        //                await context.SaveChangesAsync();

        //                await userManager.AddToRoleAsync(adminUser, "Admin");

        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }
        //}


    }
}

