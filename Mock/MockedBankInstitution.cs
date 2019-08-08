using System;
using CheckoutPaymentGateway.Enums;
using CheckoutPaymentGateway.Interfaces;
using CheckoutPaymentGateway.Models;

namespace CheckoutPaymentGateway.Mock
{
    /// <summary>
    /// The Implementation of a Mock Bank Institution
    /// </summary>
    /// <seealso cref="CheckoutPaymentGateway.Interfaces.IBank" />
    public class MockedBankInstitution : IBank
    {
        /// <summary>
        /// Mock Processes the payment request.
        /// </summary>
        /// <param name="request">The payment request.</param>
        /// <returns>
        /// A Payment Response
        /// </returns>
        public IPaymentResponse ProcessPayment(PaymentRequest request)
        {
            var response = new PaymentResponse {Id = Guid.NewGuid()};

            if (string.IsNullOrEmpty(request.CVV) ||
                string.IsNullOrEmpty(request.CardNumber) ||
                string.IsNullOrEmpty(request.CardHolderName) ||
                string.IsNullOrEmpty(request.CardHolderName) ||
                string.IsNullOrEmpty(request.Currency) ||
                string.IsNullOrEmpty(request.ExpiryDate))
            {
                response.Status = Status.Declined;
            }

            response.Status = Status.Authorized;
            return response;
        }
    }
}