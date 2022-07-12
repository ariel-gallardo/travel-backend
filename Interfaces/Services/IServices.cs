using Models.Output;

namespace Interfaces.Services
{
    public interface IServices<Input,ResponseType>
    {
        public Task<Output<ResponseType>> Create(Input inputDto);
        public Task<Output<ResponseType>> Update(Input inputDto);
        public Task<Output> Delete(long id);
        public Task<Output<Boolean>> Exists(long id);
        public Task<Output<ResponseType>> FindById(long id);
        public Task<Output<Pagination<ResponseType>>> FindAll(long page, long limit);
    }
}
