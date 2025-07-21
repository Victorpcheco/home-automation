using HomeAutomation.Domain.Interfaces;
using HomeAutomation.infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HomeAutomation.infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
            return services;
        }
    }
}
