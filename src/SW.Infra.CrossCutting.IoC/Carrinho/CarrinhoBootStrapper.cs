using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SW.Domain.Entities.Carrinho.Commands;
using SW.Domain.Entities.Carrinho.Commands.Carrinho;
using SW.Domain.Entities.Carrinho.Events;
using SW.Domain.Entities.Carrinho.Events.Carrinho;
using SW.Domain.Entities.Carrinho.Repository;
using SW.Infra.Data.Repositories.Carrinho;

namespace SW.Infra.CrossCutting.IoC.Carrinho
{
    public class CarrinhoBootStrapper
    {
        public static void Register(IServiceCollection services)
        {
            /// Domain - Commands
            services.AddScoped<IRequestHandler<RegistrarCarrinhoCommand, bool>, CarrinhoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarCarrinhoCommand, bool>, CarrinhoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirCarrinhoCommand, bool>, CarrinhoCommandHandler>();


            //// Domain - Eventos
            services.AddScoped<INotificationHandler<CarrinhoRegistradoEvent>, CarrinhoEventHandler>();
            services.AddScoped<INotificationHandler<CarrinhoAtualizadoEvent>, CarrinhoEventHandler>();
            services.AddScoped<INotificationHandler<CarrinhoExcluidoEvent>, CarrinhoEventHandler>();

            //// Infra - Data
            services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
        }
    }
}
