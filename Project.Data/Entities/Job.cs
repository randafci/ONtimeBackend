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
    public sealed class Job : AuditEntity<int>,ILookup
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
      public  string NameSE { get; set; }
        public bool IsDeleted { get; set; }

    }
}
