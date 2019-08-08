using System;
using CheckoutPaymentGateway.Models;

namespace CheckoutPaymentGateway.Interfaces
{
    public interface IPaymentGateway
    {
        IPaymentResponse ProcessPayment(PaymentRequest request);

        PaymentInfo RetrievePayamentInfo(Guid id);
    }
}