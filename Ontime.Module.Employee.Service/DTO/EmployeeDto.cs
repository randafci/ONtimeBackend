using System;
using System.ComponentModel.DataAnnotations;

namespace OnTime.Employee.Services.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string EmployeeCode { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        public char? Gender { get; set; }

        [MaxLength(100)]
        public string? Nationality { get; set; }

        [MaxLength(50)]
        public string? ReligionType { get; set; }

        public bool IsSpecialNeeds { get; set; } = false;

        [MaxLength(255)]
        public string? ImageUrl { get; set; }

        [MaxLength(50)]
        public string? EmployeeType { get; set; }

        [MaxLength(50)]
        public string? EmployeeStatus { get; set; }

        // Navigation properties
        public EmployeeContactDto? Contact { get; set; }
        public EmployeeDocumentDto? Document { get; set; }
    }
}
