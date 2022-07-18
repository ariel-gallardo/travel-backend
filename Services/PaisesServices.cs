using AutoMapper;
using Interfaces.Repositories;
using Repository;
using Models.Filter;
namespace Services
{
    public class PaisesServices : BasicServices<Models.Input.Pais, Models.Domain.Pais, Models.Output.Pais, PaisesFilter>, Interfaces.Services.IPaisesServices
    {
        public PaisesServices(
            IMapper mapper,
            UnitOfWork unitOfWork
        ) : base(mapper, unitOfWork)
        {
        }
    }
}
