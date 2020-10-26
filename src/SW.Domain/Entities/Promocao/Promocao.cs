using SW.Domain.Core.Models;
using System;

namespace SW.Domain.Entities.Promocao
{
    public class Promocao : Entity<Promocao>
    {
        public string Descricao { get; set; }
        protected Promocao() { }
        public override bool EhValido()
        {
            return true;
        }
        public Promocao(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
        }
    }
}
