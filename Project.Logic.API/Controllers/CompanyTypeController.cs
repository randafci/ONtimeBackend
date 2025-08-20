using Microsoft.AspNetCore.Mvc;
using OnTime.Lookups.Services.Contracts;
using OnTime.Module.lookup.DTO.CompanyType;
using ProjectPulse.Data.Entities;

namespace OnTime.Lookups.Domain.API.Controllers
{
    public class CompanyTypeController : LookupController<CompanyType, CompanyTypeDto>
    {
        public CompanyTypeController(ILookupService<CompanyType, CompanyTypeDto> iLookupService) : base(iLookupService) { }
    }
}
