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
        }
        }

        public class InputToDomain : Profile
        {
            public InputToDomain()
            {
                CreateMap<Models.Input.Ciudad, Models.Domain.Ciudad>();
                CreateMap<Models.Input.Pais, Models.Domain.Pais>();
                CreateMap<Models.Input.Vehiculo, Models.Domain.Vehiculo>();
            }
        }
}
