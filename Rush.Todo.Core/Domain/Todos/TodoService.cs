using Rush.Todo.Core.Domain.Todos;
using Rush.Todo.Core.Infrastructure;

namespace Rush.Todo.Core.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
    }
}