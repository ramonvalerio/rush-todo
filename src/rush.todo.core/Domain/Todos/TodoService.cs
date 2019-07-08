using System.Collections.Generic;
using System.Threading.Tasks;

namespace rush.Todo.Core.Domain.Todos
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await _todoRepository.GetAllAsync();
        }

        public async Task<TodoItem> GetByIdAsync(int todoId)
        {
            return await _todoRepository.GetByIdAsync(todoId);
        }

        public async Task<TodoItem> AddAsync(TodoItem todo)
        {
            return await _todoRepository.AddAsync(todo);
        }

        public async Task<TodoItem> UpdateAsync(int todoId, TodoItem todo)
        {
            return await _todoRepository.UpdateAsync(todoId, todo);
        }

        public async Task DeleteAsync(int todoId)
        {
            await _todoRepository.DeleteAsync(todoId);
            return;
        }
    }
}