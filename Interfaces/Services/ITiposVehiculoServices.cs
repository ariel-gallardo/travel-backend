namespace Interfaces.Services
{
    using Models.Filter;
    public interface ITiposVehiculoServices : IRepository<Models.Input.TipoVehiculo, Models.Domain.TipoVehiculo, Models.Output.TipoVehiculo, TiposVehiculoFilter>
    {

    }
}
