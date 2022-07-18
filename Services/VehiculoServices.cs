using AutoMapper;
using Repository;
using Models.Filter;
namespace Services
{
    public class VehiculoServices : BasicServices<Models.Input.Vehiculo, Models.Domain.Vehiculo, Models.Output.Vehiculo, VehiculosFilter>, Interfaces.Services.IVehiculosServices
    {
        public VehiculoServices(
            IMapper mapper,
            UnitOfWork unitOfWork
        ) : base(mapper, unitOfWork)
        {

        }
    }
}
