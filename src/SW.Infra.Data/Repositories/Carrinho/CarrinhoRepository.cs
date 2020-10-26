using Dapper;
using Microsoft.EntityFrameworkCore;
using SW.Domain.Entities.Carrinho.Repository;
using SW.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SW.Infra.Data.Repositories.Carrinho
{
    public class CarrinhoRepository : Repository<Domain.Entities.Carrinho.Carrinho>, ICarrinhoRepository
    {
        public CarrinhoRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override IEnumerable<Domain.Entities.Carrinho.Carrinho> ObterTodos()
        {
            const string sql = @"SELECT * FROM Carrinho c
                                LEFT JOIN Produto p ON c.ProdutoId = p.Id
                                LEFT JOIN Promocao pr ON p.PromocaoId = pr.Id";

            return Db.Database.GetDbConnection()
                .Query<Domain.Entities.Carrinho.Carrinho, Domain.Entities.Produto.Produto,
                Domain.Entities.Promocao.Promocao,
                Domain.Entities.Carrinho.Carrinho>(sql, (c, p, pr) =>
                {
                    c.IncluirProduto(p);
                    p.IncluirPromocao(pr);
                    return c;
                });
        }


        public override Domain.Entities.Carrinho.Carrinho ObterPorId(Guid id)
        {
            const string sql = @"SELECT * FROM Carrinho c
                                LEFT JOIN Produto p ON c.ProdutoId = p.Id
                                LEFT JOIN Promocao pr ON p.PromocaoId = pr.Id
                                WHERE c.Id = @uId";

            return Db.Database.GetDbConnection()
               .Query<Domain.Entities.Carrinho.Carrinho, Domain.Entities.Produto.Produto,
                Domain.Entities.Promocao.Promocao,
                Domain.Entities.Carrinho.Carrinho>(sql, (c, p, pr) =>
                {
                    c.IncluirProduto(p);
                    p.IncluirPromocao(pr);
                    return c;
                }, new { uId = id }).FirstOrDefault();
        }
    }
}
