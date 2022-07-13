namespace Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        public object SelectRepository(System.Type domainType);
        public ICiudadRepository CiudadRepository { get;}
        public IPaisRepository PaisRepository { get;}
    }
}
