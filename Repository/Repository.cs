using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Interfaces.Repositories;

namespace Repository
{
    public class Repository<InputType, DomainType> : IRepository<InputType, DomainType> where DomainType : Models.Domain.Entity
    {
        public readonly DbSet<DomainType> _repository;
        public readonly TravelContext _context;
        public Repository(TravelContext context)
        {
            _context = context;
            _repository = (DbSet<DomainType>)context.GetDbSet(typeof(DomainType).ToString());
        }

        public async Task<bool> Create(DomainType entity)
        {
            _repository
                .Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Update(DomainType entity)
        {
            _repository
                .Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public IQueryable<DomainType> FindById(long id)
        =>
           _repository
           .Where(p => p.Id == id && p.DeletedAt == null)
           .AsQueryable();
        public IQueryable<DomainType> FindAll(int page, int limit)
        =>
             _repository
                .AsQueryable()
                .Where(p => p.DeletedAt == null)
                .Skip(page > 1 ? page * limit : 0)
                .Take(limit)
                .AsQueryable();
        public IQueryable<DomainType> Count()
        =>
          _repository
            .AsQueryable()
            .Where(p => p.DeletedAt == null)
            .AsQueryable();
        public async Task<bool> SoftDelete(DomainType entity)
        {
            if (entity.DeletedAt == null)
            {
                entity.DeletedAt = System.DateTime.Now.ToUniversalTime();
                _repository
                    .Update(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
