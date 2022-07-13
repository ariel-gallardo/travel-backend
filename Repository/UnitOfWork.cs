using Interfaces.Repositories;

namespace Repository
{
    public class UnitOfWork
    {
        public readonly TravelContext _context;
        #region Repositories
        public  ICiudadRepository CiudadRepository { get; }
        public  IPaisRepository PaisRepository { get; }
        #endregion

        public UnitOfWork(
            TravelContext context
        )
        {
            _context = context;
            CiudadRepository = new CiudadRepository(_context);
            PaisRepository = new PaisRepository(_context);
        }

        public object SelectRepository(System.Type domainType)
        {
            if (typeof(Models.Domain.Ciudad) == domainType)
                return CiudadRepository;
            if (typeof(Models.Domain.Pais) == domainType)
                return PaisRepository;
            return null;
        }
    }
}
