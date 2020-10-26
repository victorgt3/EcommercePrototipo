using AutoMapper;
using SW.Domain.Entities.Produto.Commands.Produto;
using SW.Infra.CrossCutting.AutoMapper.ViewModels;

namespace SW.Infra.CrossCutting.AutoMapper.Maps.Produto
{
    public class ProdutoMappingProfile : Profile
    {
        public ProdutoMappingProfile()
        {
            CreateMap<Domain.Entities.Produto.Produto, ProdutoViewModel>();

            CreateMap<ProdutoViewModel, RegistrarProdutoCommand>()
              .ConstructUsing(c => new RegistrarProdutoCommand(c.Id, c.Nome, c.Preco, c.PromocaoId));

            CreateMap<ProdutoViewModel, AtualizarProdutoCommand>()
              .ConstructUsing(c => new AtualizarProdutoCommand(c.Id, c.Nome, c.Preco, c.PromocaoId));

            CreateMap<ProdutoViewModel, ExcluirProdutoCommand>()
              .ConstructUsing(c => new ExcluirProdutoCommand(c.Id));

        }
    }
}
