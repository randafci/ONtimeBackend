using Microsoft.Extensions.DependencyInjection;
using OnTime.CrossCutting.Comman.Time;
using OnTime.Services.Helpers;
//using OnTime.Services.Implementation;
using OnTime.Services.Interfaces;
using OnTime.Services.Mapper;
using OnTime.User.Services.Implementation;
using OnTime.User.Services.Interfaces;
using  OnTime.CrossCutting.Comman.Time;
using OnTime.User.Services.DTO;
using OnTime.Application.Common.Interfaces;

namespace OnTime.User.Services
{
    public static class ModuleServicesDependences
    {
        public static IServiceCollection AddReposetoriesServices(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(MappingProfile));
           // service.AddTransient<IAuthenticationService, AuthenticationService>();
            service.AddTransient<IHelpureService, HelpureService>();
            service.AddScoped<IAccountServices, AccountServices>();
            service.AddScoped<ISettingsProvider, SettingsProvider>();
            service.AddScoped<ILdapAuthenticator, LdapAuthenticator>();
            service.AddScoped<IDateTimeProvider, SystemDateTimeProvider>();
            service.AddScoped<IJwtServices, JwtServices>();


            service.AddScoped<ICurrentUserService, CurrentUserService>();




            return service;
        }
    }
}
