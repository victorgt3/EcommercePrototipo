using AutoMapper;
using SW.Infra.CrossCutting.AutoMapper.Maps.Carrinho;
using SW.Infra.CrossCutting.AutoMapper.Maps.Produto;
using SW.Infra.CrossCutting.AutoMapper.Maps.Promocao;

namespace SW.Infra.CrossCutting.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps => 
            {
                ps.AddMemberConfiguration();
                ps.AddProfile(new ProdutoMappingProfile());
                ps.AddProfile(new PromocaoMappingProfile());
                ps.AddProfile(new CarrinhoMappingProfile());
            });
        }
    }
}
