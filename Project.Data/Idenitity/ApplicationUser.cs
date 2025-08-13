
using Microsoft.AspNetCore.Identity;
using OnTime.Comman.Enums;
using OnTime.Data.Entities.Employee;
using System.ComponentModel.DataAnnotations;

namespace OnTime.Comman.Idenitity
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsLdapUser { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryDate { get; set; }
        public string ExtraEmployeesView { get; set; } = string.Empty;

        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
