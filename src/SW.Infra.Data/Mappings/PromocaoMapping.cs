using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SW.Domain.Entities.Promocao;
using SW.Infra.Data.Extensions;

namespace SW.Infra.Data.Mappings
{
    public class PromocaoMapping : EntityTypeConfiguration<Promocao>
    {
        public override void Map(EntityTypeBuilder<Promocao> builder)
        {
            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(g => g.CascadeMode);

            builder.ToTable("Promocao");
        }
    }
}
