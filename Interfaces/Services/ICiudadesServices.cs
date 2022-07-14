using Models.Output;

namespace Interfaces.Services
{
    public interface ICiudadesServices : IRepository<Models.Input.Ciudad,Models.Domain.Ciudad, Models.Output.Ciudad>
    {
    }
}
