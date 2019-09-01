using NServiceBus;

namespace mofo.todo.core.Domain.Todos.Commands
{
    public class DeleteTodoItem : ICommand
    {
        public int TodoId { get; set; }
        public DeleteTodoItem(int todoId)
        {
            TodoId = todoId;
        }
    }
}