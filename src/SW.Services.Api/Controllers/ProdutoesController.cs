using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SW.Domain.Entities.Produto.Commands.Produto;
using SW.Domain.Entities.Produto.Repository;
using SW.Domain.Entities.Promocao.Repository;
using SW.Domain.Interfaces;
using SW.Infra.CrossCutting.AutoMapper.ViewModels;

namespace SW.Services.Api.Controllers
{
    public class ProdutoesController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPromocaoRepository _promocaoRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;

        public ProdutoesController(IProdutoRepository produtoRepository, 
            IMediatorHandler mediator, IMapper mapper, IPromocaoRepository promocaoRepository)
        {
            _produtoRepository = produtoRepository;
            _mediator = mediator;
            _mapper = mapper;
            _promocaoRepository = promocaoRepository;
        }

        // GET: Produtoes
        public async Task<IActionResult> Index()
        {
            try
            {
                var produto = _produtoRepository.ObterTodos();
                return View(produto);
            }

            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
           
        }

        // GET: Produtoes/Details/5
        public IActionResult Details(Guid id)
        {

            return View(_produtoRepository.ObterPorId(id));
        }

        // GET: Produtoes/Create
        public IActionResult Create()
        {
            
            ViewData["PromocaoId"] = new SelectList(_promocaoRepository.ObterTodos(), "Id", "Descricao");
            return View();
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            try
            {
                var produtoCommand = _mapper.Map<RegistrarProdutoCommand>(produtoViewModel);
                await  _mediator.EnviarComando(produtoCommand);
                return RedirectToAction("Index", "Produtoes");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET: Produtoes/Edit/5
        public IActionResult Edit(Guid id)
        {
            return View(_produtoRepository.ObterPorId(id));
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProdutoViewModel produtoViewModel)
        {
            try
            {
                var produtoCommand = _mapper.Map<AtualizarProdutoCommand>(produtoViewModel);
                await _mediator.EnviarComando(produtoCommand);
                return RedirectToAction("Index", "Produtoes");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET: Produtoes/Delete/5
        public IActionResult Delete(Guid id)
        {
            return View(_produtoRepository.ObterPorId(id));
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                var produtoViewModel = new ProdutoViewModel { Id = id };
                var produtoCommand = _mapper.Map<ExcluirProdutoCommand>(produtoViewModel);
                _mediator.EnviarComando(produtoCommand);
                return RedirectToAction("Index", "Produtoes");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
