using HomeAutomation.Application.Mappers;
using HomeAutomation.Application.Services.Impl;
using HomeAutomation.Application.Services.Interface;
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

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDispositivoService, DispositivoService>();
            return services;
        }

        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DispositivoMapper));
            return services;
        }
    }
}
