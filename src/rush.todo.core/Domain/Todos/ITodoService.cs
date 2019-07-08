using rush.Todo.Core.Domain.Todos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rush.Todo.Core.Domain.Todos
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem> GetByIdAsync(int todoId);
        Task<TodoItem> AddAsync(TodoItem todo);
        Task<TodoItem> UpdateAsync(int todoId, TodoItem todo);
        Task DeleteAsync(int todoId);
    }
}