using AutoMapper;

namespace Services
{
        public class DomainToOutput : Profile
        {
            public DomainToOutput()
            {
                CreateMap<Models.Domain.Ciudad, Models.Output.Ciudad>()
                .ForMember(o => o.Pais, opt => opt.MapFrom(d => d.Pais.Nombre));
                CreateMap<Models.Domain.Pais, Models.Output.Pais>();

                CreateMap<Models.Domain.TipoVehiculo, Models.Output.TipoVehiculo>();
                CreateMap<Models.Domain.Vehiculo, Models.Output.Vehiculo>()
                .ForMember(o => o.TipoVehiculo, opt => opt.MapFrom(d => d.Tipo.Denominacion));

                CreateMap<Models.Domain.Viaje, Models.Output.Viaje>()
                .ForMember(o => o.EstadoViaje, opt => opt.MapFrom(d => d.EstadoViaje.LastOrDefault()))
                .ForMember(o => o.PaisOrigen, opt => opt.MapFrom(d => d.CiudadOrigen.Pais.Nombre))
                .ForMember(o => o.PaisDestino, opt => opt.MapFrom(d => d.CiudadDestino.Pais.Nombre))
                .ForMember(o => o.CiudadOrigen, opt => opt.MapFrom(d => d.CiudadOrigen.Nombre))
                .ForMember(o => o.CiudadDestino, opt => opt.MapFrom(d => d.CiudadDestino.Nombre))
                .ForMember(o => o.FechaInicio, opt => opt.MapFrom(d => d.FechaInicio.ToLocalTime().ToString()))
                .ForMember(o => o.FechaFin, opt => opt.MapFrom(d => d.FechaFin.ToLocalTime().ToString()));
        }
    }

        public class InputToDomain : Profile
        {
            public InputToDomain()
            {
                CreateMap<Models.Input.Ciudad, Models.Domain.Ciudad>();
                CreateMap<Models.Input.Pais, Models.Domain.Pais>();
                CreateMap<Models.Input.Vehiculo, Models.Domain.Vehiculo>();
                CreateMap<Models.Input.Viaje, Models.Domain.Viaje>();
            }
        }
}
