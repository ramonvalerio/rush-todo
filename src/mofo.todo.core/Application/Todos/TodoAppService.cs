using mofo.todo.Core.Commands;
using mofo.todo.Core.Domain.Todos;
using NServiceBus;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mofo.todo.core.Application
{
    public class TodoAppService : ITodoAppService
    {
        private readonly ITodoService _todoService;
        private readonly EndpointConfiguration _endPointConfiguration;

        public TodoAppService(ITodoService todoService)
        {
            _todoService = todoService;

            _endPointConfiguration = new EndpointConfiguration("Mofo.Todo");
            _endPointConfiguration.UsePersistence<NHibernatePersistence>();
            _endPointConfiguration.EnableInstallers();
            _endPointConfiguration.SagaPlugin("OpenPlatform.ServiceControl");
            _endPointConfiguration.SendFailedMessagesTo("ExemploSaga.Pedidos.Errors");

            var transport = _endPointConfiguration.UseTransport<RabbitMQTransport>();
            transport.ConnectionString("host=localhost");
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
            var command = new CreateTodoItem(title, status);
            //await _endPointConfiguration.SendLocal(command);

            throw new System.Exception();
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