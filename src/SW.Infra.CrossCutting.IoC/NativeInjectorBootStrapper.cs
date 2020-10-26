using Microsoft.Extensions.DependencyInjection;
using SW.Infra.CrossCutting.IoC.Carrinho;
using SW.Infra.CrossCutting.IoC.Produto;
using SW.Infra.CrossCutting.IoC.Promocao;

namespace SW.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Core
            CoreBootStrapper.Register(services);

            PromocaoBootStrapper.Register(services);

            ProdutoBootStrapper.Register(services);

            CarrinhoBootStrapper.Register(services);
        }
    }
}
