using SW.Domain.Core.Commands;
using System;

namespace SW.Domain.Entities.Produto.Commands.Promocao
{
    public class ExcluirPromocaoCommand : Command
    {
        public Guid Id { get; protected set; }
        public ExcluirPromocaoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
