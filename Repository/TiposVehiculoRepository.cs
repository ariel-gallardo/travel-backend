using Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models.Filter;
namespace Repository
{
    public class TiposVehiculoRepository : ITiposVehiculoRepository
    {
        private readonly TravelContext _context;
        public IRepository<Models.Input.TipoVehiculo, Models.Domain.TipoVehiculo, TiposVehiculoFilter> _repository { get; }

        private UnitOfWork _unitOfWork;

        public TiposVehiculoRepository(TravelContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _repository = new Repository<Models.Input.TipoVehiculo, Models.Domain.TipoVehiculo, TiposVehiculoFilter>(_context);
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Count()
        {
            return await _repository.Count().CountAsync();
        }

        public async Task<bool> Create(Models.Domain.TipoVehiculo entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<List<Models.Domain.TipoVehiculo>> FindAll(int page, int limit, bool useFilter, TiposVehiculoFilter fModel)
        {
            return await _repository
                .FindAll(page, limit, useFilter, fModel)
                .Include(tv => tv.Vehiculos)
                .Where(tv => tv.Vehiculos.All(v => v.DeletedAt == null))
                .ToListAsync();
        }

        public async Task<Models.Domain.TipoVehiculo> FindById(long id)
        {
            return await _repository
                .FindById(id)
                .Include(tv => tv.Vehiculos)
                .Where(tv => tv.Vehiculos.All(v => v.DeletedAt == null))
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SoftDelete(Models.Domain.TipoVehiculo entity)
        {
            return await _repository.SoftDelete(entity);
        }

        public async Task<bool> Update(Models.Domain.TipoVehiculo entity)
        {
            return await _repository.Update(entity);
        }
    }
}
