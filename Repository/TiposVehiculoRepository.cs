using Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models.Filter;
using Models.Domain;

namespace Repository
{
    public class TiposVehiculoRepository : ITiposVehiculoRepository
    {
        private readonly TravelContext _context;
        public IRepository<Models.Input.TipoVehiculo, Models.Domain.TipoVehiculo> _repository { get; }

        private UnitOfWork _unitOfWork;

        public TiposVehiculoRepository(TravelContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _repository = new Repository<Models.Input.TipoVehiculo, Models.Domain.TipoVehiculo>(_context);
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
            var query = _repository
                .FindAll(page, limit)
                .Include(tv => tv.Vehiculos)
                .Where(tv => tv.Vehiculos.All(v => v.DeletedAt == null));

                return await Filter(useFilter, fModel, query).ToListAsync();
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

        public IQueryable<TipoVehiculo> Filter(bool useFilter, TiposVehiculoFilter fModel, IQueryable<TipoVehiculo> query)
        {
            return query;
        }
    }
}
