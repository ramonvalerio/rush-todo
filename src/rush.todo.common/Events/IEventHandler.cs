using System.Threading.Tasks;

namespace rush.todo.common.Events
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}