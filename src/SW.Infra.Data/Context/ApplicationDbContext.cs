using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SW.Domain.Entities.Carrinho;
using SW.Domain.Entities.Produto;
using SW.Domain.Entities.Promocao;
using SW.Infra.Data.Extensions;
using SW.Infra.Data.Mappings;
using System.IO;

namespace SW.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Promocao> Promocao { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new PromocaoMapping());

            modelBuilder.AddConfiguration(new ProdutoMapping());

            modelBuilder.Entity<Promocao>()
                .HasData(new Promocao("3 por 10 reais"),
                         new Promocao("Leve 2 e Pague 1"));

            modelBuilder.AddConfiguration(new CarrinhoMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
