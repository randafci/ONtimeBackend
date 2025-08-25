using System;
using System.ComponentModel.DataAnnotations;

namespace OnTime.Employee.Services.DTO
{
    public class EmployeeDocumentDto
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string? PassportNumber { get; set; }

        public DateTime? PassportExpirationDate { get; set; }

        [MaxLength(50)]
        public string? VisaNumber { get; set; }

        public DateTime? VisaExpirationDate { get; set; }

        public int EmployeeId { get; set; }
    }
}
