using mofo.todo.core.domain;

namespace mofo.todo.Core.Domain.Todos
{
    public class TodoItem : AggregateRoot
    {
        public string Title { get; set; }

        public string Status { get; set; }

        public TodoItem(string title, string status)
        {
            Title = title;
            Status = status;
        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(this.Title))
                return false;

            if (string.IsNullOrWhiteSpace(this.Status))
                return false;

            return true;
        }
    }
}
