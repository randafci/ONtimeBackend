using Microsoft.AspNetCore.Mvc;
using OnTime.Lookups.Services.Contracts;
using OnTime.Module.lookup.DTO;
using ProjectPulse.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OnTime.Lookups.Domain.API.Controllers
{

    public class OrganizationController : LookupController<Organization, OrganizationDto>
    {
        public OrganizationController(ILookupService<Organization, OrganizationDto> iLookupService) : base(iLookupService) { }
    }

}