using MediatR;
using SW.Domain.Entities.Produto.Events.Produto;
using System.Threading;
using System.Threading.Tasks;

namespace SW.Domain.Entities.Produto.Events
{
    public class ProdutoEventHandler :
        INotificationHandler<ProdutoRegistradoEvent>,
        INotificationHandler<ProdutoAtualizadoEvent>,
        INotificationHandler<ProdutoExcluidoEvent>
    {
        public Task Handle(ProdutoRegistradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(ProdutoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ProdutoExcluidoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
