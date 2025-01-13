using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkTest.Repositories.Interfaces;

namespace UnitOfWorkTest.Repositories.classes
{

    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public readonly MyDbContext _context;
        public UserRepository(MyDbContext myDbContext) : base(myDbContext)
        {
            this._context = myDbContext;
        }

        public async Task<IEnumerable<User>> GetTopNUsers(int TopNUsers)
        {
            return await Task.Run(() => this._context.Users
            .Include(e => e.ActiveUsers)
            .OrderByDescending(e => e.Id)
            .Take(TopNUsers)
            .ToList());
        }
    }
}