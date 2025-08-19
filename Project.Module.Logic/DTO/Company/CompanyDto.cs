using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.Module.lookup.DTO.Company
{
    public class CompanyDto
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string NameSE { get; set; } = string.Empty;
        public long Index { get; set; }
        public long? ParentId { get; set; }
        public bool FromIntegration { get; set; }
        public int OrganizationId { get; set; }
    }
}
