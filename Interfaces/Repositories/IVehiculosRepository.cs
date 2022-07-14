namespace Interfaces.Repositories
{
    public interface IVehiculosRepository : IRepositoryMethods<Models.Domain.Vehiculo>
    {
        public IRepository<Models.Input.Vehiculo, Models.Domain.Vehiculo> _repository { get; }
    }
}
