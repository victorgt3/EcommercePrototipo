using SW.Domain.Core.Events;
using System;

namespace SW.Domain.Entities.Produto.Events.Promocao

{
    public class PromocaoExcluidoEvent : Event
    {
        public Guid Id { get; protected set; }
        public PromocaoExcluidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
