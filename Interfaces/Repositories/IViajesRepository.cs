namespace Interfaces.Repositories
{
    using Models.Filter;
    public interface IViajesRepository : IRepositoryMethods<Models.Domain.Viaje, ViajesFilter>
    {
        public IRepository<Models.Input.Viaje, Models.Domain.Viaje, ViajesFilter> _repository { get; }
        public Task<bool> CanTravelToCity(Models.Domain.Viaje entity);
    }
}
