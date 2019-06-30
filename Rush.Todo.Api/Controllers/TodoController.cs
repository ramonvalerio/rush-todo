using Microsoft.AspNetCore.Mvc;
using Rush.Todo.Core.Application;
using System.Collections.Generic;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "Todo Item 1", "Todo Item 2" };
        }

        // GET: api/Todo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Todo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
