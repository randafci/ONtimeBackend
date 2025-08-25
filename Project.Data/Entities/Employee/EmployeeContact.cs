using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnTime.CrossCutting.Comman;

namespace OnTime.Data.Entities.Employee
{
    public class EmployeeContact
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string? PersonalEmail { get; set; }

        [MaxLength(255)]
        public string? OfficialEmail { get; set; }

        [MaxLength(20)]
        public string? PersonalPhone { get; set; }

        [MaxLength(20)]
        public string? PersonalMobile { get; set; }

        [MaxLength(20)]
        public string? OfficialPhone { get; set; }

        [MaxLength(20)]
        public string? OfficialMobile { get; set; }

        [MaxLength(500)]
        public string? Address { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(100)]
        public string? State { get; set; }

        public int EmployeeId { get; set; }

        // Navigation property
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } = null!;
    }
}
