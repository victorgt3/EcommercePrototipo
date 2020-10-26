using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SW.Domain.Entities.Produto.Commands.Promocao;
using SW.Domain.Entities.Produto.Events.Promocao;
using SW.Domain.Entities.Promocao.Commands;
using SW.Domain.Entities.Promocao.Events;
using SW.Domain.Entities.Promocao.Repository;
using SW.Infra.Data.Repositories.Promocao;

namespace SW.Infra.CrossCutting.IoC.Promocao
{
    public class PromocaoBootStrapper
    {
        public static void Register(IServiceCollection services)
        {
            //// Domain - Commands
            services.AddScoped<IRequestHandler<RegistrarPromocaoCommand, bool>, PromocaoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarPromocaoCommand, bool>, PromocaoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirPromocaoCommand, bool>, PromocaoCommandHandler>();


            //// Domain - Eventos
            services.AddScoped<INotificationHandler<PromocaoRegistradoEvent>, PromocaoEventHandler>();
            services.AddScoped<INotificationHandler<PromocaoAtualizadoEvent>, PromocaoEventHandler>();
            services.AddScoped<INotificationHandler<PromocaoExcluidoEvent>, PromocaoEventHandler>();

            //// Infra - Data
            services.AddScoped<IPromocaoRepository, PromocaoRepository>();
        }
    }
}
