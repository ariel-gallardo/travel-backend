using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Middleware
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<Interfaces.Services.IPaisesServices, Services.PaisesServices>();
            services.AddTransient<Interfaces.Services.ICiudadesServices, Services.CiudadesServices>();
            return services;
        }
    }
}