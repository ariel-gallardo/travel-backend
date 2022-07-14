using AutoMapper;
using Interfaces.Services;

namespace Services
{
    public class PronosticoServices : IPronosticoServices
    {
        private readonly HttpClient _http;
        private readonly IMapper _mapper;

        public PronosticoServices(HttpClient httpClient, IMapper mapper)
        {
            _http = httpClient;
            _mapper = mapper;
        }
        public async Task<Models.Output.Output<Models.Output.Pronostico>> ConsultarPronostico(Models.Domain.Ciudad ciudad)
        {
            var output = new Models.Output.Output<Models.Output.Pronostico>();

            var httpResponse = await _http.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={ciudad.Nombre},AR&APPID=e4ca409d3f12cba782e9b00911483d0c");
            
            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsAsync<Models.Domain.ExternalPronostico>();
                if (response != null)
                {
                    var pronostico =  _mapper.Map<Models.Domain.ExternalPronostico, Models.Domain.Pronostico>(response);
                    pronostico.Ciudad = ciudad;
                    output.Messages.Add($"Pronostico encontrado para la ciudad {ciudad.Nombre}");
                    output.StatusCode = 200;
                    output.Data = _mapper.Map<Models.Domain.Pronostico,Models.Output.Pronostico>(pronostico);
                }
                else
                {
                    output.StatusCode = 404;
                    output.Messages.Add($"No se encuentra el pronostico para la ciudad {ciudad.Nombre}");
                }
            }
            else
            {
                output.StatusCode = 404;
                output.Messages.Add($"No se encuentra el pronostico para la ciudad {ciudad.Nombre}");
            }

            return output;
        }
    }
}
