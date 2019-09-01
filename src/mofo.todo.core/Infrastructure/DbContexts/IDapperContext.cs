using mofo.todo.core.domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mofo.todo.core.Infrastructure.DbContexts
{
    public interface IDapperContext
    {
        Task<IEnumerable<T>> ExecuteManyAsync<T>(string sql) where T : AggregateRoot;

        Task<T> ExecuteSingleAsync<T>(string sql) where T : AggregateRoot;

        Task ExecuteAsync(string sql);
    }
}