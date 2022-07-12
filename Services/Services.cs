using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Models.Output;
using Repository;

namespace Services
{
    public class Services<InputType, OutputType, DomainType> : IServices<InputType, OutputType> where DomainType : Models.Domain.Entity
    {
        public readonly DbSet<DomainType> _repository;
        private readonly TravelContext _context;
        public Services(DbSet<DomainType> repository, TravelContext context)
        {
            this._repository = repository;
            this._context = context;
        }

        public async Task<Output<OutputType>> Create(InputType inputDto)
        {
            _repository.Add(null);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<Output> Delete(long id)
        {
            var exists = await Exists(id);
            var output = new Output();
            if(exists.StatusCode == 200)
            {
                var entity = await _repository.Where(p => p.Id == id && p.DeletedAt == null).FirstOrDefaultAsync();
               
                if(entity != null) entity.DeletedAt = DateTime.Now.ToUniversalTime();

                if (entity != null) _repository.Update(entity);
                await _context.SaveChangesAsync();

                output.Messages.Add($"{nameof(DomainType)} deleted successfully.");
                output.StatusCode = 200;
            }
            else
            {
                output.Messages = exists.Messages;
                output.StatusCode = exists.StatusCode;
            }

            return output;
        }

        public async Task<Output<bool>> Exists(long id)
        {
            var entity = await _repository.Where(p => p.Id == id && p.DeletedAt == null).FirstOrDefaultAsync();
            var output = new Output<bool>() { Data = entity != null };
            output.Messages.Add($"{nameof(DomainType)}{(output.Data ? " " : " not")} found.");
            output.StatusCode = output.Data ? 200 : 404;
            return output;
        }

        public async Task<Output<Pagination<OutputType>>> FindAll(long page, long limit)
        {
            throw new NotImplementedException();
        }

        public async Task<Output<OutputType>> FindById(long id)
        {
            var entity = await _repository.Where(p => p.Id == id && p.DeletedAt == null).FirstOrDefaultAsync();
            var output = new Output<OutputType>();
            output.Messages.Add($"{nameof(DomainType)}{(output.Data != null ? " " : " not")} found.");
            output.StatusCode = output.Data != null ? 200 : 404;
            return output;
        }

        public async Task<Output<OutputType>> Update(InputType inputDto)
        {
            throw new NotImplementedException();
        }
    }
}
