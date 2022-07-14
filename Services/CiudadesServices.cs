namespace Services 
{
    using AutoMapper;
    using Interfaces.Repositories;
    using Repository;

    public class CiudadesServices : BasicServices<Models.Input.Ciudad, Models.Domain.Ciudad, Models.Output.Ciudad>, Interfaces.Services.ICiudadesServices
    {
        public CiudadesServices(
            IMapper mapper,
            UnitOfWork unitOfWork
        ) : base(mapper, unitOfWork)
        {
            
        }
    }
}
