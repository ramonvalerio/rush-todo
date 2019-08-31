using mofo.todo.Core.Domain.Todos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mofo.todo.core.Application
{
    public interface ITodoAppService
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem> GetByIdAsync(int todoId);
        Task<TodoItem> AddAsync(string title, string status);
        Task<TodoItem> UpdateAsync(int todoId, string title, string status);
        Task DeleteAsync(int todoId);
    }
}