using Moujam.Casiher.Comman.Base;
using OnTime.CrossCutting.Comman;
using System.ComponentModel.DataAnnotations;

namespace ProjectPulse.Data.Entities
{
    public class DepartmentType : AuditEntity<long>, ILookup
    {
        [MaxLength(500)]
        public string Name { get; set; } = string.Empty;
        public string NameSE { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }

        public ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}
