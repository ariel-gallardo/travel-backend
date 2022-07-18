using Microsoft.AspNetCore.Mvc;

namespace Interfaces.Controllers
{
    public interface ControllerMethods<OutputType, InputType, FilterModel>
    {
        Task<IActionResult> FindAll(int page, [FromQuery] FilterModel fModel, [FromQuery] bool useFilter = false);

        Task<IActionResult> FindById(long id);

        Task<IActionResult> Create([FromForm] InputType t);

        Task<IActionResult> Update([FromForm] InputType t, long id);

        Task<IActionResult> LogicDelete(long id);
    }
}
