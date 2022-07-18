namespace Interfaces.Repositories
{
    using Models.Filter;
    public interface IViajesRepository : IRepositoryMethods<Models.Domain.Viaje, ViajesFilter>
    {
        public IRepository<Models.Input.Viaje, Models.Domain.Viaje> _repository { get; }
        public Task<bool> CanTravelToCity(Models.Domain.Viaje entity);
        public Task<List<Models.Domain.Viaje>> FindProgramados(int page, int limit, bool useFilter, ViajesFilter fModel);
        public Task<List<Models.Domain.Viaje>> FindTerminados(int page, int limit, bool useFilter, ViajesFilter fModel);
    }
}
