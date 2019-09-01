using mofo.todo.Core.Domain.Todos;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace mofo.todo.core.Domain.Todos.Handlers
{
    class UpdateTodoItemHandler : IHandleMessages<TodoItemUpdated>
    {
        public Task Handle(TodoItemUpdated message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }
    }
}