using Moujam.Casiher.Comman.Base;
using OnTime.CrossCutting.Comman;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPulse.Data.Entities
{
    public class Organization:AuditEntity<int>, ILookup
    {
        [MaxLength(500)]
      public  string Name { get; set; }
        [MaxLength(500)]
        public string NameSE { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    //    public ICollection<Company> Companies { get; set; } = new List<Company>();  
        public ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}
