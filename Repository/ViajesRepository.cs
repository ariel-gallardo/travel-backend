using Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Models.Filter;
namespace Repository
{
    public class ViajesRepository : IViajesRepository
    {
        private readonly TravelContext _context;
        public IRepository<Models.Input.Viaje, Models.Domain.Viaje, ViajesFilter> _repository { get; }

        private UnitOfWork _unitOfWork;

        public ViajesRepository(TravelContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _repository = new Repository<Models.Input.Viaje, Models.Domain.Viaje, ViajesFilter>(_context);
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Count()
        {
            return await _repository.Count().CountAsync();
        }

        public async Task<bool> Create(Models.Domain.Viaje entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<List<Models.Domain.Viaje>> FindAll(int page, int limit, bool useFilter, ViajesFilter fModel)
        {
            return await _repository
                .FindAll(page, limit, useFilter, fModel)
                .Include(v => v.CiudadOrigen)
                .ThenInclude(c => c.Pais)
                .Include(v => v.CiudadDestino)
                .ThenInclude(c => c.Pais)
                .Include(v => v.VehiculoAsignado)
                .ThenInclude(v => v.Tipo)
                .ToListAsync();
        }

        public async Task<Models.Domain.Viaje> FindById(long id)
        {
            return await _repository
                .FindById(id)
                .Include(v => v.CiudadOrigen)
                .ThenInclude(c => c.Pais)
                .Include(v => v.CiudadDestino)
                .ThenInclude(c => c.Pais)
                .Include(v => v.VehiculoAsignado)
                .ThenInclude(v => v.Tipo)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SoftDelete(Models.Domain.Viaje entity)
        {
            if(await _unitOfWork.VehiculosRepository.FreeVehicle(entity.VehiculoId))
            {
                return await _repository.SoftDelete(entity);
            }
            return false;
        }

        public async Task<bool> Update(Models.Domain.Viaje entity)
        {
            return await _repository.Update(entity);
        }

        public async Task<bool> CanTravelToCity(Viaje entity)
        {
            var cOrigen = await _unitOfWork.CiudadRepository.FindById(entity.CiudadOrigenId);
            var cDestino = await _unitOfWork.CiudadRepository.FindById(entity.CiudadDestinoId);
            return cOrigen != null && cDestino != null;
        }
    }
}
