using Interfaces.Controllers;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route($"api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CiudadesController : ControllerBase, ControllerMethods<Models.Output.Ciudad, Models.Input.Ciudad>
    {
        private readonly ICiudadesServices _services;
        public CiudadesController(ICiudadesServices services)
        {
            _services = services;
        }


        /// <summary>
        /// Endpoint para crear un ciudad.
        /// </summary>
        /// <remarks>
        /// Endpoint para crear un ciudad.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     POST: /Ciudades
        /// 
        /// </remarks>
        /// <response code="201">Ciudad creada exitosamente.</response>
        /// <response code="400">Errores de validacion.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.Input.Ciudad t)
        {
            var output = await _services.Create(t);
            return StatusCode(output.StatusCode, output);
        }

        /// <summary>
        /// Endpoint para obtener una lista de 10 Ciudades mediante paginacion.
        /// </summary>
        /// <remarks>
        /// Endpoint para obtener una lista de Ciudades.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     GET: /Ciudades/all/{page}
        /// 
        /// </remarks>
        /// <response code="200">Ciudades encontrados.</response>
        /// <response code="404">No se encontro ningun ciudad en dicha pagina.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpGet("all/{page}")]
        public async Task<IActionResult> FindAll(int page)
        {
            var output = await _services.FindAll(page, 10);
            return StatusCode(output.StatusCode, output);
        }

        /// <summary>
        /// Endpoint para obtener un ciudad.
        /// </summary>
        /// <remarks>
        /// Endpoint para obtener un ciudad.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     GET: /Ciudades/{id}
        /// 
        /// </remarks>
        /// <response code="200">Paise encontrado.</response>
        /// <response code="404">No se encontro ningun ciudad.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var output = await _services.FindById(id);
            return StatusCode(output.StatusCode, output);
        }

        /// <summary>
        /// Endpoint para eliminar logicamente un ciudad.
        /// </summary>
        /// <remarks>
        /// Endpoint para eliminar logicamente un ciudad.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     DELETE: /Ciudades/{id}
        /// 
        /// </remarks>
        /// <response code="200">ciudad eliminado.</response>
        /// <response code="404">No se encontro ningun ciudad.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> LogicDelete(long id)
        {
            var output = await _services.Delete(id);
            return StatusCode(output.StatusCode, output);
        }


        /// <summary>
        /// Endpoint para editar la informacion de un ciudad.
        /// </summary>
        /// <remarks>
        /// Endpoint para editar la informacion de un ciudad.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     PUT: /Ciudades/{id}
        /// 
        /// </remarks>
        /// <response code="200">ciudad editado correctamente.</response>
        /// <response code="404">No se encontro ningun ciudad.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Models.Input.Ciudad t, long id)
        {
            var output = await _services.Update(t, id);
            return StatusCode(output.StatusCode, output);
        }
    }
}
