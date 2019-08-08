using CheckoutPaymentGateway.Models;

namespace CheckoutPaymentGateway.Interfaces
{
    /// <summary>
    /// Interface for the Bank requests
    /// </summary>
    public interface IBank
    {
        /// <summary>
        /// Processes the payment request.
        /// </summary>
        /// <param name="request">The payment request.</param>
        /// <returns>A Payment Response</returns>
        IPaymentResponse ProcessPayment(PaymentRequest request);
    }
}