using System;
using CheckoutPaymentGateway.Models;

namespace CheckoutPaymentGateway.Interfaces
{
    /// <summary>
    /// Interface for the Payment Gateway processing
    /// </summary>
    public interface IPaymentGateway
    {
        /// <summary>
        /// Processes the payment request.
        /// </summary>
        /// <param name="request">The payment request.</param>
        /// <returns>A Payment Reponse</returns>
        IPaymentResponse ProcessPayment(PaymentRequest request);

        /// <summary>
        /// Retrieves the payment information.
        /// </summary>
        /// <param name="id">The payment request identifier.</param>
        /// <returns>The Payment Information</returns>
        PaymentInfo RetrievePaymentInfo(Guid id);
    }
}