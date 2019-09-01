using mofo.todo.Core.Events;
using NServiceBus;
using System.Threading.Tasks;

namespace mofo.todo.core.Domain.Todos.Handlers
{
    class DeleteTodoItemHandler : IHandleMessages<TodoItemDeleted>
    {
        public Task Handle(TodoItemDeleted message, IMessageHandlerContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
