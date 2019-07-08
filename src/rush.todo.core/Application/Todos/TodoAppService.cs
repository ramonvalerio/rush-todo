using rush.Todo.Core.Domain.Todos;
using Rush.Todo.Core.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rush.todo.core.Application
{
    public class TodoAppService : ITodoAppService
    {
        private readonly ITodoService _todoService;

        public TodoAppService(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await _todoService.GetAllAsync();
        }

        public async Task<TodoItem> GetByIdAsync(int todoId)
        {
            return await _todoService.GetByIdAsync(todoId);
        }

        public async Task<TodoItem> AddAsync(string title, string status)
        {
            //var command = new CreateTodoItem(title, status);
            //await _busClient.PublishAsync(command);

            var todoItem = new TodoItem(title, status);
            return await _todoService.AddAsync(todoItem);
        }

        public async Task<TodoItem> UpdateAsync(int todoId, string title, string status)
        {
            var todoItem = new TodoItem(title, status);
            return await _todoService.UpdateAsync(todoId, todoItem);
        }

        public async Task DeleteAsync(int todoId)
        {
            await _todoService.DeleteAsync(todoId);
        }
    }
}