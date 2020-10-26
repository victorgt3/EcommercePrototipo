using SW.Domain.Core.Events;
using System;

namespace SW.Domain.Entities.Produto.Events.Promocao
{
    public class PromocaoAtualizadoEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Descricao { get; protected set; }
        public PromocaoAtualizadoEvent(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            AggregateId = id;
        }
    }
}
