using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SW.Domain.Entities.Produto.Commands;
using SW.Domain.Entities.Produto.Commands.Produto;
using SW.Domain.Entities.Produto.Events;
using SW.Domain.Entities.Produto.Events.Produto;
using SW.Domain.Entities.Produto.Repository;
using SW.Infra.Data.Repositories.Produto;

namespace SW.Infra.CrossCutting.IoC.Produto
{
    public class ProdutoBootStrapper
    {
        public static void Register(IServiceCollection services)
        {
            /// Domain - Commands
            services.AddScoped<IRequestHandler<RegistrarProdutoCommand, bool>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarProdutoCommand, bool>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirProdutoCommand, bool>, ProdutoCommandHandler>();


            //// Domain - Eventos
            services.AddScoped<INotificationHandler<ProdutoRegistradoEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<ProdutoAtualizadoEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<ProdutoExcluidoEvent>, ProdutoEventHandler>();

            //// Infra - Data
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

        }
    }
}
