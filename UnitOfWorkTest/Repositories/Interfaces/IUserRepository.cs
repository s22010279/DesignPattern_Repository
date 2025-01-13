using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkTest.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<IEnumerable<User>> GetTopNUsers(int TopNUsers);
    }
}