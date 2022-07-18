namespace Interfaces.Repositories
{
    using Models.Filter;
    public interface ICiudadRepository: IRepositoryMethods<Models.Domain.Ciudad, CiudadesFilter>
    {
        public IRepository<Models.Input.Ciudad, Models.Domain.Ciudad, CiudadesFilter> _repository { get; }
    }
}
