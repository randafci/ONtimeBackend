using Microsoft.AspNetCore.Mvc;
using OnTime.Lookups.Services.Contracts;
using OnTime.Module.lookup.DTO;
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
    //public class ComapnyController : LookupController<company, JobDto>
    //{
    //    public comapnyController(ILookupService<Job, JobDto> iLookupService) : base(iLookupService) { }
    //}
}