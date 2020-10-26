using SW.Domain.Core.Commands;
using System;

namespace SW.Domain.Entities.Produto.Commands.Produto
{
    public class ExcluirProdutoCommand : Command
    {
        public Guid Id { get; protected set; }
        public ExcluirProdutoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
