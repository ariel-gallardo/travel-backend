
namespace Interfaces.Repositories
{
    public interface IRepositoryMethods<DomainType, FilterType>
    {
        public Task<bool> Create(DomainType entity);
        public Task<bool> Update(DomainType entity);
        public Task<bool> SoftDelete(DomainType entity);
        public Task<DomainType> FindById(long id);
        public Task<List<DomainType>> FindAll(int page, int limit, bool useFilter, FilterType fModel);
        public Task<int> Count();
    }
}
