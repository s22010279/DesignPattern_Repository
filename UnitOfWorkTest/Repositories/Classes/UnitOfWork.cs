

using UnitOfWorkTest.Repositories.Interfaces;

namespace UnitOfWorkTest.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;

        public IUserRepository UserRepository { get; private set; }
        public IActiveUserRepository ActiveUserRepository { get; private set; }

        public UnitOfWork(MyDbContext context)
        {
            this._context = context;
            this.UserRepository = new UserRepository(this._context);
            this.ActiveUserRepository = new ActiveUserRepository(this._context);
        }

        public async Task CommitAsync()
        {
            await this._context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}