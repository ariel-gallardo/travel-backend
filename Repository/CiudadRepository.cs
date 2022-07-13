using Interfaces.Repositories;
using Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CiudadRepository : ICiudadRepository
    {
        private readonly TravelContext _context;
        public IRepository<Models.Input.Ciudad, Models.Domain.Ciudad> _repository { get; }

        public CiudadRepository(TravelContext context)
        {
            _context = context;
            _repository = new Repository<Models.Input.Ciudad, Models.Domain.Ciudad>(context);
        }

        public async Task<bool> Create(Ciudad entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<bool> Update(Ciudad entity)
        {
            return await _repository.Update(entity);
        }

        public async Task<bool> SoftDelete(Ciudad entity)
        {
            return await _repository.SoftDelete(entity);
        }

        public async Task<Ciudad> FindById(long id)
        {
            return await _repository.FindById(id).FirstOrDefaultAsync();
        }

        public async Task<List<Ciudad>> FindAll(int page, int limit)
        {
            return await _repository.FindAll(page, limit).ToListAsync();
        }

        public async Task<int> Count()
        {
            return await _repository.Count().CountAsync();
        }
    }
}