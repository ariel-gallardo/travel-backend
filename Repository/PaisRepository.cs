using Interfaces.Repositories;
using Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PaisRepository : IPaisRepository
    {
        private readonly TravelContext _context;
        public IRepository<Models.Input.Pais, Models.Domain.Pais> _repository { get; }

        public PaisRepository(TravelContext context)
        {
            _context = context;
            _repository = new Repository<Models.Input.Pais, Models.Domain.Pais>(_context);
        }

        public async Task<bool> Create(Pais entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<bool> Update(Pais entity)
        {
            return await _repository.Update(entity);
        }

        public async Task<bool> SoftDelete(Pais entity)
        {
            return await _repository.SoftDelete(entity);
        }

        public async Task<Pais> FindById(long id)
        {
            return await _repository.FindById(id).FirstOrDefaultAsync();
        }

        public async Task<List<Pais>> FindAll(int page, int limit)
        {
            return await _repository.FindAll(page, limit).ToListAsync();
        }

        public async Task<int> Count()
        {
            return await _repository.Count().CountAsync();
        }
    }
}
