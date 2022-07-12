namespace Services 
{
    using AutoMapper;
    using Repository;

    public class CiudadesServices : BasicServices<Models.Input.Ciudad, Models.Domain.Ciudad, Models.Output.Ciudad>, Interfaces.Services.ICiudadesServices
    {
        public CiudadesServices(TravelContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
