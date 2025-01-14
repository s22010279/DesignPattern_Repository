using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkTest.Data;
using UnitOfWorkTest.DesignPatternRepository.Interfaces;

namespace UnitOfWorkTest.DesignPatternRepository.Classes
{
    public class OrderRepository : GenericRepository<Order, int>
    {
        public OrderRepository(MyDbContext context) : base(context)
        {
        }
    }
}