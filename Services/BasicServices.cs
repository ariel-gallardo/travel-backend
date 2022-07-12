using AutoMapper;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Models.Output;
using Repository;

namespace Services
{
    public class BasicServices<InputType, DomainType, OutputType> : IServices<InputType, DomainType, OutputType> where DomainType : Models.Domain.Entity
    {
        public readonly DbSet<DomainType> _repository;
        private readonly TravelContext _context;
        private readonly IMapper _mapper;
        public BasicServices(TravelContext context, IMapper mapper)
        {
            var data = typeof(DomainType);
            this._repository = (DbSet<DomainType>)context.GetDbSet(typeof(DomainType).ToString());
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<Output<bool>> Create(InputType inputDto)
        {
            _repository.Add(_mapper.Map<InputType, DomainType>(inputDto));
            var output = new Output<bool>();
            try
            {
                await _context.SaveChangesAsync();
                output.Messages.Add($"{typeof(DomainType).Name} created successfully.");
                output.StatusCode = 201;
                output.Data = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                output.Messages.Add($"{typeof(DomainType).Name} cannot be created.");
                output.StatusCode = 422;
                output.Data = false;
            }

            return output;
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

                output.Messages.Add($"{typeof(DomainType).Name} deleted successfully.");
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
            output.Messages.Add($"{typeof(DomainType).Name}{(output.Data ? " " : " not")} found.");
            output.StatusCode = output.Data ? 200 : 404;
            return output;
        }

        public async Task<Output<Pagination<List<OutputType>>>> FindAll(int page, int limit)
        {
            var totalItems = await Count();
            var result = await _repository
                .AsQueryable()
                .Skip(page > 1 ? page*limit : 0)
                .Take(limit).ToListAsync();

            var output = new Output<Pagination<List<OutputType>>>();
            var pagination = new Pagination<List<OutputType>>();

            pagination.Page = page;
            pagination.Count = result.Count;
            pagination.BackPage = page > 1 && pagination.Count > 0;
            pagination.NextPage = page * limit < totalItems.Data;
            pagination.TotalItems = totalItems.Data;
            pagination.TotalPages = totalItems.Data / limit;

            if (result.Count > 0)
            {
                pagination.Data = _mapper.Map<List<DomainType>, List<OutputType>>(result);
                output.StatusCode = 200;
                output.Messages.Add($"{typeof(DomainType).Name} found.");
            }
            else
            {
                output.StatusCode = 404;
                output.Messages.Add($"{typeof(DomainType).Name} not found.");
            }

            output.Data = pagination;

            return output;
        }

        public async Task<Output<OutputType>> FindById(long id)
        {
            var entity = await _repository.Where(p => p.Id == id && p.DeletedAt == null).FirstOrDefaultAsync();
            var output = new Output<OutputType>();
            output.Messages.Add($"{typeof(DomainType).Name}{(entity != null ? "" : " not")} found.");
            output.StatusCode = entity != null ? 200 : 404;
            if(entity != null)
                output.Data = _mapper.Map<DomainType, OutputType>(entity);

            return output;
        }

        public async Task<Output<bool>> Update(InputType inputDto, long id)
        {
            var searched = await FindById(id);
            var output = new Output<bool>();
            if(searched.StatusCode == 200)
            {
                var domainData = _mapper.Map<InputType, DomainType>(inputDto);
                try
                {
                    var toUpdate = await _repository.FirstOrDefaultAsync(d => d.Id == id);
                    _repository.Update(_mapper.Map(inputDto, domainData));
                    await _context.SaveChangesAsync();
                    output.StatusCode = 204;
                    output.Data = true;
                    output.Messages.Add($"{typeof(DomainType).Name} updated successfully");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    output.StatusCode = 501;
                    output.Data = true;
                    output.Messages.Add($"{typeof(DomainType).Name} updated failed.");
                }
            }
            else
            {
                output.StatusCode = searched.StatusCode;
                output.Data = false;
                output.Messages = searched.Messages;
            }
            return output;
        }

        public async Task<Output<int>> Count()
        {
            var result = await _repository.AsQueryable().CountAsync();
            var output = new Output<int>() { Data = result, StatusCode = 200 };
            output.Messages.Add($"{result} {typeof(DomainType).Name} found.");
            return output;
        }
    }
}
