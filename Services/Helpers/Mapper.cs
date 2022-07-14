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
            }
        }

        public class InputToDomain : Profile
        {
            public InputToDomain()
            {
                CreateMap<Models.Input.Ciudad, Models.Domain.Ciudad>();
                CreateMap<Models.Input.Pais, Models.Domain.Pais>();
                CreateMap<Models.Input.TipoVehiculo, Models.Domain.TipoVehiculo>();
            }
        }
}
