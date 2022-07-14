using AutoMapper;
using Models.Input;
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

        public async Task<Models.Output.Output<bool>> Viajar(Viaje viaje)
        {
            var output = new Models.Output.Output<bool>();

            var canTravelToCity = await _unitOfWork.ViajesRepository.
                CanTravelToCity(_mapper.Map<Viaje,Models.Domain.Viaje>(viaje));

            var canUseCar = !await _unitOfWork
                .VehiculosRepository
                .ItsBusy(viaje.VehiculoId);

            if (!canTravelToCity)
                output.Messages.Add("No se puede viajar desde la ubicacion seleccionada.");
            else
                output.Messages.Add("Se puede viajar a destino.");
            if (!canUseCar)
                output.Messages.Add("El vehiculo se encuentra ocupado / verifique la seleccion.");
            else
                output.Messages.Add("El vehiculo se puede utilizar.");

            if(canTravelToCity && canUseCar)
            {
                output.Messages.Clear();
                var result = await Create(viaje);
                output.StatusCode = result.StatusCode;
                output.Data = result.Data;
                if(await _unitOfWork.VehiculosRepository.UseVehicle(viaje.VehiculoId)) {
                    if (!result.Data)
                        foreach (var message in result.Messages) output.Messages.Add(message);
                    else
                        output.Messages.Add($"Viaje creado exitosamente.");
                }
                else
                {
                    output.Messages.Add($"Lo lamento ocuparon su vehiculo.");
                    output.StatusCode = 400;
                }
            }
            else
            {
                output.StatusCode = 400;
                output.Data = canTravelToCity && canUseCar;
            } 

            return output;
        }
    }
}
