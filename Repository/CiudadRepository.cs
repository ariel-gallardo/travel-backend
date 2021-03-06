using Interfaces.Repositories;
using Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models.Filter;
namespace Repository
{
    public class CiudadRepository : ICiudadRepository
    {
        private readonly TravelContext _context;
        public IRepository<Models.Input.Ciudad, Models.Domain.Ciudad> _repository { get; }

        private UnitOfWork _unitOfWork;


        public CiudadRepository(TravelContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _repository = new Repository<Models.Input.Ciudad, Models.Domain.Ciudad>(context);
            _unitOfWork = unitOfWork;
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
            var ciudad =
            await _repository
                .FindById(id)
                .Include(c => c.Pais)
                .Where(c => c.Pais.DeletedAt == null)
                .FirstOrDefaultAsync();

            return ciudad;
        }

        public async Task<List<Ciudad>> FindAll(int page, int limit, bool useFilter, CiudadesFilter fModel)
        {
            var query = _repository
                .FindAll(page, limit)
                .Include(p => p.Pais)
                .Where(c => c.Pais.DeletedAt == null);

            return await Filter(useFilter,fModel,query).ToListAsync();
        }

        public async Task<int> Count()
        {
            return await _repository.Count()
                .Include(c => c.Pais)
                .Where(c => c.Pais.DeletedAt == null)
                .CountAsync();
        }

        public IQueryable<Ciudad> Filter(bool useFilter, CiudadesFilter fModel, IQueryable<Ciudad> query)
        {
            return query;
        }
    }
}