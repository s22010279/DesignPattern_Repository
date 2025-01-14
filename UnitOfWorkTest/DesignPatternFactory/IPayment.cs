using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkTest.DesignPatternFactory
{
    public interface IPayment
    {
        Task<string> Pay(decimal amount);

        public string Cancell();
    }
}