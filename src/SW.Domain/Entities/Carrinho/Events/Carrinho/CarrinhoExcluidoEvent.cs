using SW.Domain.Core.Events;
using System;

namespace SW.Domain.Entities.Carrinho.Events.Carrinho
{
    public class CarrinhoExcluidoEvent : Event
    {
        public Guid Id { get; set; }
        public CarrinhoExcluidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
