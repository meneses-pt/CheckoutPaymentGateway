using System;
using CheckoutPaymentGateway.Interfaces;
using CheckoutPaymentGateway.Models.Enums;
using CheckoutPaymentGateway.Models.Models;
using NLog;

namespace CheckoutPaymentGateway.Mock
{
    /// <summary>
    /// The Implementation of a Mock Bank Institution
    /// </summary>
    /// <seealso cref="CheckoutPaymentGateway.Interfaces.IBank" />
    public class MockedBankInstitution : IBank
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Mock Processes the payment request.
        /// </summary>
        /// <param name="request">The payment request.</param>
        /// <returns>
        /// A Payment Response
        /// </returns>
        public PaymentResponse ProcessPayment(PaymentRequest request)
        {
            _logger.Log(LogLevel.Info, "Payment Request received");

            if (request == null)
            {
                return null;
            }

            var response = new PaymentResponse {Id = Guid.NewGuid()};

            if (string.IsNullOrEmpty(request.CVV) ||
                string.IsNullOrEmpty(request.CardNumber) ||
                string.IsNullOrEmpty(request.CardHolderName) ||
                string.IsNullOrEmpty(request.CardHolderName) ||
                string.IsNullOrEmpty(request.Currency) ||
                string.IsNullOrEmpty(request.ExpiryDate) ||
                request.Amount <= 0 ||
                request.CardNumber.Length != 16 ||
                request.Currency.Length != 3)
            {
                response.Status = Status.Declined;
                return response;
            }

            var expiryDateSplit = request.ExpiryDate.Split("/");
            if (expiryDateSplit.Length != 2)
            {
                response.Status = Status.Declined;
                return response;
            }

            if (!int.TryParse(expiryDateSplit[0], out var month))
            {
                response.Status = Status.Declined;
                return response;
            }

            if (!int.TryParse(expiryDateSplit[1], out var year))
            {
                response.Status = Status.Declined;
                return response;
            }

            var expiryDate = new DateTime(year + 2000, month, 1).AddMonths(1).AddDays(-1);
            if (DateTime.Today > expiryDate.Date)
            {
                response.Status = Status.Expired;
                return response;
            }

            return response;
        }
    }
}