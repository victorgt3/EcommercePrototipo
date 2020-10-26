using SW.Domain.Core.Events;
using System;

namespace SW.Domain.Entities.Produto.Events.Promocao
{
    public class PromocaoRegistradoEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Descricao { get; protected set; }
        public PromocaoRegistradoEvent(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            AggregateId = id;
        }
    }
}
