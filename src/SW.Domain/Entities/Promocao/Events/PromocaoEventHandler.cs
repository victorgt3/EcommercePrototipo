using MediatR;
using SW.Domain.Entities.Produto.Events.Promocao;
using System.Threading;
using System.Threading.Tasks;

namespace SW.Domain.Entities.Promocao.Events
{
    public class PromocaoEventHandler :
        INotificationHandler<PromocaoRegistradoEvent>,
        INotificationHandler<PromocaoAtualizadoEvent>,
        INotificationHandler<PromocaoExcluidoEvent>
    {
        public Task Handle(PromocaoRegistradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(PromocaoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PromocaoExcluidoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
