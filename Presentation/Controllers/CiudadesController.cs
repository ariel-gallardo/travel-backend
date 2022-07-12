using Interfaces.Controllers;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route($"api/[controller]")]
    [ApiController]
    public class CiudadesController : ControllerBase, ControllerMethods<Models.Output.Ciudad, Models.Input.Ciudad>
    {
        private readonly ICiudadesServices _services;
        public CiudadesController(ICiudadesServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.Input.Ciudad t)
        {
            var output = await _services.Create(t);
            return StatusCode(output.StatusCode, output);
        }

        [HttpGet("all/{page}")]
        public async Task<IActionResult> FindAll(int page)
        {
            var output = await _services.FindAll(page, 10);
            return StatusCode(output.StatusCode,output);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var output = await _services.FindById(id);
            return StatusCode(output.StatusCode, output);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> LogicDelete(long id)
        {
            var output = await _services.Delete(id);
            return StatusCode(output.StatusCode, output);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Models.Input.Ciudad t, long id)
        {
            var output = await _services.Update(t, id);
            return StatusCode(output.StatusCode, output);
        }
    }
}
