using MediatR;
using SW.Domain.Core.Notifications;
using SW.Domain.Entities.Produto.Commands.Produto;
using SW.Domain.Entities.Produto.Events.Produto;
using SW.Domain.Entities.Produto.Repository;
using SW.Domain.Handlers;
using SW.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SW.Domain.Entities.Produto.Commands
{
    public class ProdutoCommandHandler : CommandHandler,
        IRequestHandler<RegistrarProdutoCommand, bool>,
        IRequestHandler<AtualizarProdutoCommand, bool>,
        IRequestHandler<ExcluirProdutoCommand, bool>
    {
        private readonly IMediatorHandler _mediator; 
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoCommandHandler(IUnitOfWork uow,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator, 
            IProdutoRepository produtoRepository) : base(uow, mediator, notifications)
        {
            _mediator = mediator;
            _produtoRepository = produtoRepository;
        }
        public Task<bool> Handle(RegistrarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Entities.Produto.Produto(request.Id, request.Nome, request.Preco, request.PromocaoId);
            
            if (!produto.EhValido())
            {
                NotificarValidacoesErro(produto.ValidationResult);
                return Task.FromResult(false);
            }
            
            _produtoRepository.Adicionar(produto);

            if (Commit()) 
            {
                _mediator.PublicarEvento(new ProdutoRegistradoEvent(produto.Id, produto.Nome, produto.Preco, produto.PromocaoId));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(AtualizarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Entities.Produto.Produto(request.Id, request.Nome, request.Preco, request.PromocaoId);

            if (!produto.EhValido())
            {
                NotificarValidacoesErro(produto.ValidationResult);
                return Task.FromResult(false);
            }

            _produtoRepository.Atualizar(produto);

            if (Commit())
            {
                _mediator.PublicarEvento(new ProdutoAtualizadoEvent(produto.Id, produto.Nome, produto.Preco, produto.PromocaoId));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(ExcluirProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = _produtoRepository.ObterPorId(request.Id);

            _produtoRepository.Remover(produto.Id);

            if (Commit())
            {
                _mediator.PublicarEvento(new ProdutoExcluidoEvent(produto.Id));
            }

            return Task.FromResult(true);
        }
    }
}
