using Interfaces.Repositories;

namespace Repository
{
    public class UnitOfWork
    {
        public readonly TravelContext _context;
        #region Repositories
        public  ICiudadRepository CiudadRepository { get; }
        public  IPaisRepository PaisRepository { get; }
        public  ITiposVehiculoRepository TiposVehiculoRepository { get; }
        #endregion

        public UnitOfWork(
            TravelContext context
        )
        {
            _context = context;
            CiudadRepository = new CiudadRepository(_context,this);
            PaisRepository = new PaisRepository(_context,this);
            TiposVehiculoRepository = new TiposVehiculoRepository(_context, this);
        }

        public object SelectRepository(System.Type domainType)
        {
            if (typeof(Models.Domain.Ciudad) == domainType)
                return CiudadRepository;
            if (typeof(Models.Domain.Pais) == domainType)
                return PaisRepository;
            if (typeof(Models.Domain.TipoVehiculo) == domainType)
                return TiposVehiculoRepository;
            return null;
        }
    }
}
