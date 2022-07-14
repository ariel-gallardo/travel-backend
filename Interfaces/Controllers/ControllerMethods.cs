using Microsoft.AspNetCore.Mvc;

namespace Interfaces.Controllers
{
    public interface ControllerMethods<OutputType, InputType>
    {
        Task<IActionResult> FindAll(int page);

        Task<IActionResult> FindById(long id);

        Task<IActionResult> Create([FromForm] InputType t);

        Task<IActionResult> Update([FromForm] InputType t, long id);

        Task<IActionResult> LogicDelete(long id);
    }
}
