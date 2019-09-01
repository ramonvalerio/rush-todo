using mofo.todo.Core.Events;
using NServiceBus;
using System.Threading.Tasks;

namespace mofo.todo.core.Domain.Todos.Handlers
{
    public class CreateTodoItemHandler : IHandleMessages<TodoItemCreated>
    {
        public Task Handle(TodoItemCreated message, IMessageHandlerContext context)
        {
            return Task.FromResult(0);
        }
    }
}