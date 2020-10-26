using MediatR;
using SW.Domain.Core.Notifications;
using SW.Domain.Entities.Carrinho.Commands.Carrinho;
using SW.Domain.Entities.Carrinho.Events.Carrinho;
using SW.Domain.Entities.Carrinho.Repository;
using SW.Domain.Handlers;
using SW.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SW.Domain.Entities.Carrinho.Commands
{
    public class CarrinhoCommandHandler : CommandHandler,
        IRequestHandler<RegistrarCarrinhoCommand, bool>,
        IRequestHandler<AtualizarCarrinhoCommand, bool>,
        IRequestHandler<ExcluirCarrinhoCommand, bool>
    {
        private readonly IMediatorHandler _mediator;
        private readonly ICarrinhoRepository _carrinhoRepository;
        public CarrinhoCommandHandler(IUnitOfWork uow,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            ICarrinhoRepository carrinhoRepository) : base(uow, mediator, notifications)
        {
            _mediator = mediator;
            _carrinhoRepository = carrinhoRepository;
        }

        public Task<bool> Handle(RegistrarCarrinhoCommand request, CancellationToken cancellationToken)
        {
            var carrinho = new Entities.Carrinho.Carrinho(request.Id, request.Quantidade, request.ProdutoId);

            if (!carrinho.EhValido())
            {
                NotificarValidacoesErro(carrinho.ValidationResult);
                return Task.FromResult(false);
            }

            _carrinhoRepository.Adicionar(carrinho);

            if (Commit())
            {
                _mediator.PublicarEvento(new CarrinhoRegistradoEvent(carrinho.Id, carrinho.Quantidade, carrinho.ProdutoId));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(AtualizarCarrinhoCommand request, CancellationToken cancellationToken)
        {
            var carrinho = new Entities.Carrinho.Carrinho(request.Id, request.Quantidade, request.ProdutoId);

            if (!carrinho.EhValido())
            {
                NotificarValidacoesErro(carrinho.ValidationResult);
                return Task.FromResult(false);
            }

            _carrinhoRepository.Atualizar(carrinho);

            if (Commit())
            {
                _mediator.PublicarEvento(new CarrinhoAtualizadoEvent(carrinho.Id, carrinho.Quantidade, carrinho.ProdutoId));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(ExcluirCarrinhoCommand request, CancellationToken cancellationToken)
        {
            var carrinho = _carrinhoRepository.ObterPorId(request.Id);

            _carrinhoRepository.Remover(carrinho.Id);

            if (Commit())
            {
                _mediator.PublicarEvento(new CarrinhoExcluidoEvent(carrinho.Id));
            }

            return Task.FromResult(true);
        }
    }
}
