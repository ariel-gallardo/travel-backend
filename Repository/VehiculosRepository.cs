using Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models.Filter;
namespace Repository
{
    public class VehiculosRepository : IVehiculosRepository
    {
        private readonly TravelContext _context;
        public IRepository<Models.Input.Vehiculo, Models.Domain.Vehiculo, VehiculosFilter> _repository { get; }

        private UnitOfWork _unitOfWork;

        public VehiculosRepository(TravelContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _repository = new Repository<Models.Input.Vehiculo, Models.Domain.Vehiculo, VehiculosFilter>(_context);
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

        public async Task<List<Models.Domain.Vehiculo>> FindAll(int page, int limit, bool useFilter, VehiculosFilter fModel)
        {
            return await _repository
                .FindAll(page, limit, useFilter, fModel)
                .Include(v => v.Tipo)
                .Where(v => v.Tipo.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<Models.Domain.Vehiculo> FindById(long id)
        {
            return await _repository
                .FindById(id)
                .Include(v => v.Tipo)
                .Where(v => v.Tipo.DeletedAt == null)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SoftDelete(Models.Domain.Vehiculo entity)
        {
            return await _repository.SoftDelete(entity);
        }

        public async Task<bool> Update(Models.Domain.Vehiculo entity)
        {
            return await _repository.Update(entity);
        }

        public async Task<bool> ItsBusy(long id)
        {
            var vehicle = await _repository.FindById(id).FirstOrDefaultAsync();
            if (vehicle == null)
                return true;
            else
                return vehicle.ItsBusy;
        }

        public async Task<bool> UseVehicle(long id)
        {
            var vehicle = await _repository.FindById(id).FirstOrDefaultAsync();
            if (vehicle == null)
                return false;
            else
            {
                if (vehicle.ItsBusy)
                    return false;
                else
                {
                    vehicle.ItsBusy = !vehicle.ItsBusy;
                    _context.Update(vehicle);
                    return await _context.SaveChangesAsync() > 0;
                }
            }
        }

        public async Task<bool> FreeVehicle(long id)
        {
            var vehicle = await FindById(id);
            if (vehicle.ItsBusy)
            {
                vehicle.ItsBusy = false;
                await _repository.Update(vehicle);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
