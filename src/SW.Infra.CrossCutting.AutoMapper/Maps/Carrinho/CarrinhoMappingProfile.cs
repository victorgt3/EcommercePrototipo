using AutoMapper;
using SW.Domain.Entities.Carrinho.Commands.Carrinho;
using SW.Infra.CrossCutting.AutoMapper.ViewModels;

namespace SW.Infra.CrossCutting.AutoMapper.Maps.Carrinho
{
    public class CarrinhoMappingProfile : Profile
    {
        public CarrinhoMappingProfile()
        {
            CreateMap<Domain.Entities.Carrinho.Carrinho, CarrinhoViewModel>();

            CreateMap<CarrinhoViewModel, RegistrarCarrinhoCommand>()
              .ConstructUsing(c => new RegistrarCarrinhoCommand(c.Id, c.Quantidade, c.ProdutoId));

            CreateMap<CarrinhoViewModel, AtualizarCarrinhoCommand>()
              .ConstructUsing(c => new AtualizarCarrinhoCommand(c.Id, c.Quantidade, c.ProdutoId));

            CreateMap<CarrinhoViewModel, ExcluirCarrinhoCommand>()
             .ConstructUsing(c => new ExcluirCarrinhoCommand(c.Id));

        }
    }
}
