using AutoMapper;
using Interfaces.Services;
using Models.Input;
using Repository;

namespace Services
{
    public class ViajesServices : BasicServices<Models.Input.Viaje, Models.Domain.Viaje, Models.Output.Viaje>, Interfaces.Services.IViajesServices
    {
        private readonly IPronosticoServices _pronosticoServices;

        public ViajesServices(
            IMapper mapper,
            UnitOfWork unitOfWork,
            Interfaces.Services.IPronosticoServices pronosticoServices
        ) : base(mapper, unitOfWork)
        {
            _pronosticoServices = pronosticoServices;
        }

        public Task<Models.Output.Output<bool>> ReprogramarViaje(Viaje viaje)
        {

            throw new NotImplementedException();
        }

        public async Task<Models.Output.Output<bool>> TiempoFavorable(Viaje viaje)
        {
            var output = new Models.Output.Output<bool>();

            var cOrigen = await _unitOfWork.CiudadRepository.FindById(viaje.CiudadOrigenId);
            var cDestino = await _unitOfWork.CiudadRepository.FindById(viaje.CiudadDestinoId);

            var proOrigen = await _pronosticoServices.ConsultarPronostico(cOrigen);
            var proDestino = await _pronosticoServices.ConsultarPronostico(cDestino);

            if (proOrigen.Data == null || proDestino.Data == null)
            {
                output.Messages.Add("No se encontro la ciudad de origen.");
                output.StatusCode = 400;
                output.Data = false;
                return output;
            }

            if (proOrigen.StatusCode == 200 && proDestino.StatusCode == 200)
            {
                output.StatusCode = 200;
                proOrigen.Data.Pais = cOrigen.Pais.Nombre;
                proDestino.Data.Pais = cDestino.Pais.Nombre;
                output.Data = proOrigen.Data.Estado.ToLower() != "clouds"
                    && proDestino.Data.Estado.ToLower() != "clouds";

                if(output.Data)
                    output.Messages.Add("se puede viajar");
                else
                    output.Messages.Add("No hay tiempo favorable repgrograme / cancele el viaje.");
            }
            else
            {
                output.Data = false;
                output.StatusCode = 404;
                output.Messages.Add("No se puede viajar");
            }

            return output;
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
