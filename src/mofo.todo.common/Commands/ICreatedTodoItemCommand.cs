using mofo.todo.Common.Commands;
using System;

namespace mofo.todo.common.Commands
{
    public interface ICreatedTodoItemCommand : ICommand
    {
         Guid TodoItemId { get; set; }
    }
}