using System;

namespace rush.todo.common
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