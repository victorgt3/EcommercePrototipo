using SW.Domain.Core.Events;
using System;

namespace SW.Domain.Entities.Produto.Events.Produto
{
    public class ProdutoExcluidoEvent : Event
    {
        public Guid Id { get; protected set; }
        public ProdutoExcluidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
