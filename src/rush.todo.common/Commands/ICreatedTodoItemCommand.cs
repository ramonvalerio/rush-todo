using Rush.Todo.Common.Commands;
using System;

namespace rush.todo.common.Commands
{
    public interface ICreatedTodoItemCommand : ICommand
    {
         Guid TodoItemId { get; set; }
    }
}