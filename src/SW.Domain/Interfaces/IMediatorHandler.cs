using SW.Domain.Core.Commands;
using SW.Domain.Core.Events;
using System.Threading.Tasks;

namespace SW.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task EnviarComando<T>(T comando) where T : Command;
    }
}
