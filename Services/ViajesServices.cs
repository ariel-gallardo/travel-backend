using AutoMapper;
using Repository;

namespace Services
{
    public class ViajesServices : BasicServices<Models.Input.Viaje, Models.Domain.Viaje, Models.Output.Viaje>, Interfaces.Services.IViajesServices
    {
        public ViajesServices(
            IMapper mapper,
            UnitOfWork unitOfWork
        ) : base(mapper, unitOfWork)
        {

        }
    }
}
