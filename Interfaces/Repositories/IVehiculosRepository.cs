namespace Interfaces.Repositories
{
    public interface IVehiculosRepository : IRepositoryMethods<Models.Domain.Vehiculo>
    {
        public IRepository<Models.Input.Vehiculo, Models.Domain.Vehiculo> _repository { get; }
        public Task<bool> ItsBusy(long id);
        public Task<bool> UseVehicle(long id);
    }
}
