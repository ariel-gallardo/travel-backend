using Interfaces.Repositories;
using Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models.Filter;
namespace Repository
{
    public class PaisRepository : IPaisRepository
    {
        private readonly TravelContext _context;
        public IRepository<Models.Input.Pais, Models.Domain.Pais, PaisesFilter> _repository { get; }

        private UnitOfWork _unitOfWork;

        public PaisRepository(TravelContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _repository = new Repository<Models.Input.Pais, Models.Domain.Pais, PaisesFilter>(_context);
            _unitOfWork = unitOfWork;
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
            return await _repository
              .FindById(id)
              .Include(p => p.Ciudades)
              .Where(p => p.Ciudades.All(c => c.DeletedAt == null))
              .FirstOrDefaultAsync();
        }

        public async Task<List<Pais>> FindAll(int page, int limit, bool useFilter, PaisesFilter fModel)
        {
            var result =  await _repository
                .FindAll(page, limit, useFilter, fModel)
                .Include(p => p.Ciudades)
                .Where(p => p.Ciudades.All(c => c.DeletedAt == null && p.Id == c.PaisId))
                .ToListAsync();

            return result;
        }

        public async Task<int> Count()
        {
            return await _repository.Count().CountAsync();
        }
    }
}
