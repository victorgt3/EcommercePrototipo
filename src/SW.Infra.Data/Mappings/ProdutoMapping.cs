using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SW.Domain.Entities.Produto;
using SW.Infra.Data.Extensions;

namespace SW.Infra.Data.Mappings
{
    public class ProdutoMapping : EntityTypeConfiguration<Produto>
    {
        public override void Map(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Preco)
                .IsRequired()
                .HasColumnType("DECIMAL(5,2)");

            builder.HasOne(c => c.Promocao)
             .WithMany()
             .HasForeignKey(c => c.PromocaoId)
            .IsRequired(false);

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(g => g.CascadeMode);

            builder.ToTable("Produto");
        }
    }
}
