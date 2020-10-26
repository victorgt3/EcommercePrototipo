using SW.Domain.Core.Commands;
using System;

namespace SW.Domain.Entities.Produto.Commands.Promocao
{
    public class AtualizarPromocaoCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Descricao { get; protected set; }
        public AtualizarPromocaoCommand(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            AggregateId = id;
        }
    }
}
