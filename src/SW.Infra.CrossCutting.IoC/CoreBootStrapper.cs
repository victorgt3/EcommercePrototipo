using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SW.Domain.Core.Notifications;
using SW.Domain.Handlers;
using SW.Domain.Interfaces;
using SW.Infra.CrossCutting.AutoMapper;
using SW.Infra.Data.Context;
using SW.Infra.Data.UoW;

namespace SW.Infra.CrossCutting.IoC
{
    public class CoreBootStrapper
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IMediatorHandler, MediatorHandler>();

            services.AddSingleton(AutoMapperConfiguration.RegisterMappings().CreateMapper());

            // Domain - Eventos
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ApplicationDbContext>();

        }
            
    }
}
