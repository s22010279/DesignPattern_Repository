using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkTest.Data;

namespace UnitOfWorkTest.DesignPatternRepository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IActiveUserRepository ActiveUserRepository { get; }
        IGenericRepository<Order, int> OrderRepository { get; }
        void Commit();
    }
}