using AutoMapper;
using OnTime.Module.lookup.DTO;
using OnTime.Module.lookup.DTO.Company;
using OnTime.Module.lookup.DTO.Department;
using OnTime.Module.lookup.DTO.Job;
using OnTime.Module.lookup.DTO.CompanyType;
using OnTime.Module.lookup.DTO.DepartmentType;
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
            
            CreateMap<JobDto, Job>();
            CreateMap<Job, JobDto>();
            
            CreateMap<CompanyDto, Company>();
            CreateMap<Company, CompanyDto>();
            
            CreateMap<DepartmentDto, Department>();
            CreateMap<Department, DepartmentDto>();
            
            CreateMap<CompanyTypeDto, CompanyType>();
            CreateMap<CompanyType, CompanyTypeDto>();
            
            CreateMap<DepartmentTypeDto, DepartmentType>();
            CreateMap<DepartmentType, DepartmentTypeDto>();
        }
    }

}
