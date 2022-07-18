namespace Interfaces.Services
{
    using Models.Filter;
    public interface IVehiculosServices : IRepository<Models.Input.Vehiculo, Models.Domain.Vehiculo, Models.Output.Vehiculo, VehiculosFilter>
    {

    }
}
