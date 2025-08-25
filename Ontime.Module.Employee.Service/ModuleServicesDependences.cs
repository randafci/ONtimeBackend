using Microsoft.Extensions.DependencyInjection;
using OnTime.Employee.Services.Interfaces;
using OnTime.Employee.Services.Implementation;
using OnTime.Employee.Services.Mapper;

namespace OnTime.Employee.Services
{
    public static class ModuleServicesDependences
    {
        public static IServiceCollection AddEmployeeServices(this IServiceCollection service)
        {
            // Register Employee services
            service.AddScoped<IEmployeeService, EmployeeService>();
            
            // Register AutoMapper
            service.AddAutoMapper(typeof(MappingProfile));
            
            return service;
        }
    }
}