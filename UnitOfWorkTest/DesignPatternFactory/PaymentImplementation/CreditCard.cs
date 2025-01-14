using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkTest.DesignPatternFactory.PaymentImplementation
{
    public class CreditCard : IPayment
    {
        public Task<string> Pay(decimal amount)
        {
            return Task.FromResult($"Paid {amount} using Credit Card.");
        }

        public string Cancell()
        {
            return "Payment cancelled";
        }
    }
}