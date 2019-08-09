using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace CheckoutPaymentGateway.Models.Models
{
    /// <summary>
    /// An implementation of the Payment Request structure
    /// </summary>
    [Owned]
    public class PaymentRequest
    {
        /// <summary>
        /// Gets or sets the credit card number.
        /// </summary>
        /// <value>
        /// The credit card number.
        /// </value>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the credit card holder.
        /// </summary>
        /// <value>
        /// The name of the credit card holder.
        /// </value>
        public string CardHolderName { get; set; }

        /// <summary>
        /// Gets or sets the expiry date for the credit card.
        /// </summary>
        /// <value>
        /// The expiry date of the credit card.
        /// </value>
        public string ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the amount to be charged on the payment.
        /// </summary>
        /// <value>
        /// The amount to be charged on the payment.
        /// </value>
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the currency for the payment.
        /// </summary>
        /// <value>
        /// The currency for the payment.
        /// </value>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the CVV code of the credit card.
        /// </summary>
        /// <value>
        /// The CVV code of the credit card.
        /// </value>
        public string CVV { get; set; }

        /// <summary>
        /// Masks the credit card number.
        /// </summary>
        public string MaskCardNumber()
        {
            if (CardNumber == null)
            {
                return null;
            }

            if (CardNumber.Length <= 4)
            {
                return Regex.Replace(CardNumber, "\\d", "*");
            }

            return Regex.Replace(
                       CardNumber.Substring(0, CardNumber.Length - 4),
                       "\\d",
                       "*") +
                   CardNumber.Substring(CardNumber.Length - 4, 4);
        }
    }
}