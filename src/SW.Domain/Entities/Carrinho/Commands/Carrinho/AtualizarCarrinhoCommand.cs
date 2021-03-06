﻿using SW.Domain.Core.Commands;
using System;

namespace SW.Domain.Entities.Carrinho.Commands.Carrinho
{
    public class AtualizarCarrinhoCommand : Command
    {
        public Guid Id { get; protected set; }
        public int Quantidade { get; set; }
        public Guid ProdutoId { get; set; }
        public AtualizarCarrinhoCommand(Guid id, int quantidade, Guid produtoId)
        {
            Id = id;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            AggregateId = id;
        }
    }
  
}
