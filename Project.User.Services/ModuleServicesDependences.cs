using Microsoft.Extensions.DependencyInjection;
using OnTime.Services.Helpers;
//using OnTime.Services.Implementation;
using OnTime.Services.Interfaces;
using OnTime.Services.Mapper;

namespace OnTime.User.Services
{
    public static class ModuleServicesDependences
    {
        public static IServiceCollection AddReposetoriesServices(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(MappingProfile));
           // service.AddTransient<IAuthenticationService, AuthenticationService>();
            service.AddTransient<IHelpureService, HelpureService>();
            return service;
        }
    }
}
