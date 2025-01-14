using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkTest.DesignPatternFactory.PaymentImplementation;

namespace UnitOfWorkTest.DesignPatternFactory
{
    public class PaymentFactory
    {
        public static IPayment Create(PaymentMethodEnum paymentMethod)
        {
            return paymentMethod switch
            {
                PaymentMethodEnum.CreditCard => new CreditCard(),
                PaymentMethodEnum.GooglePay => new GooglePay(),
                PaymentMethodEnum.PayPal => new PayPal(),
                _ => throw new Exception("Invalid Payment Method"),
            };
        }
    }
}