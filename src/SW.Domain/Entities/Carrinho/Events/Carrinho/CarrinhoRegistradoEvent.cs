using SW.Domain.Core.Events;
using System;

namespace SW.Domain.Entities.Carrinho.Events.Carrinho
{
    public class CarrinhoRegistradoEvent : Event
    {
        public Guid Id { get; protected set; }
        public int Quantidade { get; set; }
        public Guid ProdutoId { get; set; }
        public CarrinhoRegistradoEvent(Guid id, int quantidade, Guid produtoId)
        {
            Id = id;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            AggregateId = id;
        }
    }
}
