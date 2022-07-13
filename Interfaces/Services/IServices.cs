using Models.Output;

namespace Interfaces.Services
{
    public interface IRepository<InputType,DomainType,OutputType> where DomainType : Models.Domain.Entity 
    {
        public Task<Output<bool>> Create(InputType inputDto);
        public Task<Output<bool>> Update(InputType inputDto, long id);
        public Task<Output> Delete(long id);
        public Task<Output<Boolean>> Exists(long id);
        public Task<Output<OutputType>> FindById(long id);
        public Task<Output<Pagination<List<OutputType>>>> FindAll(int page, int limit);
        public Task<Output<int>> Count();
    }
}
