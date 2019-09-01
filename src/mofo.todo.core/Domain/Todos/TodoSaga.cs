using mofo.todo.Core.Commands;
using NServiceBus;

namespace mofo.todo.core.Domain.Todos
{
    public class TodoSaga : Saga<TodoSagaData>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<TodoSagaData> mapper)
        {
            mapper.ConfigureMapping<CreateTodoItem>(message => message.Id).ToSaga(saga => saga.TodoId);
            mapper.ConfigureMapping<CreateTodoItem>(message => message.Title).ToSaga(saga => saga.TodoTitle);
        }
    }
}