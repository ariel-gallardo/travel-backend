
namespace Interfaces.Repositories
{
    public interface IRepositoryMethods<DomainType>
    {
        public Task<bool> Create(DomainType entity);
        public Task<bool> Update(DomainType entity);
        public Task<bool> SoftDelete(DomainType entity);
        public Task<DomainType> FindById(long id);
        public Task<List<DomainType>> FindAll(int page, int limit);
        public Task<int> Count();
    }
}
