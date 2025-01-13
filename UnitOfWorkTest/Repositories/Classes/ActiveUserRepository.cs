using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkTest.Repositories.Classes;
using UnitOfWorkTest.Repositories.Interfaces;

namespace UnitOfWorkTest.Repositories.Classes
{
  public class ActiveUserRepository : GenericRepository<ActiveUser, int>, IActiveUserRepository
  {
    public readonly MyDbContext _context;
    public ActiveUserRepository(MyDbContext context) : base(context)
    {
      this._context = context;
    }
  }
}