using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkTest.DesignPatternFactory;

namespace UnitOfWorkTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentFactoryMethod : ControllerBase
    {

        [HttpPost("PayCreditCard")]
        public async Task<string> PayCreditCard(int paymentMethod, decimal amout)
        {
            var paymentMethodEnum = paymentMethod switch
            {
                1 => PaymentMethodEnum.CreditCard,
                2 => PaymentMethodEnum.PayPal,
                3 => PaymentMethodEnum.GooglePay,
                _ => throw new Exception("Invalid Payment Method"),
            };

            IPayment _payment = PaymentFactory.Create(paymentMethodEnum);
            return await Task.FromResult(await _payment.Pay(amout));
        }
    }
}