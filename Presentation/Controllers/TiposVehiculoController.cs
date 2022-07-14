using Interfaces.Controllers;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route($"api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TiposVehiculoController : ControllerBase, ControllerMethods<Models.Output.TipoVehiculo, Models.Input.TipoVehiculo>
    {
        private readonly ITiposVehiculoServices _services;
        public TiposVehiculoController(ITiposVehiculoServices services)
        {
            _services = services;
        }


        /// <summary>
        /// Endpoint para crear un TipoVehiculo.
        /// </summary>
        /// <remarks>
        /// Endpoint para crear un TipoVehiculo.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     POST: /TiposVehiculo
        /// 
        /// </remarks>
        /// <response code="201">Ciudad creada exitosamente.</response>
        /// <response code="400">Errores de validacion.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.Input.TipoVehiculo t)
        {
            var output = await _services.Create(t);
            return StatusCode(output.StatusCode, output);
        }

        /// <summary>
        /// Endpoint para obtener una lista de 10 TiposVehiculo mediante paginacion.
        /// </summary>
        /// <remarks>
        /// Endpoint para obtener una lista de TiposVehiculo.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     GET: /TiposVehiculo/all/{page}
        /// 
        /// </remarks>
        /// <response code="200">TiposVehiculo encontrados.</response>
        /// <response code="404">No se encontro ningun TipoVehiculo en dicha pagina.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpGet("all/{page}")]
        public async Task<IActionResult> FindAll(int page)
        {
            var output = await _services.FindAll(page, 10);
            return StatusCode(output.StatusCode, output);
        }

        /// <summary>
        /// Endpoint para obtener un TipoVehiculo.
        /// </summary>
        /// <remarks>
        /// Endpoint para obtener un TipoVehiculo.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     GET: /TiposVehiculo/{id}
        /// 
        /// </remarks>
        /// <response code="200">Paise encontrado.</response>
        /// <response code="404">No se encontro ningun TipoVehiculo.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var output = await _services.FindById(id);
            return StatusCode(output.StatusCode, output);
        }

        /// <summary>
        /// Endpoint para eliminar logicamente un TipoVehiculo.
        /// </summary>
        /// <remarks>
        /// Endpoint para eliminar logicamente un TipoVehiculo.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     DELETE: /TiposVehiculo/{id}
        /// 
        /// </remarks>
        /// <response code="200">TipoVehiculo eliminado.</response>
        /// <response code="404">No se encontro ningun TipoVehiculo.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> LogicDelete(long id)
        {
            var output = await _services.Delete(id);
            return StatusCode(output.StatusCode, output);
        }


        /// <summary>
        /// Endpoint para editar la informacion de un TipoVehiculo.
        /// </summary>
        /// <remarks>
        /// Endpoint para editar la informacion de un TipoVehiculo.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     PUT: /TiposVehiculo/{id}
        /// 
        /// </remarks>
        /// <response code="200">TipoVehiculo editado correctamente.</response>
        /// <response code="404">No se encontro ningun TipoVehiculo.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Models.Input.TipoVehiculo t, long id)
        {
            var output = await _services.Update(t, id);
            return StatusCode(output.StatusCode, output);
        }
    }
}
