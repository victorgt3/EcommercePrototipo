using FluentValidation;
using SW.Domain.Core.Models;
using System;

namespace SW.Domain.Entities.Produto
{
    public class Produto : Entity<Produto>
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public Guid? PromocaoId { get; private set; }
        public virtual Promocao.Promocao Promocao { get; private set; }
        protected Produto() { }
        public override bool EhValido()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome é requerido!");

            RuleFor(c => c.Preco)
                .NotEmpty().WithMessage("O preço é requerido!");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
        public Produto(Guid id, string nome, decimal preco, Guid? promocaoId)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Nome = nome;
            Preco = preco;
            PromocaoId = promocaoId;
        }

        public void IncluirPromocao(Promocao.Promocao promocao)
        {
            Promocao = promocao;
        }
    }
}
