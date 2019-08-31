using System.Threading.Tasks;

namespace mofo.todo.common.Events
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}