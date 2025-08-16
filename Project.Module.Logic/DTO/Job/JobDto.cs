using ProjectPulse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.Module.lookup.DTO.Job
{
    public class JobDto
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int OrganizationId { get; set; }
        public string NameSE { get; set; }
    }
}
