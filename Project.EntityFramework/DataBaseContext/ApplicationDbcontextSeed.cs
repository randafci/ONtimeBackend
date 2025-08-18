using Microsoft.AspNetCore.Identity;
using OnTime.Comman.Idenitity;
using OnTime.CrossCutting.Comman.Idenitity;
using OnTime.Data.Enums;
using OnTime.EntityFramework.Utiliies;
using OnTime.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.EntityFramework.DataBaseContext
{
    public abstract class ApplicationDbcontextSeed
    {
        public static async Task SeedDefaultUserAsync(
  
     ApplicationDbContext context,
     UserManager<ApplicationUser> userManager,
     RoleManager<ApplicationRole> roleManager)
        {
            ApplicationRole administratorRole = new()
            {
                IsHRRole = false,
                IsDefaultRole = false,
                Name = "Administrator",
            };
            var plainPermissions = PlainPermissionsGenerator.GetPlainPermissionsWithGroup();
            //var crudPermissions = await new CrudPermissionsGenerator(settings, context).GenerateAllPermissions();
            if (roleManager.Roles.All(item => item.Name != administratorRole.Name))
            {
                //    await roleManager.CreateAsync(administratorRole);
                //    var roleClaims = await roleManager.GetClaimsAsync(administratorRole);
                //    foreach (var claim in roleClaims)
                //    {
                //        await roleManager.RemoveClaimAsync(administratorRole, claim);
                //    }
                //    foreach (var crudModel in crudPermissions)
                //    {
                //        foreach (var crudPermission in crudModel.PermissionsList)
                //        {
                //            if (!string.IsNullOrWhiteSpace(crudPermission.DisplayValue))
                //            {
                //                await roleManager.AddClaimAsync(administratorRole, new Claim("Permissions", crudPermission.DisplayValue));
                //            }
                //        }
                //    }
                foreach (var plainModel in plainPermissions)
                {
                    foreach (var plainPermission in plainModel.PermissionsList)
                    {
                        if (plainPermission.DisplayValue != "BasedOnEntity")
                        {
                            await roleManager.AddClaimAsync(administratorRole, new Claim("Permissions", plainPermission.DisplayValue));
                        }
                    }
                }
            }
            var administrator = new ApplicationUser
            {
                IsLdapUser = false,
                EmailConfirmed = true,
                Email = "administrator@localhost",
                UserName = "administrator@localhost",
            };
            if (userManager.Users.All(item => item.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }
    }
}
