using Microsoft.AspNetCore.Mvc;
using OnTime.Lookups.Services.Contracts;
using OnTime.Module.lookup.DTO;
using OnTime.Module.lookup.DTO.Company;
using OnTime.Module.lookup.DTO.Department;
using OnTime.Module.lookup.DTO.Job;
using ProjectPulse.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OnTime.Lookups.Domain.API.Controllers
{

    public class OrganizationController : LookupController<Organization, OrganizationDto>
    {
        public OrganizationController(ILookupService<Organization, OrganizationDto> iLookupService) : base(iLookupService) { }
    }

    public class JobController : LookupController<Job, JobDto>
    {
        public JobController(ILookupService<Job, JobDto> iLookupService) : base(iLookupService) { }
    }

    public class CompanyController : LookupController<Company, CompanyDto>
    {
        public CompanyController(ILookupService<Company, CompanyDto> iLookupService) : base(iLookupService) { }
    }

    public class DepartmentController : LookupController<Department, DepartmentDto>
    {
        public DepartmentController(ILookupService<Department, DepartmentDto> iLookupService) : base(iLookupService) { }
    }
}