
namespace Interfaces.Repositories
{
    using Models.Filter;
    public interface IPaisRepository : IRepositoryMethods<Models.Domain.Pais, PaisesFilter>
    {
        public IRepository<Models.Input.Pais, Models.Domain.Pais> _repository { get; }
    }
}
