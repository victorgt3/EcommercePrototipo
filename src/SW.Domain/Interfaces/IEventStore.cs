using SW.Domain.Core.Events;

namespace SW.Domain.Interfaces
{
    public interface IEventStore
    {
        void SalvarEvento<T>(T evento) where T : Event;
    }
}
