namespace Interfaces.Services
{
    using Models.Filter;
    public interface IViajesServices : IRepository<Models.Input.Viaje, Models.Domain.Viaje, Models.Output.Viaje, ViajesFilter>
    {
        public Task<Models.Output.Output<bool>> Viajar(Models.Input.Viaje viaje);
        public Task<Models.Output.Output<bool>> ReprogramarViaje(Models.Input.Viaje viaje);
        public Task<Models.Output.Output<bool>> TiempoFavorable(Models.Input.Viaje viaje);

    }
}
