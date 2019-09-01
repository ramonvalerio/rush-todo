using System;

namespace mofo.todo.core.domain
{
    public abstract class AggregateRoot
    {
        public Guid Id { get; private set; }

        public AggregateRoot()
        {
            Id = Guid.NewGuid();
        }
    }
}