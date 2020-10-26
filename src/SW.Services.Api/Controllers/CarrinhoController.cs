using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SW.Domain.Entities.Carrinho.Commands.Carrinho;
using SW.Domain.Entities.Carrinho.Repository;
using SW.Domain.Interfaces;
using SW.Infra.CrossCutting.AutoMapper.ViewModels;
using System;
using System.Threading.Tasks;

namespace SW.Services.Api.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;
        public CarrinhoController(ICarrinhoRepository carrinhoRepository, 
            IMediatorHandler mediator, IMapper mapper)
        {
            _carrinhoRepository = carrinhoRepository;
            _mediator = mediator;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            var carrinho = _carrinhoRepository.ObterTodos();

            decimal total = 0;
            
            foreach(var item in carrinho)
            {
                if(item.Produto.Promocao != null)
                {
                    if (item.Produto.Promocao.Descricao == "Leve 2 e Pague 1" && item.Quantidade == 2)
                    {
                        total += item.Produto.Preco;
                    }
                    else if (item.Produto.Promocao.Descricao == "3 por 10 reais" && item.Quantidade == 3)
                    {
                        total += 10;
                    }
                    else
                    {
                        total += item.Quantidade * item.Produto.Preco;
                    }
                }
                else
                {
                    total += item.Quantidade * item.Produto.Preco;
                }
            }

            ViewData["Total"] = total;

            return View(carrinho);
        }
        public async Task<IActionResult> Create(Guid id, int quantidade = 1)
        {
            var carrinhoViewModel = new CarrinhoViewModel()
            {
                ProdutoId = id,
                Quantidade = quantidade
            };
            var carrinhoCommand = _mapper.Map<RegistrarCarrinhoCommand>(carrinhoViewModel);
            await _mediator.EnviarComando(carrinhoCommand);
            return RedirectToAction("Index", "Carrinho");
        }

        public async Task<IActionResult> UpdateCartItem(Guid id, int quantidade)
        {
            var carrinho = _carrinhoRepository.ObterPorId(id);

            var carrinhoViewModel = new CarrinhoViewModel()
            {
                Id = id,
                ProdutoId = carrinho.ProdutoId,
                Quantidade = quantidade
            };
            var carrinhoCommand = _mapper.Map<AtualizarCarrinhoCommand>(carrinhoViewModel);
            await _mediator.EnviarComando(carrinhoCommand);
            return RedirectToAction("Index", "Carrinho");
        }
        public IActionResult Delete(Guid id)
        {
            try
            {
                var carrinhoViewModel = new CarrinhoViewModel { Id = id };
                var carrinhoCommand = _mapper.Map<ExcluirCarrinhoCommand>(carrinhoViewModel);
                _mediator.EnviarComando(carrinhoCommand);
                return RedirectToAction("Index", "Carrinho");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }

}
