using Moujam.Casiher.Comman.Base;
using System.Collections.Generic;

namespace OnTime.Data.Entities.Employee
{
    public class Employee : AuditEntity<int>
    {
        public string EmployeeCode { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        /// <summary>
        /// 'M' for Male, 'F' for Female
        /// </summary>
        public char? Gender { get; set; }

        public string? Nationality { get; set; }

        public string? ReligionType { get; set; }

        public bool IsSpecialNeeds { get; set; } = false;

        public string? ImageUrl { get; set; }

        public string? EmployeeType { get; set; }

        public string? EmployeeStatus { get; set; }

        // Navigation properties for 1:1 relationships
        public EmployeeContact? Contact { get; set; }
        public EmployeeDocument? Document { get; set; }
    }
}
