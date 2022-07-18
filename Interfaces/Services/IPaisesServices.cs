namespace Interfaces.Services
{
    using Models.Filter;
    public interface IPaisesServices : IRepository<Models.Input.Pais, Models.Domain.Pais, Models.Output.Pais, PaisesFilter>
    {

    }
}
