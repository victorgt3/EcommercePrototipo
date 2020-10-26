using SW.Domain.Core.Events;
using System;

namespace SW.Domain.Entities.Produto.Events.Produto
{
    public class ProdutoRegistradoEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public decimal Preco { get; protected set; }
        public Guid? PromocaoId { get; protected set; }

        public ProdutoRegistradoEvent(Guid id, string nome, decimal preco, Guid? promocaoId)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            PromocaoId = promocaoId;
            AggregateId = id;
        }
    }
}
