
namespace Interfaces.Repositories
{
    public interface IPaisRepository : IRepositoryMethods<Models.Domain.Pais>
    {
        public IRepository<Models.Input.Pais, Models.Domain.Pais> _repository { get; }
    }
}
