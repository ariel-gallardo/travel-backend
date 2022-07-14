namespace Interfaces.Repositories
{
    public interface IViajesRepository : IRepositoryMethods<Models.Domain.Viaje>
    {
        public IRepository<Models.Input.Viaje, Models.Domain.Viaje> _repository { get; }
    }
}
