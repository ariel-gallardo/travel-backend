namespace Interfaces.Repositories
{
    public interface IRepository<InputType,DomainType> where DomainType : Models.Domain.Entity 
    {
        public Task<bool> Create(DomainType entity);
        public Task<bool> Update(DomainType entity);
        public Task<bool> SoftDelete(DomainType entity);
        public IQueryable<DomainType> FindById(long id);
        public IQueryable<DomainType> FindAll(int page, int limit);
        public IQueryable<DomainType> Count();
    }
}
