using AutoMapper;
using Repository;

namespace Services
{
    public class TiposVehiculoServices : BasicServices<Models.Input.TipoVehiculo, Models.Domain.TipoVehiculo, Models.Output.TipoVehiculo>, Interfaces.Services.ITiposVehiculoServices
    {
        public TiposVehiculoServices(
            IMapper mapper,
            UnitOfWork unitOfWork
        ) : base(mapper, unitOfWork)
        {

        }
    }
}
