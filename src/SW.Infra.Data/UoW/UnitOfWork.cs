using SW.Domain.Interfaces;
using SW.Infra.Data.Context;
using System;

namespace SW.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                var t = ex.Message;
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
