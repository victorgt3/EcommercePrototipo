using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SW.Domain.Entities.Carrinho;
using SW.Infra.Data.Extensions;

namespace SW.Infra.Data.Mappings
{
    class CarrinhoMapping : EntityTypeConfiguration<Carrinho>
    {
        public override void Map(EntityTypeBuilder<Carrinho> builder)
        {
            builder.Property(c => c.Quantidade)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(c => c.Produto)
             .WithMany()
             .HasForeignKey(c => c.ProdutoId)
            .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(g => g.CascadeMode);

            builder.ToTable("Carrinho");
        }
    }
}
