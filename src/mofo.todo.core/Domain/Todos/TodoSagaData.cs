using NServiceBus;
using System;

namespace mofo.todo.core.Domain.Todos
{
    public class TodoSagaData : ContainSagaData
    {
        public virtual Guid TodoId { get; set; }

        public string TodoTitle { get; set; }
    }
}