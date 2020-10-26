using AutoMapper;
using SW.Domain.Entities.Produto.Commands.Promocao;
using SW.Infra.CrossCutting.AutoMapper.ViewModels;

namespace SW.Infra.CrossCutting.AutoMapper.Maps.Promocao
{
    public class PromocaoMappingProfile : Profile
    {
        public PromocaoMappingProfile()
        {
            CreateMap<Domain.Entities.Promocao.Promocao, PromocaoViewModel>();

            CreateMap<PromocaoViewModel, RegistrarPromocaoCommand>()
              .ConstructUsing(c => new RegistrarPromocaoCommand(c.Id, c.Descricao ));

            CreateMap<PromocaoViewModel, AtualizarPromocaoCommand>()
              .ConstructUsing(c => new AtualizarPromocaoCommand(c.Id, c.Descricao));

            CreateMap<PromocaoViewModel, ExcluirPromocaoCommand>()
             .ConstructUsing(c => new ExcluirPromocaoCommand(c.Id));

        }
    }
}
