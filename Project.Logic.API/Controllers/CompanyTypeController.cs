using Microsoft.AspNetCore.Mvc;
using OnTime.Lookups.Services.Contracts;
using OnTime.Module.lookup.DTO.CompanyType;
using ProjectPulse.Data.Entities;

namespace OnTime.Lookups.Domain.API.Controllers
{
    public class CompanyTypeController : LookupController<CompanyTypeLookup, CompanyTypeDto>
    {
        public CompanyTypeController(ILookupService<CompanyTypeLookup, CompanyTypeDto> iLookupService) : base(iLookupService) { }
    }
}
