namespace Interfaces.Repositories
{
    using Models.Filter;
    public interface IVehiculosRepository : IRepositoryMethods<Models.Domain.Vehiculo, VehiculosFilter>
    {
        public IRepository<Models.Input.Vehiculo, Models.Domain.Vehiculo, VehiculosFilter> _repository { get; }
        public Task<bool> ItsBusy(long id);
        public Task<bool> UseVehicle(long id);
        public Task<bool> FreeVehicle(long id);
    }
}
