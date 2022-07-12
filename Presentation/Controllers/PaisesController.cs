using Interfaces.Controllers;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route($"api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase, ControllerMethods<Models.Output.Pais, Models.Input.Pais>
    {
        private readonly IPaisesServices _services;
        public PaisesController(IPaisesServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.Input.Pais t)
        {
            var output = await _services.Create(t);
            return StatusCode(output.StatusCode, output);
        }

        [HttpGet("{page}")]
        public async Task<IActionResult> FindAll(int page)
        {
            var output = await _services.FindAll(page, 10);
            return StatusCode(output.StatusCode, output);
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
        public async Task<IActionResult> Update([FromBody] Models.Input.Pais t, long id)
        {
            var output = await _services.Update(t, id);
            return StatusCode(output.StatusCode, output);
        }
    }
}
