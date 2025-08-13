using Microsoft.Extensions.DependencyInjection;
using OnTime.Repository.Repository;

namespace OnTime.Repository
{
    public static class ModuleInfrastructureDependences
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection service)
        {
            service.AddTransient<UnitOfWork>();
            return service;
        }
    }
}
