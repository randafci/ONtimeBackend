using AutoMapper;
using OnTime.Module.lookup.DTO;
using ProjectPulse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnTime.Module.lookup.Mapper
{
    public class LookupMappingProfile : Profile
    {
        public LookupMappingProfile()
        {
            CreateMap<OrganizationDto, Organization>();
            CreateMap<Organization, OrganizationDto>();
            // Add other DTO <-> Entity mappings here
        }
    }

}
