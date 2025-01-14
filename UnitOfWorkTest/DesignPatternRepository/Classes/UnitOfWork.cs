using UnitOfWorkTest.Data;
using UnitOfWorkTest.DesignPatternRepository.Interfaces;

namespace UnitOfWorkTest.DesignPatternRepository.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;
        public IUserRepository  UserRepository { get; }
        public IActiveUserRepository ActiveUserRepository { get; }
        public IGenericRepository<Order, int> OrderRepository { get; }

        public UnitOfWork(
            MyDbContext context,
            IUserRepository userRepository,
            IActiveUserRepository  activeUserRepository,
            IGenericRepository<Order, int> OrderRepository)
        {
            this._context = context;
            this.UserRepository = userRepository;
            this.ActiveUserRepository = activeUserRepository;
            this.OrderRepository = OrderRepository;
        }

        public void Commit()
        {
            if (_context.ChangeTracker.HasChanges())
            {
                this._context.SaveChanges();
            }
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

    }
}