using Loymark.Servicios;
using Loymark.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Loymark.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Loymark.Helpers;

namespace Loymark
{
    public static class DIServicesConfiguration
    {
        public static IServiceCollection ConfigureServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IActividadesServices, ActividadesService>();
            services.AddScoped<IUsuariosService, UsuariosService>();


            return services;
        }

        public static void ConfigureServiceContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LoymarkContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
        public static void ConfigureMappingProfile(this IMapperConfigurationExpression config)
        {
            config.AddProfile<MapperProfile>();
        }
    }
}
