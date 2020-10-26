using System;

namespace SW.Infra.CrossCutting.AutoMapper.ViewModels
{
    public class CarrinhoViewModel
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
        public Guid ProdutoId { get; set; }
    }
}
