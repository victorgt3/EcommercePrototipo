using SW.Domain.Core.Commands;
using System;

namespace SW.Domain.Entities.Carrinho.Commands.Carrinho
{
    public class ExcluirCarrinhoCommand : Command
    {
        public Guid Id { get; protected set; }
        public ExcluirCarrinhoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
