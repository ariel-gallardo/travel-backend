using Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class VehiculosRepository : IVehiculosRepository
    {
        private readonly TravelContext _context;
        public IRepository<Models.Input.Vehiculo, Models.Domain.Vehiculo> _repository { get; }

        private UnitOfWork _unitOfWork;

        public VehiculosRepository(TravelContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _repository = new Repository<Models.Input.Vehiculo, Models.Domain.Vehiculo>(_context);
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Count()
        {
            return await _repository.Count().CountAsync();
        }

        public async Task<bool> Create(Models.Domain.Vehiculo entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<List<Models.Domain.Vehiculo>> FindAll(int page, int limit)
        {
            return await _repository.FindAll(page, limit).ToListAsync();
        }

        public async Task<Models.Domain.Vehiculo> FindById(long id)
        {
            return await _repository.FindById(id).FirstOrDefaultAsync();
        }

        public async Task<bool> SoftDelete(Models.Domain.Vehiculo entity)
        {
            return await _repository.SoftDelete(entity);
        }

        public async Task<bool> Update(Models.Domain.Vehiculo entity)
        {
            return await _repository.Update(entity);
        }
    }
}
