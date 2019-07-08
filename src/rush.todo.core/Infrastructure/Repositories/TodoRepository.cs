using rush.todo.core.Infrastructure.DbContexts;
using rush.Todo.Core.Domain.Todos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rush.todo.core.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IDapperContext _context;

        public TodoRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            string sql = "SELECT Id, Title, Status FROM TODO_ITEM";
            return await _context.ExecuteManyAsync<TodoItem>(sql);
        }

        public async Task<TodoItem> GetByIdAsync(int todoId)
        {
            string sql = $"SELECT Id, Title, Status FROM TODO_ITEM WHERE Id = {todoId}";
            return await _context.ExecuteSingleAsync<TodoItem>(sql);
        }

        public async Task<TodoItem> AddAsync(TodoItem todo)
        {
            string sql = $"INSERT INTO TODO_ITEM (Id, Title, Status) VALUES({todo.Id}, {todo.Title}, {todo.Status})";
            return await _context.ExecuteSingleAsync<TodoItem>(sql);
        }

        public async Task<TodoItem> UpdateAsync(int todoId, TodoItem todo)
        {
            string sql = $"UPDATE TODO_ITEM SET Title = {todo.Title}, Status = {todo.Status} WHERE Id = {todoId}";
            return await _context.ExecuteSingleAsync<TodoItem>(sql);
        }

        public async Task DeleteAsync(int todoId)
        {
            string sql = $"DELETE FROM TODO_ITEM WHERE Id = {todoId}";
            await _context.ExecuteSingleAsync<TodoItem>(sql);
        }
    }
}
