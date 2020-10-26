using MediatR;
using SW.Domain.Core.Notifications;
using SW.Domain.Entities.Produto.Commands.Promocao;
using SW.Domain.Entities.Produto.Events.Promocao;
using SW.Domain.Entities.Promocao.Repository;
using SW.Domain.Handlers;
using SW.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SW.Domain.Entities.Promocao.Commands
{
    public class PromocaoCommandHandler : CommandHandler,
        IRequestHandler<RegistrarPromocaoCommand, bool>,
        IRequestHandler<AtualizarPromocaoCommand, bool>,
        IRequestHandler<ExcluirPromocaoCommand, bool>
    {
        private readonly IMediatorHandler _mediator; 
        private readonly IPromocaoRepository _promocaoRepository;
        public PromocaoCommandHandler(IUnitOfWork uow,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator, 
            IPromocaoRepository promocaoRepository) : base(uow, mediator, notifications)
        {
            _mediator = mediator;
            _promocaoRepository = promocaoRepository;
        }
        public Task<bool> Handle(RegistrarPromocaoCommand request, CancellationToken cancellationToken)
        {
            var promocao = new Entities.Promocao.Promocao(request.Descricao);
            
            if (!promocao.EhValido())
            {
                NotificarValidacoesErro(promocao.ValidationResult);
                return Task.FromResult(false);
            }
            
            _promocaoRepository.Adicionar(promocao);

            if (Commit()) 
            {
                _mediator.PublicarEvento(new PromocaoRegistradoEvent(promocao.Id, promocao.Descricao));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(AtualizarPromocaoCommand request, CancellationToken cancellationToken)
        {
            var promocao = new Entities.Promocao.Promocao(request.Descricao);

            if (!promocao.EhValido())
            {
                NotificarValidacoesErro(promocao.ValidationResult);
                return Task.FromResult(false);
            }

            _promocaoRepository.Atualizar(promocao);

            if (Commit())
            {
                _mediator.PublicarEvento(new PromocaoAtualizadoEvent(promocao.Id, promocao.Descricao));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(ExcluirPromocaoCommand request, CancellationToken cancellationToken)
        {
            var promocao = _promocaoRepository.ObterPorId(request.Id);

            _promocaoRepository.Remover(promocao.Id);

            if (Commit())
            {
                _mediator.PublicarEvento(new PromocaoExcluidoEvent(promocao.Id));
            }

            return Task.FromResult(true);
        }
    }
}
