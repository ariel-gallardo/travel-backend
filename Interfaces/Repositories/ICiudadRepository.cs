namespace Interfaces.Repositories
{
    public interface ICiudadRepository: IRepositoryMethods<Models.Domain.Ciudad>
    {
        public IRepository<Models.Input.Ciudad, Models.Domain.Ciudad> _repository { get; }
    }
}
