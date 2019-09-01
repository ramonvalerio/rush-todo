using NServiceBus;
using System;

namespace mofo.todo.Core.Commands
{
    public class CreateTodoItem : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; private set; }
        public string Status { get; private set; }

        public CreateTodoItem(string title, string status)
        {
            Title = title;
            Status = status;
        }
    }
}