namespace Interfaces.Services
{
    using Models.Output;
    public interface IPronosticoServices
    {
        public Task<Output<Pronostico>> ConsultarPronostico(Models.Domain.Ciudad ciudad);
    }
}
