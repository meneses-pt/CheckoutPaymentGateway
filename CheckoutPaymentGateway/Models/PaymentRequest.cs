using System.Text.RegularExpressions;
using CheckoutPaymentGateway.Interfaces;

namespace CheckoutPaymentGateway.Models
{
    /// <summary>
    /// An implementation of the Payment Request structure
    /// </summary>
    /// <seealso cref="CheckoutPaymentGateway.Interfaces.IPaymentRequest" />
    public class PaymentRequest : IPaymentRequest
    {
        /// <inheritdoc />
        public string CardNumber { get; set; }

        /// <inheritdoc />
        public string CardHolderName { get; set; }

        /// <inheritdoc />
        public string ExpiryDate { get; set; }

        /// <inheritdoc />
        public double Amount { get; set; }

        /// <inheritdoc />
        public string Currency { get; set; }

        /// <inheritdoc />
        public string CVV { get; set; }

        /// <inheritdoc />
        public string MaskCardNumber()
        {
            if (CardNumber == null)
            {
                return null;
            }
            else if (CardNumber.Length <= 4)
            {
                return Regex.Replace(CardNumber, "\\d", "*");
            }
            else
            {
                return Regex.Replace(
                                 CardNumber.Substring(0, CardNumber.Length - 4),
                                 "\\d",
                                 "*") +
                             CardNumber.Substring(CardNumber.Length - 4, 4);
            }
        }
    }
}