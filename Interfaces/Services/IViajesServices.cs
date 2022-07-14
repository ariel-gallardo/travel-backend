﻿namespace Interfaces.Services
{
    public interface IViajesServices : IRepository<Models.Input.Viaje, Models.Domain.Viaje, Models.Output.Viaje>
    {
        public Task<Models.Output.Output<bool>> Viajar(Models.Input.Viaje viaje);
    }
}
