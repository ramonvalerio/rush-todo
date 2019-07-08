using Rush.Todo.Common.Commands;

namespace rush.Todo.Core.Domain.Todos
{
    public class UpdateTodoItem : ICommand
    {
        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Status { get; private set; }

        public UpdateTodoItem(int todoId, string title, string status)
        {
            Id = todoId;
            Title = title;
            Status = status;
        }
    }
}