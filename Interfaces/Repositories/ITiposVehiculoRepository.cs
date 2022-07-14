namespace Interfaces.Repositories
{
    public interface ITiposVehiculoRepository : IRepositoryMethods<Models.Domain.TipoVehiculo>
    {
        public IRepository<Models.Input.TipoVehiculo, Models.Domain.TipoVehiculo> _repository { get; }
    }
}
