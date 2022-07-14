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

        public object GetDbSet(string type)
        {

                if (typeof(Ciudad).ToString() == type)
                    return Ciudades;
                if( typeof(EstadoViaje).ToString() == type)
                    return EstadoViajes;
                if( typeof(Pais).ToString() == type)
                    return Paises;
                if( typeof(Pronostico).ToString() == type)
                    return Pronosticos;
                if( typeof(ReprogramacionViaje).ToString() == type)
                    return ReprogramacionViajes;
                if( typeof(TipoVehiculo).ToString() == type)
                    return TipoVehiculos;
                if( typeof(Vehiculo).ToString() == type)
                    return Vehiculos;
                if( typeof(Viaje).ToString() == type)
                    return Viajes;
            return null;
        }

        public TravelContext(DbContextOptions<TravelContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder m)
        {

            m.Entity<Viaje>()
                .HasOne(v => v.CiudadOrigen)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            m.Entity<Viaje>()
                .HasOne(v => v.CiudadDestino)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
