namespace Interfaces.Repositories
{
    public interface IRepository<InputType,DomainType, FilterType> where DomainType : Models.Domain.Entity 
    {
        public Task<bool> Create(DomainType entity);
        public Task<bool> Update(DomainType entity);
        public Task<bool> SoftDelete(DomainType entity);
        public IQueryable<DomainType> FindById(long id);
        public IQueryable<DomainType> FindAll(int page, int limit, bool useFilter, FilterType fModel);
        public IQueryable<DomainType> Count();
        public IQueryable<DomainType> Filter(IQueryable<DomainType> query, FilterType fModel);
    }
}
