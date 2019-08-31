using mofo.todo.Common.Commands;

namespace mofo.todo.Core.Commands
{
    public class CreateTodoItem : ICommand
    {
        public string Title { get; private set; }

        public string Status { get; private set; }

        public CreateTodoItem(string title, string status)
        {
            Title = title;
            Status = status;
        }
    }
}