using Interfaces.Controllers;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Filter;

namespace Presentation.Controllers
{
    [Route($"api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PaisesController : ControllerBase, ControllerMethods<Models.Output.Pais, Models.Input.Pais, PaisesFilter>
    {
        private readonly IPaisesServices _services;
        public PaisesController(IPaisesServices services)
        {
            _services = services;
        }


        /// <summary>
        /// Endpoint para crear un pais.
        /// </summary>
        /// <remarks>
        /// Endpoint para crear un pais.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     POST: /Paises
        /// 
        /// </remarks>
        /// <response code="201">Ciudad creada exitosamente.</response>
        /// <response code="400">Errores de validacion.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Models.Input.Pais t)
        {
            var output = await _services.Create(t);
            return StatusCode(output.StatusCode, output);
        }

        /// <summary>
        /// Endpoint para obtener una lista de 10 paises mediante paginacion.
        /// </summary>
        /// <remarks>
        /// Endpoint para obtener una lista de paises.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     GET: /Paises/all/{page}
        /// 
        /// </remarks>
        /// <response code="200">Paises encontrados.</response>
        /// <response code="404">No se encontro ningun pais en dicha pagina.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpGet("all/{page}")]
        public async Task<IActionResult> FindAll(int page, [FromQuery] PaisesFilter fModel, [FromQuery] bool useFilter)
        {
            var output = await _services.FindAll(page, 10,useFilter, fModel);
            return StatusCode(output.StatusCode, output);
        }

        /// <summary>
        /// Endpoint para obtener un pais.
        /// </summary>
        /// <remarks>
        /// Endpoint para obtener un pais.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     GET: /Paises/{id}
        /// 
        /// </remarks>
        /// <response code="200">Paise encontrado.</response>
        /// <response code="404">No se encontro ningun pais.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var output = await _services.FindById(id);
            return StatusCode(output.StatusCode, output);
        }

        /// <summary>
        /// Endpoint para eliminar logicamente un pais.
        /// </summary>
        /// <remarks>
        /// Endpoint para eliminar logicamente un pais.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     DELETE: /Paises/{id}
        /// 
        /// </remarks>
        /// <response code="200">Pais eliminado.</response>
        /// <response code="404">No se encontro ningun pais.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> LogicDelete(long id)
        {
            var output = await _services.Delete(id);
            return StatusCode(output.StatusCode, output);
        }


        /// <summary>
        /// Endpoint para editar la informacion de un pais.
        /// </summary>
        /// <remarks>
        /// Endpoint para editar la informacion de un pais.
        /// El tipo de usuario no se encuentra logueado.
        /// 
        ///     PUT: /Paises/{id}
        /// 
        /// </remarks>
        /// <response code="200">Pais editado correctamente.</response>
        /// <response code="404">No se encontro ningun pais.</response>
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Models.Output.Output<bool>), StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] Models.Input.Pais t, long id)
        {
            var output = await _services.Update(t, id);
            return StatusCode(output.StatusCode, output);
        }
    }
}
