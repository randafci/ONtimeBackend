using Microsoft.AspNetCore.Mvc;
using OnTime.Lookups.Services.Contracts;
using OnTime.Module.lookup.DTO.DepartmentType;
using ProjectPulse.Data.Entities;

namespace OnTime.Lookups.Domain.API.Controllers
{
    public class DepartmentTypeController : LookupController<DepartmentType, DepartmentTypeDto>
    {
        public DepartmentTypeController(ILookupService<DepartmentType, DepartmentTypeDto> iLookupService) : base(iLookupService) { }
    }
}
