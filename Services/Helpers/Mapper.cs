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
                .ForMember(o => o.FechaFin, opt => opt.MapFrom(d => d.FechaFin.Value.ToLocalTime().ToString()));

                CreateMap<Models.Domain.Pronostico, Models.Output.Pronostico>()
                .ForMember(o => o.Pais, opt => opt.Ignore())
                .ForMember(o => o.Estado, opt => opt.MapFrom(d => d.Descripcion))
                .ForMember(o => o.Ciudad, opt => opt.MapFrom(d => d.Ciudad.Nombre));
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
                CreateMap<Models.Input.TipoVehiculo, Models.Domain.TipoVehiculo>();
            }
        }

        public class ExternalDomainToDomain : Profile
        {
            public ExternalDomainToDomain()
            {
                CreateMap<Models.Domain.ExternalPronostico, Models.Domain.Pronostico>()
                .ForMember(o => o.Ciudad, opt => opt.Ignore())
                .ForMember(o => o.Descripcion, opt => opt.MapFrom(d => d.Weather.Last().Main))
                .ForMember(o => o.DiaSolicitado, opt => opt.Ignore())
                .ForMember(o => o.CiudadId, opt => opt.Ignore());
            }
        }
}
