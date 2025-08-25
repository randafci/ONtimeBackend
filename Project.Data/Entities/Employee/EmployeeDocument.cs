using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnTime.CrossCutting.Comman;

namespace OnTime.Data.Entities.Employee
{
    public class EmployeeDocument 
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? PassportNumber { get; set; }

        public DateTime? PassportExpirationDate { get; set; }

        [MaxLength(50)]
        public string? VisaNumber { get; set; }

        public DateTime? VisaExpirationDate { get; set; }

        public int EmployeeId { get; set; }

        // Navigation property
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } = null!;
    }
}
