using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkTest.DesignPatternRepository.Interfaces;
using UnitOfWorkTest.Data;

namespace UnitOfWorkTest.DesignPatternRepository.Classes
{

    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        private readonly DbSet<User> _dbSet;
        public UserRepository(MyDbContext myDbContext) : base(myDbContext)
        {
            this._dbSet = myDbContext.Set<User>();
        }

        public async Task<IEnumerable<User>> GetTopNUsers(int TopNUsers)
        {
            return await Task.Run(() => this._dbSet
            .Include(e => e.ActiveUsers)
            .OrderByDescending(e => e.Id)
            .Take(TopNUsers)
            .ToList());
        }
    }
}