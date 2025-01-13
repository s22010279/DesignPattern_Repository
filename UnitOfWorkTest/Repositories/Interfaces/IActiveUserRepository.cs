using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkTest.Repositories.Classes;

namespace UnitOfWorkTest.Repositories.Interfaces
{
    public interface IActiveUserRepository : IRepository<ActiveUser, int>
    {

    }
}