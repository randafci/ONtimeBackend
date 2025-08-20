using Moujam.Casiher.Comman.Base;
using OnTime.CrossCutting.Comman;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectPulse.Data.Entities
{
    public class Company : AuditEntity<long>, ILookup
    {
        [MaxLength(100)]
        public string Code { get; set; } = string.Empty;
        
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(200)]
        public string NameSE { get; set; } = string.Empty;
        
        public long Index { get; set; }
        
        public long? ParentId { get; set; }
        
        public bool FromIntegration { get; set; }
        
        public int OrganizationId { get; set; }
        
        public bool IsDeleted { get; set; }
        
        // Navigation properties
        public Company? Parent { get; set; }
        public ICollection<Company> Children { get; set; } = new List<Company>();
      //  public ICollection<Department> Departments { get; set; } = new List<Department>();
       public Organization? Organization { get; set; }
       public int? CompanyTypeId { get; set; }
       public CompanyType? CompanyType { get; set; }
    }
}
