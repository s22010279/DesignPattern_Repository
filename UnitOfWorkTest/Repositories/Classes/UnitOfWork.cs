using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkTest.Repositories.Interfaces;

namespace UnitOfWorkTest.Repositories.classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;

        public UnitOfWork(MyDbContext context)
        {
            this._context = context;
        }

        public async Task Commit()
        {
            await this._context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}