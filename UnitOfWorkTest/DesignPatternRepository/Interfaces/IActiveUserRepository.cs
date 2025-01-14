using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkTest.Data;
using UnitOfWorkTest.DesignPatternRepository.Classes;

namespace UnitOfWorkTest.DesignPatternRepository.Interfaces
{
    public interface IActiveUserRepository : IGenericRepository<ActiveUser, int>
    {

    }
}