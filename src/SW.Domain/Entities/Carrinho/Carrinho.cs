using SW.Domain.Core.Models;
using System;

namespace SW.Domain.Entities.Carrinho
{
    public class Carrinho : Entity<Carrinho>
    {
        public int Quantidade { get; set; }
        public Guid ProdutoId { get; set; }
        public virtual Produto.Produto Produto { get; set; }
        protected Carrinho() { }
        public Carrinho(Guid id, int quantidade, Guid produtoId)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Quantidade = quantidade;
            ProdutoId = produtoId;
        }

        public override bool EhValido()
        {
            return true;
        }

        public void IncluirProduto(Produto.Produto produto)
        {
            Produto = produto;
        }
    }
}
