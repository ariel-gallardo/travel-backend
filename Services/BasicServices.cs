using AutoMapper;
using Interfaces.Services;
using Models.Output;
using Repository;

namespace Services
{
    public class BasicServices<InputType, DomainType, OutputType> : IRepository<InputType, DomainType, OutputType> where DomainType : Models.Domain.Entity
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly dynamic _repository;

        public BasicServices(
            IMapper mapper,
            UnitOfWork unitOfWork
        )
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._repository = _unitOfWork.SelectRepository(typeof(DomainType));

        }

        public async Task<Output<bool>> Create(InputType inputDto)
        {
            
            var output = new Output<bool>();

            try
            {
                var result = await _repository.Create(_mapper.Map<InputType, DomainType>(inputDto));
                output.Messages.Add($"{typeof(DomainType).Name} created successfully.");
                output.StatusCode = 201;
                output.Data = true;
            }
            catch (Exception e)
            {
                output.Messages.Add($"{typeof(DomainType).Name} cannot be created.");
                output.Messages.Add(e.Message);
                output.StatusCode = 400;
                output.Data = false;
            }

            return output;
        }

        public async Task<Output> Delete(long id)
        {
            var output = new Output();

            var entity = await _repository.FindById(id);
            var result = await _repository.SoftDelete(entity);

            output.Messages.Add(
               result 
                ? $"{typeof(DomainType).Name} deleted successfully."
                : $"{typeof(DomainType).Name} not found."
            );

            output.StatusCode = result ? 200 : 404;

            return output;
        }

        public async Task<Output<bool>> Exists(long id)
        {
            var entity = await _repository.FindById(id);
            var output = new Output<bool>() { Data = entity != null };
            output.Messages.Add($"{typeof(DomainType).Name}{(output.Data ? " " : " not")} found.");
            output.StatusCode = output.Data ? 200 : 404;
            return output;
        }

        public async Task<Output<Pagination<List<OutputType>>>> FindAll(int page, int limit)
        {
            var totalItems = await Count();
            var result = await _repository.FindAll(page, limit);

            var output = new Output<Pagination<List<OutputType>>>();
            var pagination = new Pagination<List<OutputType>>();

            pagination.Page = page;
            pagination.Count = result.Count;
            pagination.BackPage = page > 1 && pagination.Count > 0;
            pagination.NextPage = page * limit < totalItems.Data;
            pagination.TotalItems = totalItems.Data;
            pagination.TotalPages = totalItems.Data / limit > 0 ? totalItems.Data / limit : 1;

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
            var entity = await _repository.FindById(id);

            var output = new Output<OutputType>();
            output.Messages.Add($"{typeof(DomainType).Name}{(entity != null ? "" : " not")} found.");
            output.StatusCode = entity != null ? 200 : 404;
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
                    await _repository.Update(_mapper.Map(inputDto, domainData));
                    output.StatusCode = 204;
                    output.Data = true;
                    output.Messages.Add($"{typeof(DomainType).Name} updated successfully");
                }
                catch(Exception e)
                {
                    output.StatusCode = 400;
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
            var result = await _repository.Count();
            var output = new Output<int>() { Data = result, StatusCode = 200 };
            output.Messages.Add($"{result} {typeof(DomainType).Name} found.");
            return output;
        }
    }
}
