using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Middleware
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            #region 
            
            services.AddScoped<Repository.UnitOfWork>();
            #endregion

            #region Services
                services.AddTransient<Interfaces.Services.ITiposVehiculoServices, Services.TiposVehiculoServices>();
                services.AddTransient<Interfaces.Services.ICiudadesServices, Services.CiudadesServices>();
                services.AddTransient<Interfaces.Services.IPaisesServices, Services.PaisesServices>();
                services.AddTransient<Interfaces.Services.IVehiculosServices, Services.VehiculoServices>();
                services.AddTransient<Interfaces.Services.IViajesServices, Services.ViajesServices>();
            #endregion



            return services;
        }
    }
}