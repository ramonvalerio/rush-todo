using Microsoft.AspNetCore.Mvc;
using mofo.todo.core.Application;
using mofo.todo.Core.Domain.Todos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mofo.todo.Api.Controllers
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
        public IActionResult Get()
        {
            //return  Ok(await _todoAppService.GetAllAsyncreturn Accepted();
            var result = new List<TodoItem>();
            result.Add(new TodoItem("A", "Done"));
            result.Add(new TodoItem("B", "In Progress"));
            result.Add(new TodoItem("C", "In Progress"));
            result.Add(new TodoItem("D", "Waiting"));

            return Ok(result);
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
