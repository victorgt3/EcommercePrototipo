using Dapper;
using Microsoft.EntityFrameworkCore;
using SW.Domain.Entities.Promocao.Repository;
using SW.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SW.Infra.Data.Repositories.Promocao
{
    public class PromocaoRepository : Repository<Domain.Entities.Promocao.Promocao>, IPromocaoRepository
    {
        public PromocaoRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override IEnumerable<Domain.Entities.Promocao.Promocao> ObterTodos()
        {
            const string sql = @"SELECT * FROM Promocao";

            return Db.Database.GetDbConnection().Query<Domain.Entities.Promocao.Promocao>(sql);
        }


        public override Domain.Entities.Promocao.Promocao ObterPorId(Guid id)
        {
            const string sql = @"SELECT * FROM Promocao p
                                WHERE p.Id = @uId";

            return Db.Database.GetDbConnection()
                .Query<Domain.Entities.Promocao.Promocao>(sql, new { uId = id }).FirstOrDefault();
        }
    }
}
