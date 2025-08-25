using AutoMapper;
using OnTime.Employee.Services.DTO;
using OnTime.Data.Entities.Employee;
using EmployeeEntity = OnTime.Data.Entities.Employee.Employee;
using EmployeeContactEntity = OnTime.Data.Entities.Employee.EmployeeContact;
using EmployeeDocumentEntity = OnTime.Data.Entities.Employee.EmployeeDocument;

namespace OnTime.Employee.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Employee mappings
            CreateMap<EmployeeDto, EmployeeEntity>();
            CreateMap<EmployeeEntity, EmployeeDto>();
            
            CreateMap<EmployeeContactDto, EmployeeContactEntity>();
            CreateMap<EmployeeContactEntity, EmployeeContactDto>();
            
            CreateMap<EmployeeDocumentDto, EmployeeDocumentEntity>();
            CreateMap<EmployeeDocumentEntity, EmployeeDocumentDto>();
        }
    }
}
