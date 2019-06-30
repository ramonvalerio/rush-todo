using Rush.Todo.Core.Domain.Todos;

namespace Rush.Todo.Core.Application
{
    public class TodoAppService : ITodoAppService
    {
        private readonly ITodoService _todoService;

        public TodoAppService(ITodoService todoService)
        {
            _todoService = todoService;
        }
    }
}