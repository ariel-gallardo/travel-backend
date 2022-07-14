using Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculosServices _services;
        public VehiculosController(IVehiculosServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Endpoint para crear un Vehiculo.
        /// </summary>
        /// <remarks>
        /// Endpoint para crear un Vehiculo.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     POST: /Vehiculo
        /// 
        /// </remarks>
        /// <response code="201">Ciudad creada exitosamente.</response>
        /// <response code="400">Errores de validacion.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.Input.Vehiculo t)
        {
            var output = await _services.Create(t);
            return StatusCode(output.StatusCode, output);
        }

        /// <summary>
        /// Endpoint para obtener una lista de 10 Vehiculo mediante paginacion.
        /// </summary>
        /// <remarks>
        /// Endpoint para obtener una lista de Vehiculo.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     GET: /Vehiculo/all/{page}
        /// 
        /// </remarks>
        /// <response code="200">Vehiculo encontrados.</response>
        /// <response code="404">No se encontro ningun Vehiculo en dicha pagina.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpGet("all/{page}")]
        public async Task<IActionResult> FindAll(int page)
        {
            var output = await _services.FindAll(page, 10);
            return StatusCode(output.StatusCode, output);
        }

        /// <summary>
        /// Endpoint para obtener un Vehiculo.
        /// </summary>
        /// <remarks>
        /// Endpoint para obtener un Vehiculo.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     GET: /Vehiculo/{id}
        /// 
        /// </remarks>
        /// <response code="200">Paise encontrado.</response>
        /// <response code="404">No se encontro ningun Vehiculo.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var output = await _services.FindById(id);
            return StatusCode(output.StatusCode, output);
        }

        /// <summary>
        /// Endpoint para eliminar logicamente un Vehiculo.
        /// </summary>
        /// <remarks>
        /// Endpoint para eliminar logicamente un Vehiculo.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     DELETE: /Vehiculo/{id}
        /// 
        /// </remarks>
        /// <response code="200">Vehiculo eliminado.</response>
        /// <response code="404">No se encontro ningun Vehiculo.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> LogicDelete(long id)
        {
            var output = await _services.Delete(id);
            return StatusCode(output.StatusCode, output);
        }


        /// <summary>
        /// Endpoint para editar la informacion de un Vehiculo.
        /// </summary>
        /// <remarks>
        /// Endpoint para editar la informacion de un Vehiculo.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     PUT: /Vehiculo/{id}
        /// 
        /// </remarks>
        /// <response code="200">Vehiculo editado correctamente.</response>
        /// <response code="404">No se encontro ningun Vehiculo.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Models.Input.Vehiculo t, long id)
        {
            var output = await _services.Update(t, id);
            return StatusCode(output.StatusCode, output);
        }
    }
}
