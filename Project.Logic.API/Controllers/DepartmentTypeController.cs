using Microsoft.AspNetCore.Mvc;
using OnTime.Lookups.Services.Contracts;
using OnTime.Module.lookup.DTO.DepartmentType;
using ProjectPulse.Data.Entities;

namespace OnTime.Lookups.Domain.API.Controllers
{
    public class DepartmentTypeController : LookupController<DepartmentTypeLookup, DepartmentTypeDto>
    {
        public DepartmentTypeController(ILookupService<DepartmentTypeLookup, DepartmentTypeDto> iLookupService) : base(iLookupService) { }
    }
}
