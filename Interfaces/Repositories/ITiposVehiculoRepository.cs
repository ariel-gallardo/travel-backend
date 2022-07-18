namespace Interfaces.Repositories
{
    using Models.Filter;
    public interface ITiposVehiculoRepository : IRepositoryMethods<Models.Domain.TipoVehiculo, TiposVehiculoFilter>
    {
        public IRepository<Models.Input.TipoVehiculo, Models.Domain.TipoVehiculo, TiposVehiculoFilter> _repository { get; }
    }
}
