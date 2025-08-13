using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.CrossCutting.Comman.Idenitity
{
    public class ApplicationRole : IdentityRole
    {
        public bool? IsHRRole { get; set; }
        public bool? IsDefaultRole { get; set; }
    }

}
