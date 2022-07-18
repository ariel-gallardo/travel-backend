namespace Services 
{
    using AutoMapper;
    using Interfaces.Repositories;
    using Repository;
    using Models.Filter;
    public class CiudadesServices : BasicServices<Models.Input.Ciudad, Models.Domain.Ciudad, Models.Output.Ciudad, CiudadesFilter>, Interfaces.Services.ICiudadesServices
    {
        public CiudadesServices(
            IMapper mapper,
            UnitOfWork unitOfWork
        ) : base(mapper, unitOfWork)
        {
            
        }
    }
}
