using System;
using CheckoutPaymentGateway.Interfaces;
using CheckoutPaymentGateway.Models.Models;

namespace CheckoutPaymentGateway.BL
{
    /// <summary>
    /// Business Logic for the Payment Gateway
    /// </summary>
    /// <seealso cref="CheckoutPaymentGateway.Interfaces.IPaymentGateway" />
    public class PaymentGateway : IPaymentGateway
    {
        private readonly IBank _bank;
        private readonly IStorage _storage;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentGateway"/> class.
        /// </summary>
        /// <param name="bank">The bank instance.</param>
        /// <param name="storage">The storage instance.</param>
        public PaymentGateway(IBank bank, IStorage storage)
        {
            _bank = bank;
            _storage = storage;
        }

        /// <summary>
        /// Processes the payment and saves the Payment Information.
        /// </summary>
        /// <param name="request">The Payment Request.</param>
        /// <returns>A Payment Response</returns>
        public PaymentResponse ProcessPayment(PaymentRequest request)
        {
            var bankResponse = _bank.ProcessPayment(request);
            var paymentInfo = new PaymentInfo(request, bankResponse);
            if (bankResponse != null)
            {
                _storage.SavePaymentInfo(paymentInfo);
            }

            return bankResponse;
        }

        /// <summary>
        /// Retrieves the payament information.
        /// </summary>
        /// <param name="id">The payment information identifier.</param>
        /// <returns>The payment information with the masked card number.</returns>
        public PaymentInfo RetrievePaymentInfo(Guid id)
        {
            var paymentInfo = _storage.GetPaymentInfo(id);
            if (paymentInfo != null)
            {
                paymentInfo.Request.CardNumber = paymentInfo.Request.MaskCardNumber();
            }

            return paymentInfo;
        }
    }
}