using Microsoft.EntityFrameworkCore;
using Models.Domain;

namespace Repository
{
    public class TravelContext : DbContext
    {
        #region Entities
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<EstadoViaje> EstadoViajes { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Pronostico> Pronosticos { get; set; }
        public DbSet<ReprogramacionViaje> ReprogramacionViajes { get; set; }
        public DbSet<TipoVehiculo> TipoVehiculos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        #endregion

        public TravelContext(DbContextOptions options) : base(options)
        {

        }
    }
}
