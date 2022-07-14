using Interfaces.Controllers;
using Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route($"api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ViajesController : ControllerBase, ControllerMethods<Models.Output.Viaje, Models.Input.Viaje>
    {
        private readonly IViajesServices _services;
        public ViajesController(IViajesServices services)
        {
            _services = services;
        }


        /// <summary>
        /// Endpoint para crear un Viaje.
        /// </summary>
        /// <remarks>
        /// Endpoint para crear un Viaje.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     POST: /Viajes
        /// 
        /// </remarks>
        /// <response code="201">Ciudad creada exitosamente.</response>
        /// <response code="400">Errores de validacion.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.Input.Viaje t)
        {
            var output = await _services.Create(t);
            return StatusCode(output.StatusCode, output);
        }

        /// <summary>
        /// Endpoint para obtener una lista de 10 Viajes mediante paginacion.
        /// </summary>
        /// <remarks>
        /// Endpoint para obtener una lista de Viajes.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     GET: /Viajes/all/{page}
        /// 
        /// </remarks>
        /// <response code="200">Viajes encontrados.</response>
        /// <response code="404">No se encontro ningun Viaje en dicha pagina.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpGet("all/{page}")]
        public async Task<IActionResult> FindAll(int page)
        {
            var output = await _services.FindAll(page, 10);
            return StatusCode(output.StatusCode, output);
        }

        /// <summary>
        /// Endpoint para obtener un Viaje.
        /// </summary>
        /// <remarks>
        /// Endpoint para obtener un Viaje.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     GET: /Viajes/{id}
        /// 
        /// </remarks>
        /// <response code="200">Paise encontrado.</response>
        /// <response code="404">No se encontro ningun Viaje.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var output = await _services.FindById(id);
            return StatusCode(output.StatusCode, output);
        }

        /// <summary>
        /// Endpoint para eliminar logicamente un Viaje.
        /// </summary>
        /// <remarks>
        /// Endpoint para eliminar logicamente un Viaje.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     DELETE: /Viajes/{id}
        /// 
        /// </remarks>
        /// <response code="200">Viaje eliminado.</response>
        /// <response code="404">No se encontro ningun Viaje.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> LogicDelete(long id)
        {
            var output = await _services.Delete(id);
            return StatusCode(output.StatusCode, output);
        }


        /// <summary>
        /// Endpoint para editar la informacion de un Viaje.
        /// </summary>
        /// <remarks>
        /// Endpoint para editar la informacion de un Viaje.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     PUT: /Viajes/{id}
        /// 
        /// </remarks>
        /// <response code="200">Viaje editado correctamente.</response>
        /// <response code="404">No se encontro ningun Viaje.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Models.Input.Viaje t, long id)
        {
            var output = await _services.Update(t, id);
            return StatusCode(output.StatusCode, output);
        }
    }
}
