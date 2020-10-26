using MediatR;
using SW.Domain.Entities.Carrinho.Events.Carrinho;
using System.Threading;
using System.Threading.Tasks;

namespace SW.Domain.Entities.Carrinho.Events
{
    public class CarrinhoEventHandler :
        INotificationHandler<CarrinhoRegistradoEvent>,
        INotificationHandler<CarrinhoAtualizadoEvent>,
        INotificationHandler<CarrinhoExcluidoEvent>
    {
        public Task Handle(CarrinhoRegistradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CarrinhoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CarrinhoExcluidoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
