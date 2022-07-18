using AutoMapper;
using Repository;
using Models.Filter;
namespace Services
{
    public class TiposVehiculoServices : BasicServices<Models.Input.TipoVehiculo, Models.Domain.TipoVehiculo, Models.Output.TipoVehiculo, TiposVehiculoFilter>, Interfaces.Services.ITiposVehiculoServices
    {
        public TiposVehiculoServices(
            IMapper mapper,
            UnitOfWork unitOfWork
        ) : base(mapper, unitOfWork)
        {

        }
    }
}
