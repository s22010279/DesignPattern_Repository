using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkTest.DesignPatternFactory.PaymentImplementation
{
    public class GooglePay : IPayment
    {
        public Task<string> Pay(decimal amount)
        {
            return Task.FromResult($"Paid {amount} using Google Pay.");
        }

        public string Cancell()
        {
            return "Payment cancelled";
        }
    }
}