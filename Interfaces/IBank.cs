using CheckoutPaymentGateway.Models;

namespace CheckoutPaymentGateway.Interfaces
{
    public interface IBank
    {
        IPaymentResponse ProcessPayment(PaymentRequest request);
    }
}