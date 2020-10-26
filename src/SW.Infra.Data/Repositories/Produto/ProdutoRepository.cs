using Dapper;
using Microsoft.EntityFrameworkCore;
using SW.Domain.Entities.Produto.Repository;
using SW.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SW.Infra.Data.Repositories.Produto
{
    public class ProdutoRepository : Repository<Domain.Entities.Produto.Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override IEnumerable<Domain.Entities.Produto.Produto> ObterTodos()
        {
            const string sql = @"SELECT * FROM Produto p
                                LEFT JOIN Promocao pr ON p.PromocaoId = pr.Id";

            return Db.Database.GetDbConnection()
                .Query<Domain.Entities.Produto.Produto, Domain.Entities.Promocao.Promocao,
                Domain.Entities.Produto.Produto>(sql, (p, pr) =>
                {
                    p.IncluirPromocao(pr);
                    return p;
                });
        }


        public override Domain.Entities.Produto.Produto ObterPorId(Guid id)
        {
            const string sql = @"SELECT * FROM Produto p
                                LEFT JOIN Promocao pr ON p.PromocaoId = pr.Id
                                WHERE p.Id = @uId";

            return Db.Database.GetDbConnection()
                .Query<Domain.Entities.Produto.Produto, Domain.Entities.Promocao.Promocao,
                Domain.Entities.Produto.Produto>(sql, (p, pr) =>
                {
                    p.IncluirPromocao(pr);
                    return p;
                }, new { uId = id }).FirstOrDefault();
        }
    }
}
