using System;
using CheckoutPaymentGateway.Enums;
using CheckoutPaymentGateway.Interfaces;
using CheckoutPaymentGateway.Models;

namespace CheckoutPaymentGateway.Mock
{
    public class MockedBankInstitution : IBank
    {
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