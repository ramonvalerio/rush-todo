using Microsoft.AspNetCore.Mvc;
using rush.todo.core.Application;
using System.Threading.Tasks;

namespace Rush.Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoAppService _todoAppService;

        public TodoController(ITodoAppService todoAppService)
        {
            _todoAppService = todoAppService;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Ok(await _todoAppService.GetAllAsync());
        }

        // GET: api/Todo/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _todoAppService.GetByIdAsync(id));
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            await _todoAppService.UpdateAsync(0, "Title", "Status");
            return Accepted();
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            await _todoAppService.AddAsync("Title", "Status");
            return Accepted();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _todoAppService.DeleteAsync(id);
            return Accepted();
        }
    }
}
