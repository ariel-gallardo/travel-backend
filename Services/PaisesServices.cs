using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Repository;

namespace Services
{
    public class PaisesServices : BasicServices<Models.Input.Pais, Models.Domain.Pais, Models.Output.Pais>, Interfaces.Services.IPaisesServices
    {
        public PaisesServices(TravelContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
