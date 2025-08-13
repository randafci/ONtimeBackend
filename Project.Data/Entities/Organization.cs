using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPulse.Data.Entities
{
    public class Organization
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Job> Jobs { get; set; } = new List<Job>();


    }
}
