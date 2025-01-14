using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkTest.DesignPatternRepository.Classes;
using UnitOfWorkTest.DesignPatternRepository.Interfaces;
using UnitOfWorkTest.Data;

namespace UnitOfWorkTest.DesignPatternRepository.Classes
{
  public class ActiveUserRepository : GenericRepository<ActiveUser, int>, IActiveUserRepository
  {
    public ActiveUserRepository(MyDbContext context) : base(context)
    {
    }
  }
}