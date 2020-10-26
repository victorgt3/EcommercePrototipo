using System;

namespace SW.Infra.CrossCutting.AutoMapper.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public Guid? PromocaoId { get; set; }
        public PromocaoViewModel Promocao { get; set; }
    }
}
