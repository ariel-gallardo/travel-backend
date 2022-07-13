using AutoMapper;

namespace Services
{
        public class DomainToOutput : Profile
        {
            public DomainToOutput()
            {
                CreateMap<Models.Domain.Ciudad, Models.Output.Ciudad>();

                CreateMap<Models.Domain.Pais, Models.Output.Pais>()
                    .ForMember(o => o.Ciudades, opt => opt.Ignore());
            }
        }

        public class InputToDomain : Profile
        {
            public InputToDomain()
            {
                CreateMap<Models.Input.Ciudad, Models.Domain.Ciudad>();
                CreateMap<Models.Input.Pais, Models.Domain.Pais>();
            }
        }
}
