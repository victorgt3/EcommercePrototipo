using SW.Domain.Core.Commands;
using System;

namespace SW.Domain.Entities.Produto.Commands.Produto
{
    public class RegistrarProdutoCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public decimal Preco { get; protected set; }
        public Guid? PromocaoId { get; protected set; }

        public RegistrarProdutoCommand(Guid id, string nome, decimal preco, Guid? promocaoId)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            PromocaoId = promocaoId;
            AggregateId = id;
        }
    }
}
