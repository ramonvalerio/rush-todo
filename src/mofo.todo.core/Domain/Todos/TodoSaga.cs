using System.Threading.Tasks;
using mofo.todo.Core.Commands;
using mofo.todo.Core.Events;
using NServiceBus;

namespace mofo.todo.core.Domain.Todos
{
    public class TodoSaga : Saga<TodoSagaData>,
        IAmStartedByMessages<CreateTodoItem>,
        IHandleMessages<TodoItemCreated>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<TodoSagaData> mapper)
        {
            mapper.ConfigureMapping<CreateTodoItem>(message => message.Id).ToSaga(saga => saga.TodoId);
            mapper.ConfigureMapping<CreateTodoItem>(message => message.Title).ToSaga(saga => saga.TodoTitle);
        }

        public Task Handle(TodoItemCreated message, IMessageHandlerContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(CreateTodoItem message, IMessageHandlerContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}