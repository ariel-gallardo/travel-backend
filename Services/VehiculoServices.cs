using AutoMapper;
using Repository;

namespace Services
{
    public class VehiculoServices : BasicServices<Models.Input.Vehiculo, Models.Domain.Vehiculo, Models.Output.Vehiculo>, Interfaces.Services.IVehiculosServices
    {
        public VehiculoServices(
            IMapper mapper,
            UnitOfWork unitOfWork
        ) : base(mapper, unitOfWork)
        {

        }
    }
}
