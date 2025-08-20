using Moujam.Casiher.Comman.Base;
using OnTime.CrossCutting.Comman;
using System.ComponentModel.DataAnnotations;

namespace ProjectPulse.Data.Entities
{
    public class Department : AuditEntity<long>, ILookup
    {
        [MaxLength(100)]
        public string Code { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string NameSE { get; set; } = string.Empty;

        public long Index { get; set; }

        public long? ParentId { get; set; }
        public bool FromIntegration { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public long? CompanyId { get; set; }
        public Company? Company { get; set; }

        public bool IsDeleted { get; set; }

        // Navigation properties
        public Department? Parent { get; set; }
        public ICollection<Department> Children { get; set; } = new List<Department>();
        public int? DepartmentTypeId { get; set; }
        public DepartmentType? DepartmentType { get; set; }
    }

}
