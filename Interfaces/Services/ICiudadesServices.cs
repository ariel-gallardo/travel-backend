using Models.Output;
namespace Interfaces.Services
{
    using Models.Filter;
    public interface ICiudadesServices : IRepository<Models.Input.Ciudad,Models.Domain.Ciudad, Models.Output.Ciudad, CiudadesFilter>
    {
    }
}
